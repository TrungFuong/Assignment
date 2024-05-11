using Day2.WebApp.Models;

namespace Day2.Models
{
    public class PersonDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }    
        public Gender Gender { get; set; }
        public string DateOfBirth { get; set; }
        public string? BirthPlace { get; set; }
    }
}
