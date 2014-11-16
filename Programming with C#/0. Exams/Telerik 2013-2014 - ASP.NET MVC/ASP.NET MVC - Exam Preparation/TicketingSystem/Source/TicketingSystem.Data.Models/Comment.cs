namespace TicketingSystem.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class Comment
    {
        [Key]
        public int CommentId { get; set; }

        [Required]
        [MinLength(100), MaxLength(4096)]
        public string Content { get; set; }

        public int TicketId { get; set; }

        public virtual Ticket Ticket { get; set; }

        [Required]
        public string AuthorId { get; set; }

        public virtual User Author { get; set; }
    }
}