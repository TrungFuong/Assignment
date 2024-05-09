namespace Day2.WebApp.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string? PhoneNumber { get; set; }
        public string? BirthPlace { get; set; }
        public bool IsGraduated{ get; set; }
    }
}
