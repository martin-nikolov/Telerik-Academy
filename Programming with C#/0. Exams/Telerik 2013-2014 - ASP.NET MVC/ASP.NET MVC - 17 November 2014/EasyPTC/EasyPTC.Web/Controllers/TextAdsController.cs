namespace EasyPTC.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using AutoMapper.QueryableExtensions;
    using EasyPTC.Data;
    using EasyPTC.Web.ViewModels.TextAds;

    public class TextAdsController : BaseController
    {
        public TextAdsController(IEasyPtcData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            var textAds = this.Data.TextAdvertisements.All()
                              .Where(t => t.AvailableClicks > 0)
                              .Project()
                              .To<TextAdvertisementViewModel>()
                              .ToList();

            return this.View(textAds);
        }
    }
}