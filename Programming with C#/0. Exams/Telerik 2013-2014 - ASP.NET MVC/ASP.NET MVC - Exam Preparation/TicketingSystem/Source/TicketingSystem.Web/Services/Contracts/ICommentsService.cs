namespace TicketingSystem.Web.Services.Contracts
{
    using System.Linq;
    using TicketingSystem.Data.Models;

    public interface ICommentsService
    {
        IQueryable<Comment> GetAllComments();
    }
}