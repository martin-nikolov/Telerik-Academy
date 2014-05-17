namespace StudentSystem.Models
{
    using System;
    using System.Linq;

    public class Material
    {
        public int MaterialId { get; set; }

        public string DownloadUrl { get; set; }

        public virtual MaterialType Type { get; set; }

        public int HomeworkId { get; set; }

        public virtual Homework Homework { get; set; }
    }
}