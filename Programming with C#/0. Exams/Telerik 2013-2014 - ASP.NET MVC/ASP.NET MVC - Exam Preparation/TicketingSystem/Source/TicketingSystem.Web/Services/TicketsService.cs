namespace TicketingSystem.Web.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper.QueryableExtensions;
    using TicketingSystem.Data.UnitOfWork;
    using TicketingSystem.Web.Services.Base;
    using TicketingSystem.Web.Services.Contracts;
    using TicketingSystem.Web.ViewModels.Comments;
    using TicketingSystem.Web.ViewModels.Home;
    using TicketingSystem.Web.ViewModels.Tickets;

    public class TicketsService : BaseService, ITicketsService
    {
        public TicketsService(ITicketingSystemData data)
            : base(data)
        {
        }

        public IList<TicketViewModel> GetMostCommentedTickets(int numberOfTicketsToTake)
        {
            var tickets = this.Data.Tickets.All()
                              .OrderByDescending(t => t.Comments.Count())
                              .Take(numberOfTicketsToTake)
                              .Project()
                              .To<TicketViewModel>()
                              .ToList();
            return tickets;
        }

        public TicketDetailsViewModel GetTicketById(int id)
        {
            var ticket = this.Data.Tickets.All()
                             .Where(t => t.TicketId == id)
                             .Project()
                             .To<TicketDetailsViewModel>()
                             .FirstOrDefault();
            return ticket;
        }

        public IEnumerable<CommentViewModel> GetTicketCommentsById(int id)
        {
            var comments = this.Data.Comments.All()
                               .Where(c => c.TicketId == id)
                               .Project()
                               .To<CommentViewModel>()
                               .ToList();
            return comments;
        }

        public IQueryable<ListTicketViewModel> GetTicketsByCategoryId(int? category)
        {
            var ticketsQuery = this.Data.Tickets.All();

            if (category.HasValue)
            {
                ticketsQuery = ticketsQuery.Where(t => t.CategoryId == category.Value);
            }

            var tickets = ticketsQuery.Project()
                                      .To<ListTicketViewModel>();
            return tickets;
        }
    }
}