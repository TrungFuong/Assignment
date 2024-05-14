using UnitTestDay1.WebApp.Models;

namespace UnitTestDay1.WebApp.Services
{
    public interface IPersonService
    {
        void Create(Person person);
        void Update(int id, Person person);
        void Delete(int id);
        List<Person> GetAll();
        Person GetById(int id);
    }
}
