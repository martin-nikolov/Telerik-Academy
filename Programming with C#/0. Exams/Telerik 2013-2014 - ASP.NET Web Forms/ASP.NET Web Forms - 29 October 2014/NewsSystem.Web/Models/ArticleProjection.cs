namespace NewsSystem.Web.Models
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    public class ArticleProjection
    {
        public static Expression<Func<Article, ArticleProjection>> FromArticle
        {
            get
            {
                return article => new ArticleProjection
                {
                    ArticleId = article.ArticleId,
                    Title = article.Title,
                    Content = article.Content,
                    AuthorName = article.Author.UserName,
                    CategoryName = article.Category.Name,
                    LikesCount = article.Likes.Count(),
                    DateCreated = article.DateCreated
                };
            }
        }

        public int ArticleId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string AuthorName { get; set; }

        public string CategoryName { get; set; }

        public int LikesCount { get; set; }

        public DateTime DateCreated { get; set; }
    }
}