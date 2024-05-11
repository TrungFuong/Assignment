using Day1.Model;
using System.ComponentModel.DataAnnotations;

public class Employees
{
    [Required]
    public int Id { get; set; }
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
    public int DepartmentId { get; set; }
    public DateTime JoinedDate { get; set; }
    public Salaries Salary { get; set; }
    public IList<Projects> Projects { get; set; }
    public Departments Department { get; set; }
    public IList<ProjectEmployee> ProjectEmployees { get; set; }
}
