namespace StudentSystem.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using StudentSystem.Data.Migrations;
    using StudentSystem.Models;

    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext()
            : base(ConnectionStrings.Default.DatabaseConnectionString)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentSystemContext, Configuration>());
        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Homework> Homeworks { get; set; }

        public DbSet<Material> Materials { get; set; }
    }
}