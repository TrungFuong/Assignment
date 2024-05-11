using System.ComponentModel.DataAnnotations;

namespace Day1.Model
{
    public class Salaries
    {
        [Required]
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public decimal Salary { get; set; }
        public Employees Employee { get; set; }
    }
}
