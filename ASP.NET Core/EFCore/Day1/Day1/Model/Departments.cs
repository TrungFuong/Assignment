using Day1.Model;
using System.ComponentModel.DataAnnotations;

namespace Day1.Model
{
    public class Departments
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public IList<Employee> Employees { get; set; }

    }
}
