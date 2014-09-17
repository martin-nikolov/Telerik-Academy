namespace StudentSystem.Data.Contracts
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using StudentSystem.Models;

    public interface IStudentSystemDbContext : IDbContext
    {
        IDbSet<Course> Courses { get; }

        IDbSet<Homework> Homeworks { get; }

        IDbSet<Material> Materials { get; }

        IDbSet<Student> Students { get; }
    }
}