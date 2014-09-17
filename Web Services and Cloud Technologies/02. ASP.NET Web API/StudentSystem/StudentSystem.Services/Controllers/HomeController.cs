namespace StudentSystem.Services.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            this.ViewBag.Title = "Student System";

            return this.View();
        }
    }
}