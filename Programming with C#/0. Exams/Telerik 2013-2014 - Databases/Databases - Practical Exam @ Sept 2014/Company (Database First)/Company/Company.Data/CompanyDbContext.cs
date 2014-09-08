namespace Company.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Company.Models;

    public class CompanyDbContext : DbContext
    {
        public CompanyDbContext()
            : base(ConnectionStrings.Default.CompanyConnectionString)
        {
            // Database.SetInitializer(new MigrateDatabaseToLatestVersion<CompanyDbContext, Configuration>());
        }

        public IDbSet<Department> Departments { get; set; }

        public IDbSet<Employee> Employees { get; set; }

        public IDbSet<Project> Projects { get; set; }

        public IDbSet<Report> Reports { get; set; }

        public IDbSet<EmployeeProject> EmployeeProjects { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                        .Property(i => i.YearSalary)
                        .HasColumnType("money");

            modelBuilder.Entity<EmployeeProject>().HasKey(a => new { a.EmployeeId, a.ProjectId });
        }
    }
}