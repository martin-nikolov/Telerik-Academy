namespace TicketingSystem.Web.Services
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using TicketingSystem.Data.Models;
    using TicketingSystem.Data.UnitOfWork;
    using TicketingSystem.Web.Services.Base;
    using TicketingSystem.Web.Services.Contracts;

    public class CommentsService : BaseService, ICommentsService
    {
        public CommentsService(ITicketingSystemData data)
            : base(data)
        {
        }

        public IQueryable<Comment> GetAllComments()
        {
            var comments = this.Data.Comments.All()
                               .Include(c => c.Author)
                               .Include(c => c.Ticket);
            return comments;
        }


    }
}