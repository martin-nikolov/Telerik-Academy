namespace NewsSystem.Web.Models
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    public class CategoryProjection
    {
        public static Expression<Func<Category, CategoryProjection>> FromCategory
        {
            get
            {
                return category => new CategoryProjection
                {
                    CategoryId = category.CategoryId,
                    Name = category.Name,
                    Articles = category.Articles
                                       .AsQueryable()
                                       .Select(ArticleProjection.FromArticle)
                                       .OrderByDescending(a => a.DateCreated)
                                       .Take(3)
                };
            }
        }

        public int CategoryId { get; set; }

        public string Name { get; set; }

        public IQueryable<ArticleProjection> Articles { get; set; }
    }
}