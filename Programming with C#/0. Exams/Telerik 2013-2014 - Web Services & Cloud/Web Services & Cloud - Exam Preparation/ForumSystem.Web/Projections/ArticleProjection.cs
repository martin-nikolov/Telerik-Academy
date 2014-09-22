namespace ForumSystem.Web.Projections
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Web.Mvc;
    using ForumSystem.Models;

    public class ArticleProjection
    {
        public static Expression<Func<Article, ArticleProjection>> FromArticle
        {
            get
            {
                return article => new ArticleProjection
                {
                    ID = article.ID,
                    Title = article.Title,
                    Content = article.Content,
                    Category = article.Category.Name,
                    DateCreated = article.DateCreated,
                    Tags = article.Tags.AsQueryable().Select(TagProjection.FromTag).ToList()
                };
            }
        }

        public int ID { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [AllowHtml]
        public string Content { get; set; }

        [Required]
        public string Category { get; set; }

        public DateTime DateCreated { get; set; }

        public ICollection<TagProjection> Tags { get; set; }
    }
}