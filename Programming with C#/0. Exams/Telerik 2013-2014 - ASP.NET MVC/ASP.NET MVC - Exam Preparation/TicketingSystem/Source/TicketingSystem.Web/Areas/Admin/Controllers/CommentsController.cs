namespace TicketingSystem.Web.Areas.Admin.Controllers
{
    using System;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;
    using TicketingSystem.Data.Models;
    using TicketingSystem.Data.UnitOfWork;
    using TicketingSystem.Web.Areas.Admin.Controllers.Base;
    using TicketingSystem.Web.Services.Contracts;

    public class CommentsController : AdminController
    {
        private readonly ICommentsService commentsService;

        public CommentsController(ITicketingSystemData data, ICommentsService commentsService)
            : base(data)
        {
            this.commentsService = commentsService;
        }

        public ActionResult Index()
        {
            var comments = this.commentsService.GetAllComments();
            return this.View(comments.ToList());
        }
 
        public ActionResult Details(int? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            var comment = this.Data.Comments.Find(id);
            if (comment == null)
            {
                return this.HttpNotFound();
            }
        
            return this.View(comment);
        }

        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var comment = this.Data.Comments.Find(id);
            if (comment == null)
            {
                return this.HttpNotFound();
            }

            return this.View(comment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Comment comment)
        {
            if (this.ModelState.IsValid)
            {
                this.Data.Comments.Update(comment);
                this.Data.SaveChanges();

                return this.RedirectToAction("Index");
            }

            return this.View(comment);
        }

        public ActionResult Delete(int? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var comment = this.Data.Comments.Find(id);
            if (comment == null)
            {
                return this.HttpNotFound();
            }

            return this.View(comment);
        }

        [ValidateAntiForgeryToken]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            this.Data.Comments.Remove(id);
            this.Data.SaveChanges();
            return this.RedirectToAction("Index");
        }
    }
}