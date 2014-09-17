namespace StudentSystem.Services.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Linq.Expressions;
    using StudentSystem.Models;

    public class CourseModel
    {
        public static Expression<Func<Course, CourseModel>> FromCourse
        {
            get
            {
                return course => new CourseModel
                {
                    CourseId = course.CourseId,
                    Description = course.Description
                };
            }
        }

        [Key]
        public int CourseId { get; set; }

        [Required]
        public string Description { get; set; }
    }
}