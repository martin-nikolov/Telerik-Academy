namespace NewsSystem.Web
{
    using System;
    using System.Linq;
    using System.Web.UI;
    using NewsSystem.Web.Controls;
    using NewsSystem.Web.Infrastructure;
    using NewsSystem.Web.Models;

    public partial class ViewArticle : Page
    {
        private ApplicationDbContext context = new ApplicationDbContext();
        private IUserIdProvider userIdProvider = new AspNetUserIdProvider();

        public ArticleProjection FormViewArticleDetails_GetItem()
        {
            int articleIdAsInteger = 0;
            var queryParam = this.Request.Params["articleId"];
            if (string.IsNullOrEmpty(queryParam) || !int.TryParse(queryParam, out articleIdAsInteger))
            {
                this.Response.Redirect("/");
            }
       
            var article = this.context.Articles
                              .Select(ArticleProjection.FromArticle)
                              .FirstOrDefault(a => a.ArticleId == articleIdAsInteger);

            if (article == null)
            {
                this.Response.Redirect("/");
            }

            return article;
        }

        protected int GetLikesValue(ArticleProjection item)
        {
            var article = this.context.Articles.Find(item.ArticleId);
            int likesCount = article.Likes.Count(l => l.Value == true);
            int hatesCount = article.Likes.Count(l => l.Value == false);
            return likesCount - hatesCount;
        }

        protected bool? GetUserVote(ArticleProjection item)
        {
            var article = this.context.Articles.Find(item.ArticleId);
            string userId = this.userIdProvider.GetUserId();
            var like = article.Likes.FirstOrDefault(l => l.UserId == userId);
            if (like == null)
            {
                return null;
            }

            return like.Value;
        }

        protected void LikeControl_Like(object sender, LikeEventArgs e)
        {
            var article = this.context.Articles.Find(Convert.ToInt32(e.DataID));
            string userId = this.userIdProvider.GetUserId();

            var like = article.Likes.FirstOrDefault(l => l.UserId == userId);
            if (like == null)
            {
                like = new Like()
                {
                    UserId = userId,
                    ArticleId = Convert.ToInt32(e.DataID)
                };

                article.Likes.Add(like);
            }

            like.Value = e.LikeValue;
            this.context.SaveChanges();

            this.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            var userId = this.userIdProvider.GetUserId();
            if (userId == null)
            {
                var likeControlContainer = this.FormViewArticleDetails.FindControl("LikeControlContainer");
                likeControlContainer.Visible = false;
            }
        }
    }
}