using Assignment4.Domain;
using Assignment4.Domain.Enums;

namespace Assignment4.Models
{
    public class Person : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public GenderType Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string BirthPlace { get; set; }
        public bool IsGraduated { get; set; }

        public int Age => DateTime.Now.Year - DateOfBirth.Year;
        public override string ToString()
        {
            return $"{FirstName} {LastName} | {Gender} | {DateOfBirth} | {PhoneNumber} | {BirthPlace} | {IsGraduated}";
        }
    }
}
