namespace ForumSystem.Web.Projections
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Linq.Expressions;
    using ForumSystem.Models;

    public class CommentProjection
    {
        public static Expression<Func<Comment, CommentProjection>> FromComment
        {
            get
            {
                return comment => new CommentProjection
                {
                    ID = comment.ID,
                    Content = comment.Content,
                    DateCreated = comment.DateCreated,
                    AuthorName = comment.Author.UserName,
                    ArticleId = comment.ArticleID
                };
            }
        }

        public int ID { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime DateCreated { get; set; }

        public int ArticleId { get; set; }

        public string AuthorName { get; set; }
    }
}