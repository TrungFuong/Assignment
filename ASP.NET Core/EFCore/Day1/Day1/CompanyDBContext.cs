using Day1.Model;
using Microsoft.EntityFrameworkCore;

namespace Day1
{
    public class CompanyDBContext : DbContext
    {
        public DbSet<Employees> Employees { get; set; }
        public DbSet<Departments> Departments { get; set; }
        public DbSet<Projects> Projects { get; set; }
        public DbSet<Salaries> Salaries { get; set; }
        public DbSet<ProjectEmployee> ProjectEmployees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employees>()
                .HasOne(e => e.Salary)
                .WithOne(s => s.Employee)
                .HasForeignKey<Salaries>(s => s.EmployeeId);

            modelBuilder.Entity<Departments>()
                .HasMany(d => d.Employees)
                .WithOne(e => e.Department)
                .HasForeignKey(e => e.DepartmentId);

            modelBuilder.Entity<ProjectEmployee>().HasKey(pe => new { pe.ProjectId, pe.EmployeeId });

            modelBuilder.Entity<Departments>().HasData(
                new Departments { Id = 1, Name = "Software Development" },
                new Departments { Id = 2, Name = "Finance" },
                new Departments { Id = 3, Name = "Accountant" },
                new Departments { Id = 4, Name = "HR" }
            );
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=EFCoreDay1;Trusted_Connection=True;");
        }
    }
}
