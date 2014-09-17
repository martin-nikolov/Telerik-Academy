namespace StudentSystem.Data.Contracts
{
    using System;
    using System.Linq;
    using StudentSystem.Models;

    public interface IStudentSystemData : IDisposable
    {
        IGenericRepository<Course> Courses { get; }

        IGenericRepository<Homework> Homeworks { get; }

        IGenericRepository<Material> Materials { get; }

        IGenericRepository<Student> Students { get; }

        int SaveChanges();
    }
}