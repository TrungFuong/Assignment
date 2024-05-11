using Day2.Extensions;
using Day2.Models;
using Day2.WebApp.Models;
using Day2.WebApp.Repositories;

namespace Day2.WebApp.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public Person Create(PersonDTO personDTO)
        {
            var person = personDTO.ToPerson(_personRepository.GetAll().Count + 1);
            _personRepository.Create(person);
            return person;
        }

        public bool Delete(int id)
        {
            var currentPerson = GetById(id);
            if (currentPerson != null)
            {
                _personRepository.Delete(id);
                return true;
            }
            return false;
        }

        public List<Person> GetAll()
        {
            return _personRepository.GetAll();
        }

        public Person? GetById(int id)
        {
            return _personRepository.GetById(id);
        }

        public bool Update(int id, PersonDTO personDTO)
        {
            var currentPerson = GetById(id);
            if (currentPerson != null)
            {
                var person = personDTO.ToPerson(id);
                _personRepository.Update(id, person);
                return true;
            }
            return false;
        }
    }
}
