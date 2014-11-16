namespace TicketingSystem.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using TicketingSystem.Data.UnitOfWork;
    using TicketingSystem.Web.Controllers.Base;
    using TicketingSystem.Web.Services.Contracts;

    public class HomeController : BaseController
    {
        private const int NumberOfTicketsAtHomePage = 6;
        private const string MostCommentedTicketsPartialView = "_MostCommentedTicketsPartial";

        private readonly ITicketsService ticketsService;

        public HomeController(ITicketingSystemData data, ITicketsService ticketsService)
            : base(data)
        {
            this.ticketsService = ticketsService;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        [ChildActionOnly]
        [OutputCache(Duration = 60 * 60)]
        public ActionResult MostCommentedTickets()
        {
            var tickets = this.ticketsService.GetMostCommentedTickets(NumberOfTicketsAtHomePage);
            return this.PartialView(MostCommentedTicketsPartialView, tickets);
        }
    }
}