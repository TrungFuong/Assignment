﻿namespace Day1.Model
{
    public class ProjectEmployee
    {
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public bool Enable { get; set; }
    }
}
