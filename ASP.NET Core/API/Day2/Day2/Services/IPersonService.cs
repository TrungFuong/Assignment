using Day2.Models;
using Day2.WebApp.Models;

namespace Day2.WebApp.Services
{
    public interface IPersonService
    {
        Person Create(PersonDTO person);
        bool Update(int id, PersonDTO person);
        bool Delete(int id);
        List<Person> GetAll();
        Person? GetById(int id);
    }
}
