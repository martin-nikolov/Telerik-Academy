namespace TicketingSystem.Web.Services.Contracts
{
    using System.Collections.Generic;
    using System.Linq;
    using TicketingSystem.Web.ViewModels.Comments;
    using TicketingSystem.Web.ViewModels.Home;
    using TicketingSystem.Web.ViewModels.Tickets;

    public interface ITicketsService
    {
        IList<TicketViewModel> GetMostCommentedTickets(int numberOfTicketsToTake);

        TicketDetailsViewModel GetTicketById(int id);

        IEnumerable<CommentViewModel> GetTicketCommentsById(int id);

        IQueryable<ListTicketViewModel> GetTicketsByCategoryId(int? category);
    }
}