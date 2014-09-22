namespace ForumSystem.Web.Projections
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using ForumSystem.Models;

    public class ArticleDetails : ArticleProjection
    {
        private const int CommentsToTake = 10;

        public static Expression<Func<Article, ArticleDetails>> FromArticle
        {
            get
            {
                return article => new ArticleDetails
                {
                    ID = article.ID,
                    Title = article.Title,
                    Content = article.Content,
                    Category = article.Category.Name,
                    DateCreated = article.DateCreated,
                    Tags = article.Tags.AsQueryable().Select(TagProjection.FromTag).ToList(),
                    Comments = article.Comments.AsQueryable().Select(CommentProjection.FromComment).OrderBy(c => c.DateCreated).Take(CommentsToTake).ToList(),
                    Likes = article.Likes.AsQueryable().Select(LikeProjection.FromLike).ToList()
                };
            }
        }

        public ICollection<CommentProjection> Comments { get; set; }

        public ICollection<LikeProjection> Likes { get; set; }
    }
}