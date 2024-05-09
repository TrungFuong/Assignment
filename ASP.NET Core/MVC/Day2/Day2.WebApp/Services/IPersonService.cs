using Day2.WebApp.Models;

namespace Day2.WebApp.Services
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
