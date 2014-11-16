namespace TicketingSystem.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using TicketingSystem.Data.UnitOfWork;
    using TicketingSystem.Web.Controllers.Base;

    public class ErrorController : BaseController
    {
        public ErrorController(ITicketingSystemData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            return this.View("Error");
        }
    }
}