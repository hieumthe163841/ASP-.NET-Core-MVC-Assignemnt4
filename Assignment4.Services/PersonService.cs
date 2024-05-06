using Assignment4.Domain.Contracts;
using Assignment4.Domain.Enums;
using Assignment4.Models;
using ClosedXML.Excel;
namespace Assignment4.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        public IEnumerable<Person> FilterMembersByBirthYear(int year, string comparisonType)
        {

            switch (comparisonType)
            {
                case "Equal":
                    return _personRepository.GetPeople().Where(x => x.DateOfBirth.Year == year);
                case "Greater":
                    return _personRepository.GetPeople().Where(x => x.DateOfBirth.Year > year);
                case "Less":
                    return _personRepository.GetPeople().Where(x => x.DateOfBirth.Year < year);
                default:
                    return null;
            }
        }

        public IEnumerable<Person> GetMaleMembers()
        {
            return _personRepository.GetPeople().Where(x => x.Gender == GenderType.Male);
        }

        public IEnumerable<string> GetMemberFullNames()
        {
            return _personRepository.GetPeople().Select(x => x.FirstName + " " + x.LastName);
        }

        public byte[] GetMembersAsExcelFile()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Members");
                var currentRow = 1;
                // Define header titles
                string[] headers = { "First Name", "Last Name", "Gender", "Date Of Birth", "Phone Number", "Birth Place", "Is Graduated" };

                // Apply header style
                for (int i = 0; i < headers.Length; i++)
                {
                    worksheet.Cell(currentRow, i + 1).Value = headers[i];
                    worksheet.Cell(currentRow, i + 1).Style
                             .Font.SetBold()
                             .Fill.SetBackgroundColor(XLColor.CornflowerBlue)
                             .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                    worksheet.Cell(currentRow, i + 1).Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin);
                }

                foreach (var member in _personRepository.GetPeople())
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = member.FirstName;
                    worksheet.Cell(currentRow, 2).Value = member.LastName;
                    worksheet.Cell(currentRow, 3).Value = member.Gender.ToString();
                    worksheet.Cell(currentRow, 4).Value = member.DateOfBirth.ToString("yyyy-MM-dd");
                    worksheet.Cell(currentRow, 5).Value = member.PhoneNumber;
                    worksheet.Cell(currentRow, 6).Value = member.BirthPlace;
                    worksheet.Cell(currentRow, 7).Value = member.IsGraduated ? "Yes" : "No";

                    // Apply alternating row color
                    if (currentRow % 2 == 0)
                    {
                        worksheet.Range(currentRow, 1, currentRow, 7).Style
                                 .Fill.SetBackgroundColor(XLColor.LightGray);
                    }
                }

                // Adjust column widths
                worksheet.Columns().AdjustToContents();

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    return stream.ToArray();
                }
            }
            //using (var workbook = new XLWorkbook())
            //{
            //    var worksheet = workbook.Worksheets.Add("Members");
            //    var currentRow = 1;

            //    worksheet.Cell(currentRow, 1).Value = "First Name";
            //    worksheet.Cell(currentRow, 2).Value = "Last Name";
            //    worksheet.Cell(currentRow, 3).Value = "Gender";
            //    worksheet.Cell(currentRow, 4).Value = "Date Of Birth";
            //    worksheet.Cell(currentRow, 5).Value = "Phone Number";
            //    worksheet.Cell(currentRow, 6).Value = "Birth Place";
            //    worksheet.Cell(currentRow, 7).Value = "Is Graduated";


            //    foreach (var member in _personRepository.GetPeople())
            //    {
            //        currentRow++;
            //        worksheet.Cell(currentRow, 1).Value = member.FirstName;
            //        worksheet.Cell(currentRow, 2).Value = member.LastName;
            //        worksheet.Cell(currentRow, 3).Value = member.Gender.ToString();
            //        worksheet.Cell(currentRow, 4).Value = member.DateOfBirth.ToString("yyyy-MM-dd");
            //        worksheet.Cell(currentRow, 5).Value = member.PhoneNumber;
            //        worksheet.Cell(currentRow, 6).Value = member.BirthPlace;
            //        worksheet.Cell(currentRow, 7).Value = member.IsGraduated ? "Yes" : "No";
            //    }

            //    using (var stream = new MemoryStream())
            //    {
            //        workbook.SaveAs(stream);
            //        return stream.ToArray();
            //    }
            //}

        }

        public Person GetOldestMember()
        {
            return _personRepository.GetPeople().OrderBy(x => x.DateOfBirth).FirstOrDefault();
        }

        public IEnumerable<Person> GetPeopleList()
        {
            return _personRepository.GetPeople().ToList();
        }
    }
}
