namespace ForumSystem.Web.Projections
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Linq.Expressions;
    using ForumSystem.Models;

    public class LikeProjection
    {
        public static Expression<Func<Like, LikeProjection>> FromLike
        {
            get
            {
                return like => new LikeProjection
                {
                    ID = like.ID,
                    AuthorName = like.Author.UserName
                };
            }
        }

        public int ID { get; set; }

        [Required]
        public string AuthorName { get; set; }
    }
}