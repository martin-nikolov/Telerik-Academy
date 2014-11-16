namespace TicketingSystem.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return this.View();
        }
    }
}