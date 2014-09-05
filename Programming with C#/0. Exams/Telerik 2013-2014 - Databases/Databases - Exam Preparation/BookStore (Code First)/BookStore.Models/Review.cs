namespace BookStore.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class Review
    {
        [Key]
        public int ReviewId { get; set; }

        public string Content { get; set; }

        public DateTime DateOfCreation { get; set; }

        public int? AuthorId { get; set; }

        public virtual Author Author { get; set; }

        public int BookId { get; set; }

        public virtual Book Book { get; set; }
    }
}