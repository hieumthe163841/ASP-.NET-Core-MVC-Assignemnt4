using Assignment4.Models;

namespace Assignment4.Domain.Contracts
{
    public interface IPersonRepository
    { 
        IEnumerable<Person> GetPeople();
    }
}
