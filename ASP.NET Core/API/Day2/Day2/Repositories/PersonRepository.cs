﻿using Day2.WebApp.Models;

namespace Day2.WebApp.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private List<Person> _people = new List<Person>();

        public void Create(Person person)
        {
            var people = GetAllPersonFromFile();
            people.Add(person);
        }

        public void Delete(int id)
        {
            _people.RemoveAll(p => p.Id == id);
        }

        public List<Person> GetAll()
        {
            return GetAllPersonFromFile();
        }

        public Person? GetById(int id)
        {
            var people = GetAllPersonFromFile();
            var currentPerson = _people.FirstOrDefault(p => p.Id == id);
            return currentPerson;
        }

        public void Update(int id, Person person)
        {
            var currentPerson = GetById(id);
            if (currentPerson != null)
            {
                currentPerson.FirstName = person.FirstName;
                currentPerson.LastName = person.LastName;
                currentPerson.Gender = person.Gender;
                currentPerson.DateOfBirth = person.DateOfBirth;
                currentPerson.BirthPlace = person.BirthPlace;
            }
        }
       
        private List<Person> GetAllPersonFromFile()
        {
            if (_people == null || !_people.Any())
            {
                string filePath = "Data\\MOCK_DATA.csv";
                string fileContent = "";

                using (var reader = new StreamReader(filePath))
                {
                    fileContent = reader.ReadToEnd();
                }

                _people = ParsePeople(fileContent);
            }
            return _people;
        }

        private List<Person> ParsePeople(string fileContent)
        {
            List<Person> people = new List<Person>();

            string[] lines = fileContent.Split('\n', StringSplitOptions.RemoveEmptyEntries);

            for (int i = 1; i < lines.Length; i++)
            {
                string[] values = lines[i].Split(',');

                Person person = new Person
                {
                    Id = i,
                    FirstName = values[0],
                    LastName = values[1],
                    Gender = (Gender)Enum.Parse(typeof(Gender), values[2]),
                    DateOfBirth = DateTime.Parse(values[3]),
                    BirthPlace = values[4],
                };

                people.Add(person);
            }

            return people;
        }
    }
}
