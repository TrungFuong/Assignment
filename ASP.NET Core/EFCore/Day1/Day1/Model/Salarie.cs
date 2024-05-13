using System.ComponentModel.DataAnnotations;

namespace Day1.Model
{
    public class Salarie
    {
        [Required]
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int Salary { get; set; }
        public Employee Employee { get; set; }
    }
}
