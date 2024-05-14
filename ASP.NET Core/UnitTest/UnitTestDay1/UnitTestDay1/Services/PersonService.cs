using UnitTestDay1.WebApp.Models;
using UnitTestDay1.WebApp.Repositories;

namespace UnitTestDay1.WebApp.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        public PersonService(IPersonRepository personRepository) {
            _personRepository = personRepository;
        }

        public void Create(Person person)
        {
            person.Id = _personRepository.GetAll().Count + 1;
            _personRepository.Create(person);
        }

        public void Delete(int id)
        {
            _personRepository.Delete(id);
        }

        public List<Person> GetAll()
        {
            return _personRepository.GetAll();
        }

        public Person GetById(int id)
        {
            return _personRepository.GetById(id);
        }

        public void Update(int id, Person person)
        {
            _personRepository.Update(id, person);
        }
    }
}
