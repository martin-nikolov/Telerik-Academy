namespace ForumSystem.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class Vote
    {
        [Key]
        public int Id { get; set; }

        // Like -> +1 / Dislike -> -1 / Neutral -> 0
        public int Value { get; set; }

        [Required]
        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public int PostId { get; set; }

        public virtual Post Post { get; set; }
    }
}