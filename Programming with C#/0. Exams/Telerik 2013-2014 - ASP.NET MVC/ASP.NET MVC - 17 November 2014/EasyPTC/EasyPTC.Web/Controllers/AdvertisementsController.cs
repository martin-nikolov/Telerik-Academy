namespace EasyPTC.Web.Controllers
{
    using EasyPTC.Data;
    using EasyPTC.Models;
    using System.Web.Mvc;

    public class AdvertisementsController : BaseController
    {
        public AdvertisementsController(IEasyPtcData data)
            : base(data)
        {
        }

        // GET: Advertisements
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(Advertisement ad)
        {
            return View(ad);
        }
    }
}