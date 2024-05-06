using Assignment4.Services;
using Microsoft.AspNetCore.Mvc;

namespace Assignment4.WebApp.Areas.NashTech.Controllers
{
    public class RookiesController : Controller
    {
        private readonly IPersonService _personService;

        public RookiesController(IPersonService personService)
        {
            _personService = personService;
        }
        public IActionResult Index()
        {
            var listMembers = _personService.GetPeopleList();
            return Content(string.Join("\n", listMembers.Select(p => p.ToString())));
        }
        public IActionResult MaleMember()
        {
            var listMaleMembers = _personService.GetMaleMembers();
            if (listMaleMembers == null)
            {
                return Content("No found member in list");
            }
            return Content(string.Join("\n", listMaleMembers.Select(p => p.ToString())));
        }
        public IActionResult OldestMember()
        {
            var oldestMember = _personService.GetOldestMember();
            if (oldestMember == null)
            {
                return Content("No member found");
            }
            return Content(oldestMember.ToString());
        }
        public IActionResult MemberFullNames()
        {
            var fullNames = _personService.GetMemberFullNames();
            if (fullNames == null)
            {
                return Content("No member found");
            }
            return Content(string.Join("\n", fullNames));
        }
        public IActionResult FilterByBirthYear(int? year, string comparisonType)
        {
            if (!year.HasValue)
            {
                return Content("Year parameter is null or empty.");
            }

            if (string.IsNullOrEmpty(comparisonType))
            {
                return Content("Comparison type is null or empty.");
            }
            var validComparisonTypes = new HashSet<string> { "Equal", "Greater", "Less" };
            if (string.IsNullOrEmpty(comparisonType) || !validComparisonTypes.Contains(comparisonType))
            {
                return Content("Invalid query.");
            }
            var filteredMembers = _personService.FilterMembersByBirthYear(year.Value, comparisonType).ToList();

            if (filteredMembers == null || filteredMembers.Count == 0)
            {
                return Content("No members found.");
            }


            return Content(string.Join("\n", filteredMembers.Select(p => p.ToString())));
        }
        public IActionResult Download()
        {
            var file = _personService.GetMembersAsExcelFile();
            return File(file, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "members.xlsx");
        }
    }

}
