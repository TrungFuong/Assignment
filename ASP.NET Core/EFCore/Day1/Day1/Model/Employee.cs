using Day1.Model;
using System.ComponentModel.DataAnnotations;

public class Employee
{
    [Required]
    public int Id { get; set; }
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
    public int DepartmentId { get; set; }
    public DateTime JoinedDate { get; set; }
    public Salarie Salary { get; set; }
    public Departments Department { get; set; }
    public IList<ProjectEmployee> ProjectEmployees { get; set; }
}
