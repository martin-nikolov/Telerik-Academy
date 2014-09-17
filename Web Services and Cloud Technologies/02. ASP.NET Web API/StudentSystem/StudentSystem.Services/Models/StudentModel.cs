namespace StudentSystem.Services.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Linq.Expressions;
    using StudentSystem.Models;

    public class StudentModel
    {
        public static Expression<Func<Student, StudentModel>> FromStudent
        {
            get
            {
                return student => new StudentModel
                {
                    StudentId = student.StudentId,
                    Name = student.Name
                };
            }
        }

        [Key]
        public int StudentId { get; set; }

        [MinLength(5)]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}