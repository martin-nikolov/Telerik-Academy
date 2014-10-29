namespace NewsSystem.Web.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class Like
    {
        [Key]
        public int LikeId { get; set; }

        public bool Value { get; set; }

        public int ArticleId { get; set; }

        public Article Article { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }
    }
}