namespace TicketingSystem.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using AutoMapper;
    using TicketingSystem.Data.Models;
    using TicketingSystem.Data.UnitOfWork;
    using TicketingSystem.Web.Controllers.Base;
    using TicketingSystem.Web.Infrastructure.Filters;
    using TicketingSystem.Web.ViewModels.Comments;

    public class CommentsController : BaseController
    {
        public CommentsController(ITicketingSystemData data)
            : base(data)
        {
        }

        [AjaxPost]
        [ValidateAntiForgeryToken]
        public ActionResult PostComment(PostCommentViewModel comment)
        {
            if (comment != null && this.ModelState.IsValid)
            {
                var dbComment = Mapper.Map<Comment>(comment);
                dbComment.AuthorId = this.CurrentUser.Id;

                var ticket = this.Data.Tickets.Find(comment.TicketId);
                if (ticket == null)
                {
                    throw new HttpException(404, "Ticket not found");
                }

                ticket.Comments.Add(dbComment);
                this.Data.SaveChanges();

                var viewModel = Mapper.Map<CommentViewModel>(dbComment);
                return this.PartialView("_CommentPartial", viewModel);
            }

            throw new HttpException(400, "Invalid comment");
        }
    }
}