namespace ForumSystem.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;
    using ForumSystem.Data.Contracts;
    using ForumSystem.Data.UnitOfWork;
    using ForumSystem.Models;
    using ForumSystem.Web.Projections;

    public class CommentsController : BaseApiController
    {
        //public CommentsController()
        //    : base(new ForumSystemData())
        //{
        //}

        public CommentsController(IForumSystemData forumSystemData)
            : base(forumSystemData)
        {
        }

        [HttpPost]
        [Authorize]
        public IHttpActionResult Create(int id, CommentProjection commentProjection)
        {
            if (!this.ExistsArticle(id))
            {
                return this.BadRequest(string.Format("Article with id={0} does not exists!", id));
            }

            if (string.IsNullOrEmpty(commentProjection.Content))
            {
                return this.BadRequest("Invalid comment content!");
            }

            var userId = this.GetUserId();
            var comment = new Comment()
            {
                Content = commentProjection.Content,
                DateCreated = DateTime.Now,
                ArticleID = id,
                AuthorID = userId
            };

            this.ForumSystemData.Comments.Add(comment);
            this.ForumSystemData.SaveChanges();

            commentProjection.ID = comment.ID;
            commentProjection.ArticleId = id;
            commentProjection.AuthorName = this.GetUsername();

            return this.Ok(commentProjection);
        }

        private bool ExistsArticle(int id)
        {
            return this.ForumSystemData.Articles.Find(id) != null;
        }
    }
}