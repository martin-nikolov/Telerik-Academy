namespace EasyPTC.Web.Areas.Administration.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using EasyPTC.Data;
    using EasyPTC.Models;
    using EasyPTC.Web.Areas.Administration.Controllers.Base;
    using EasyPTC.Web.Areas.Administration.ViewModels.TextAds;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;

    public class TextAdsController : AdminController
    {
        public TextAdsController(IEasyPtcData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public JsonResult Read([DataSourceRequest]
                               DataSourceRequest request)
        {
            var result = this.Data.TextAdvertisements.All()
                             .Project()
                             .To<TextAdvertisementViewModel>();

            return this.Json(result.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public TextAdvertisementViewModel Create(TextAdvertisementViewModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                var textAd = new TextAdvertisement()
                {
                    Name = model.Name,
                    Url = model.Url,
                    Content = model.Content,
                    AvailableClicks = model.AvailableClicks
                };

                this.Data.TextAdvertisements.Add(textAd);
                this.Data.SaveChanges();

                var mapped = Mapper.Map<TextAdvertisementViewModel>(textAd);
                mapped.Id = textAd.Id;
                return mapped;
            }

            return null;
        }

        public JsonResult Update([DataSourceRequest]
                                 DataSourceRequest request, TextAdvertisementViewModel model)
        {
            var dbModel = this.Data.TextAdvertisements.GetById(model.Id);

            if (model != null && this.ModelState.IsValid)
            {
                dbModel.Name = model.Name;
                dbModel.Content = model.Content;
                dbModel.AvailableClicks = model.AvailableClicks;
                dbModel.Url = model.Url;
                this.Data.TextAdvertisements.Update(dbModel);
                this.Data.SaveChanges();
            }

            return this.Json((new[] { model }.ToDataSourceResult(request, this.ModelState)), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Destroy([DataSourceRequest]
                                  DataSourceRequest request, TextAdvertisementViewModel model)
        {
            var dbModel = this.Data.TextAdvertisements.GetById(model.Id);
            this.Data.TextAdvertisements.Delete(dbModel);
            this.Data.SaveChanges();

            return this.Json(new[] { model }, JsonRequestBehavior.AllowGet);
        }
    }
}