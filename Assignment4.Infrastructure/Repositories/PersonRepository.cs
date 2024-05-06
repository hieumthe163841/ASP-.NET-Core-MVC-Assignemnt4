using Assignment4.Domain.Contracts;
using Assignment4.Domain.Enums;
using Assignment4.Models;
using ClosedXML.Excel;

namespace Assignment4.Infrastructure.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        public IEnumerable<Person> GetPeople()
        {

            var people = new List<Person>
            {
                 new Person
                {
                FirstName = "Mai Trong",
                LastName = "Hieu",
                Gender = GenderType.Male,
                DateOfBirth = new DateTime(2002, 04, 02),
                PhoneNumber = "0943317918",
                BirthPlace = "Ha Tinh",
                IsGraduated = false
                },
                new Person
                {
                FirstName = "Truong Trong",
                LastName = "Hoa",
                Gender = GenderType.Male,
                DateOfBirth = new DateTime(2002, 05, 12),
                PhoneNumber = "0941829321",
                BirthPlace = "Thanh Hoa",
                IsGraduated = false
                },
                new Person
                {
                FirstName = "Nguyen Minh",
                LastName = "Anh",
                Gender = GenderType.Female,
                DateOfBirth = new DateTime(2001,09,12),
                PhoneNumber = "0941234921",
                BirthPlace = "Ha Noi",
                IsGraduated = true
                },
                new Person
                {
                     FirstName = "Hoang Nhat",
                LastName = "Minh",
                Gender = GenderType.Male,
                DateOfBirth = new DateTime(2002, 06, 12),
                PhoneNumber = "0943334921",
                BirthPlace = "Ha Nam",
                IsGraduated = false
                },
                new Person
                {
                FirstName = "La Thien",
                LastName = "Vu",
                Gender = GenderType.Male,
                DateOfBirth = new DateTime(2000, 07, 13),
                PhoneNumber = "0943334123",
                BirthPlace = "Ha Noi",
                IsGraduated = true
                },
                new Person
                {
                FirstName = "Nguyen Ngoc",
                LastName = "Quang",
                Gender = GenderType.Male,
                DateOfBirth = new DateTime(1999, 08, 12),
                PhoneNumber = "0941134921",
                BirthPlace = "Nghe An",
                IsGraduated = true
                },
                new Person
                {
                FirstName = "Le Viet",
                LastName = "Hoang",
                Gender = GenderType.Female,
                DateOfBirth = new DateTime(2003, 09, 22),
                PhoneNumber = "0943345921",
                BirthPlace = "Ha Giang",
                IsGraduated = false
                }
            };
            return people;
        }
    }
}
