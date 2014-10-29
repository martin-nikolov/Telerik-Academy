namespace NewsSystem.Web.Auth
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.UI;
    using Error_Handler_Control;
    using NewsSystem.Web.Infrastructure;
    using NewsSystem.Web.Models;

    public partial class EditArticles : Page
    {
        private ApplicationDbContext context = new ApplicationDbContext();
        private IUserIdProvider userIdProvider = new AspNetUserIdProvider();

        public IQueryable<ArticleProjection> ListViewArticles_GetData()
        {
            return this.context.Articles
                       .Select(ArticleProjection.FromArticle)
                       .OrderBy(a => a.ArticleId);
        }

        public void ListViewArticles_DeleteItem(int articleId)
        {
            var article = this.context.Articles.Find(articleId);
            this.context.Articles.Remove(article);
            this.TryUpdateOrShowMessage(new NotificationMessage()
            {
                Text = "Article was deleted successfully.",
                AutoHide = false,
                Type = MessageType.Success
            });
        }

        public void ListViewArticles_UpdateItem(int articleId)
        {
            var article = this.context.Articles.Find(articleId);
            if (article == null)
            {
                this.ModelState.AddModelError("", String.Format("Item with id {0} was not found", articleId));
                return;
            }

            this.TryUpdateModel(article);

            if (this.ModelState.IsValid)
            {
                this.TryUpdateOrShowMessage(new NotificationMessage()
                {
                    Text = "Article was updated successfully.",
                    AutoHide = false,
                    Type = MessageType.Success
                });
            }
        }

        public void ListViewArticles_InsertItem()
        {
            var articleProjection = new ArticleProjection();
            this.TryUpdateModel(articleProjection);
            var categoryId = int.Parse(articleProjection.CategoryName);

            if (string.IsNullOrEmpty(articleProjection.Title) || string.IsNullOrEmpty(articleProjection.Content))
            {
                ErrorSuccessNotifier.AddMessage(new NotificationMessage()
                {
                    Text = "Cannot create article with emptry title/content.",
                    AutoHide = false,
                    Type = MessageType.Warning
                });

                return;
            }

            var article = new Article()
            {
                Title = articleProjection.Title,
                Content = articleProjection.Content,
                AuthorId = this.userIdProvider.GetUserId(),
                DateCreated = DateTime.Now,
                CategoryId = categoryId
            };

            if (this.ModelState.IsValid)
            {
                this.context.Articles.Add(article);
                this.TryUpdateOrShowMessage(new NotificationMessage()
                {
                    Text = "Article was created successfully.",
                    AutoHide = false,
                    Type = MessageType.Success
                });
            }
        }

        public List<Category> GetCategoryNames()
        {
            return this.context.Categories.ToList();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        private void TryUpdateOrShowMessage(NotificationMessage msg)
        {
            try
            {
                this.context.SaveChanges();
                ErrorSuccessNotifier.AddMessage(msg);
            }
            catch (Exception)
            {
                ErrorSuccessNotifier.AddMessage(new NotificationMessage()
                {
                    Text = "Unhandled exception: something bad happened.",
                    AutoHide = false,
                    Type = MessageType.Error
                });
            }
        }
    }
}