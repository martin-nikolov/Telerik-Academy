namespace StudentSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Homework
    {
        public Homework()
        {
            this.Materials = new HashSet<Material>();
        }

        public int HomeworkId { get; set; }

        public string Content { get; set; }

        public DateTime? TimeSent { get; set; }

        public virtual ICollection<Material> Materials { get; set; }

        public int CourseId { get; set; }

        public virtual Course Course { get; set; }

        public int? StudentId { get; set; }

        public virtual Student Student { get; set; }
    }
}