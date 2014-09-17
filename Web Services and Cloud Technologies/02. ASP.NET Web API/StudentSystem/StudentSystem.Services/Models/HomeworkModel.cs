namespace StudentSystem.Services.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Linq.Expressions;
    using StudentSystem.Models;

    public class HomeworkModel
    {
        public static Expression<Func<Homework, HomeworkModel>> FromHomework
        {
            get
            {
                return homework => new HomeworkModel
                {
                    HomeworkId = homework.HomeworkId,
                    CourseId = homework.CourseId,
                    StudentId = homework.StudentId,
                    TimeSent = homework.TimeSent,
                    Content = homework.Content
                };
            }
        }

        [Key]
        public int HomeworkId { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime? TimeSent { get; set; }

        public int CourseId { get; set; }

        public int? StudentId { get; set; }
    }
}