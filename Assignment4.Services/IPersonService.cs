using Assignment4.Models;
using System;

namespace Assignment4.Services
{
    public interface IPersonService
    {
        IEnumerable<Person> GetMaleMembers();
        Person GetOldestMember();
        IEnumerable<string> GetMemberFullNames();
        byte[] GetMembersAsExcelFile();
        IEnumerable<Person> FilterMembersByBirthYear(int year, string comparisonType);
        IEnumerable<Person> GetPeopleList();


     }
}
