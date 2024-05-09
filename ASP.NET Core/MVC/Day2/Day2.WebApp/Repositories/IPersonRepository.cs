using Day2.WebApp.Models;

namespace Day2.WebApp.Repositories
{
    public interface IPersonRepository
    {
        void Create(Person person);
        void Update(int id, Person person);
        void Delete(int id);
        List<Person> GetAll();
        Person GetById(int id);
    }
}
