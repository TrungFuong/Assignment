namespace Day1.Model
{
    public class ProjectEmployee
    {
        public int ProjectId { get; set; }
        public Projects Project { get; set; }
        public int EmployeeId { get; set; }
        public Employees Employee { get; set; }
        public bool Enable { get; set; }
    }
}
