using Day2.Models;
using Day2.WebApp.Models;
using System.Globalization;

namespace Day2.Extensions
{
    public static class PersonExtension
    {
        public static Person ToPerson(this PersonDTO personDTO, int id)
        {
            var dob = DateTime.ParseExact(personDTO.DateOfBirth, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None);
            return new Person
            {
                Id = id,
                FirstName = personDTO.FirstName,
                LastName = personDTO.LastName,
                Gender = personDTO.Gender,
                DateOfBirth = dob,
                BirthPlace = personDTO.BirthPlace
            };
        }
    }
}
