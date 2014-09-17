namespace StudentSystem.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using StudentSystem.Common;
    using StudentSystem.Data.Contracts;
    using StudentSystem.Data.Migrations;
    using StudentSystem.Models;

    public class StudentSystemContext : DbContext, IStudentSystemDbContext
    {
        public StudentSystemContext()
            : base(ConnectionStrings.StudentSystemConnectionString)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentSystemContext, Configuration>());
        }

        public IDbSet<Student> Students { get; set; }

        public IDbSet<Course> Courses { get; set; }

        public IDbSet<Homework> Homeworks { get; set; }

        public IDbSet<Material> Materials { get; set; }

        public IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public void SaveChanges()
        {
            this.SaveChanges();
        }
    }
}