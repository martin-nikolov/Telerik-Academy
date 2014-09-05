namespace BookStore.Models.Projection
{
    using System;
    using System.Linq;

    public class ReviewProjection
    {
        public string Content { get; set; }

        public DateTime DateOfCreation { get; set; }

        public string[] AuthorName { get; set; }

        public string BookName { get; set; }
    }
}