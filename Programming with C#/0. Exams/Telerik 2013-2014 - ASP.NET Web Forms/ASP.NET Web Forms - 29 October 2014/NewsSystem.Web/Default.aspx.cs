namespace NewsSystem.Web
{
    using System;
    using System.Linq;
    using System.Web.UI;
    using NewsSystem.Web.Models;
    using NewsSystem.Web.Utility;

    public partial class _Default : Page
    {
        private ApplicationDbContext context = new ApplicationDbContext();

        public IQueryable<ArticleProjection> ListViewArticles_GetData()
        {
            var articles = this.context.Articles
                               .Select(ArticleProjection.FromArticle)
                               .OrderByDescending(a => a.LikesCount)
                               .Take(3);

            return this.NormalizeArticlesContent(articles);
        }

        public IQueryable<CategoryProjection> ListViewCategories_GetData()
        {
            return this.context.Categories
                       .Select(CategoryProjection.FromCategory)
                       .OrderBy(c => c.Name);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        private IQueryable<ArticleProjection> NormalizeArticlesContent(IQueryable<ArticleProjection> articles)
        {
            var articlesToList = articles.ToList();

            foreach (var article in articlesToList)
            {
                article.Content = article.Content.NormalizeText(300);
            }

            return articlesToList.AsQueryable();
        }
    }
}