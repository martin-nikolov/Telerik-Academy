namespace EasyPTC.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using EasyPTC.Data;

    public class HomeController : BaseController
    {
        public HomeController(IEasyPtcData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult About()
        {
            return this.View();
            //return RedirectToAction<HomeController>(h => h.Index());
        }
    }
}