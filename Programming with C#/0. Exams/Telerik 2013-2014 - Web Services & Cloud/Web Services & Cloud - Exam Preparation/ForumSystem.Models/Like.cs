namespace ForumSystem.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class Like
    {
        [Key]
        public int ID { get; set; }

        public string AuthorID { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public int ArticleID { get; set; }

        public virtual Article Article { get; set; }
    }
}