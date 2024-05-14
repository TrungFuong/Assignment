using Day1.Model;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace Day1
{
    public class CompanyDBContext : DbContext
    {
        public CompanyDBContext(DbContextOptions<CompanyDBContext> dbContextOptions) : base(dbContextOptions) { }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Departments> Departments { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Salaries> Salaries { get; set; }
        public DbSet<ProjectEmployee> ProjectEmployees { get; set; }
        //public DbSet<EmployeeSQL> EmployeeSQL { get; set; }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Salary)
                .WithOne(s => s.Employee)
                .HasForeignKey<Salaries>(s => s.EmployeeId);

            modelBuilder.Entity<Departments>()
                .HasMany(d => d.Employees)
                .WithOne(e => e.Department)
                .HasForeignKey(e => e.DepartmentId);

            modelBuilder.Entity<ProjectEmployee>().HasKey(pe => new { pe.ProjectId, pe.EmployeeId });

            modelBuilder.Entity<ProjectEmployee>()
                .HasOne(pe => pe.Project)
                .WithMany(p => p.ProjectEmployees)
                .HasForeignKey(pe => pe.ProjectId);

            modelBuilder.Entity<ProjectEmployee>()
                .HasOne(pe => pe.Employee)
                .WithMany(e => e.ProjectEmployees)
                .HasForeignKey(pe => pe.EmployeeId);

            modelBuilder.Entity<Departments>().HasData(
                new Departments { Id = 1, Name = "Software Development" },
                new Departments { Id = 2, Name = "Finance" },
                new Departments { Id = 3, Name = "Accountant" },
                new Departments { Id = 4, Name = "HR" }
            );

            modelBuilder.Entity<Project>().HasData(
                new Project { Id = 1, Name = "Project 1" },
                new Project { Id = 2, Name = "Project 2" },
                new Project { Id = 3, Name = "Project 3" },
                new Project { Id = 4, Name = "Project 4" }
                );

            modelBuilder.Entity<Employee>().HasData(
                new Employee { Id = 1, Name = "John Doe", DepartmentId = 1, JoinedDate = DateTime.Now },
                new Employee { Id = 2, Name = "Jane Doe", DepartmentId = 2, JoinedDate = DateTime.Now },
                new Employee { Id = 3, Name = "Alice", DepartmentId = 1, JoinedDate = DateTime.Now },
                new Employee { Id = 4, Name = "Bob", DepartmentId = 3, JoinedDate = DateTime.Now },
                new Employee { Id = 5, Name = "Charlie", DepartmentId = 2, JoinedDate = DateTime.Now },
                new Employee { Id = 6, Name = "David", DepartmentId = 1, JoinedDate = DateTime.Now },
                new Employee { Id = 7, Name = "Eve", DepartmentId = 4, JoinedDate = DateTime.Now },
                new Employee { Id = 8, Name = "Frank", DepartmentId = 3, JoinedDate = DateTime.Now },
                new Employee { Id = 9, Name = "Grace", DepartmentId = 2, JoinedDate = DateTime.Now },
                new Employee { Id = 10, Name = "Helen", DepartmentId = 4, JoinedDate = DateTime.Now }
            );

            modelBuilder.Entity<ProjectEmployee>().HasData(
                new ProjectEmployee { EmployeeId = 1, ProjectId = 1, Enable = true },
                new ProjectEmployee { EmployeeId = 2, ProjectId = 4, Enable = true },
                new ProjectEmployee { EmployeeId = 3, ProjectId = 2, Enable = true },
                new ProjectEmployee { EmployeeId = 4, ProjectId = 1, Enable = true },
                new ProjectEmployee { EmployeeId = 5, ProjectId = 3, Enable = true },
                new ProjectEmployee { EmployeeId = 6, ProjectId = 3, Enable = true },
                new ProjectEmployee { EmployeeId = 7, ProjectId = 4, Enable = true },
                new ProjectEmployee { EmployeeId = 8, ProjectId = 1, Enable = true },
                new ProjectEmployee { EmployeeId = 9, ProjectId = 2, Enable = true },
                new ProjectEmployee { EmployeeId = 10, ProjectId = 4, Enable = true }
            );
            modelBuilder.Entity<Salaries>().HasData(
                new Salaries { Id = 1, EmployeeId = 1, Salary = 50 },
                new Salaries { Id = 2, EmployeeId = 2, Salary = 160 },
                new Salaries { Id = 3, EmployeeId = 3, Salary = 70 },
                new Salaries { Id = 4, EmployeeId = 4, Salary = 80 },
                new Salaries { Id = 5, EmployeeId = 5, Salary = 140 },
                new Salaries { Id = 6, EmployeeId = 6, Salary = 100 },
                new Salaries { Id = 7, EmployeeId = 7, Salary = 110 },
                new Salaries { Id = 8, EmployeeId = 8, Salary = 120 },
                new Salaries { Id = 9, EmployeeId = 9, Salary = 130 },
                new Salaries { Id = 10, EmployeeId = 10, Salary = 140 });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=TRUNGFUONG;Initial Catalog=Company;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
    }
}