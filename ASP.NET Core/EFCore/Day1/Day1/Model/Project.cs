using Day1.Model;
using System.ComponentModel.DataAnnotations;

public class Project
{
    [Required]
    public int Id { get; set; }
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
    public IList<ProjectEmployee> ProjectEmployees { get; set; }
}
