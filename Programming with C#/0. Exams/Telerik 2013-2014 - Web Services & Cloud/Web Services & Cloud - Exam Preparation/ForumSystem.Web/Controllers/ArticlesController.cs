namespace ForumSystem.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;
    using ForumSystem.Data.Contracts;
    using ForumSystem.Data.UnitOfWork;
    using ForumSystem.Models;
    using ForumSystem.Web.Projections;

    public class ArticlesController : BaseApiController
    {
        private const int DefaultPageSize = 10;

        //public ArticlesController()
        //    : base(new ForumSystemData())
        //{
        //}

        public ArticlesController(IForumSystemData forumSystemData)
            : base(forumSystemData)
        {
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            var articles = this.ForumSystemData.Articles
                               .All()
                               .OrderBy(a => a.DateCreated)
                               .Select(ArticleProjection.FromArticle)
                               .Take(DefaultPageSize);

            return this.Ok(articles);
        }

        [HttpGet]
        public IQueryable<ArticleProjection> Get(int? page)
        {
            return this.Get(string.Empty, page);
        }

        [HttpGet]
        [Authorize]
        public IHttpActionResult Get(int id)
        {
            var article = this.GetArticleById(id);
            if (article == null)
            {
                return this.ReturnBadRequestIfNull(id);
            }

            return this.Ok(article);
        }

        [HttpGet]
        [Authorize]
        public IQueryable<ArticleProjection> Get(string category)
        {
            return this.Get(category, 0);
        }
 
        [HttpGet]
        [Authorize]
        public IQueryable<ArticleProjection> Get(string category, int? page)
        {
            var articles = this.ForumSystemData.Articles.All();

            if (!string.IsNullOrEmpty(category))
            {
                articles = articles.Where(a => a.Category.Name == category);
            }

            articles = articles.OrderBy(a => a.DateCreated);

            if (page.HasValue)
            {
                articles = articles.Skip(page.Value * DefaultPageSize);
            }

            return articles.Select(ArticleProjection.FromArticle)
                           .Take(DefaultPageSize);
        }

        [HttpPost]
        [Authorize]
        public IHttpActionResult Create(ArticleProjection articleProjection)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest("Invalid article!");
            }

            var tags = this.GetTags(articleProjection);
            var categoryId = this.GetCategoryId(articleProjection.Category);
            var article = new Article()
            {
                Title = articleProjection.Title,
                Content = articleProjection.Content,
                DateCreated = DateTime.Now,
                CategoryID = categoryId,
                Tags = tags,
                AuthorID = this.GetUserId()
            };

            this.ForumSystemData.Articles.Add(article);
            this.ForumSystemData.SaveChanges();

            articleProjection.ID = article.ID;
            articleProjection.DateCreated = article.DateCreated;
            articleProjection.Tags = article.Tags.AsQueryable().Select(TagProjection.FromTag).ToList();

            return this.Ok(articleProjection);
        }

        [HttpPost]
        [Authorize]
        public IHttpActionResult PostComment(int id)
        {
            var article = this.GetArticleById(id);
            if (article == null)
            {
                return this.ReturnBadRequestIfNull(id);
            }

            return this.Ok();
        }

        private ArticleDetails GetArticleById(int id)
        {
            var article = this.ForumSystemData.Articles
                              .All()
                              .Select(ArticleDetails.FromArticle)
                              .FirstOrDefault(a => a.ID == id);
            return article;
        }

        private int GetCategoryId(string categoryName)
        {
            var category = this.ForumSystemData.Categories
                               .All()
                               .FirstOrDefault(c => c.Name == categoryName);

            if (category == null)
            {
                category = new Category()
                {
                    Name = categoryName
                };

                this.ForumSystemData.Categories.Add(category);
                this.ForumSystemData.SaveChanges();
            }

            return category.ID;
        }

        private ICollection<Tag> GetTags(ArticleProjection article)
        {
            var allTags = new HashSet<string>();
            allTags.UnionWith(article.Tags.Select(t => t.Name));
            allTags.UnionWith(article.Title.Split(' '));

            var tags = new HashSet<Tag>();

            foreach (var tagName in allTags)
            {
                var tag = this.ForumSystemData.Tags
                              .All()
                              .Where(t => t.Name == tagName)
                              .FirstOrDefault();
                
                if (tag == null)
                {
                    tag = new Tag()
                    {
                        Name = tagName
                    };

                    this.ForumSystemData.Tags.Add(tag);
                    this.ForumSystemData.SaveChanges();
                }

                tags.Add(tag);
            }

            return tags;
        }

        private IHttpActionResult ReturnBadRequestIfNull(int id)
        {
            return this.BadRequest(string.Format("Article with id={0} does not exists!", id));
        }
    }
}