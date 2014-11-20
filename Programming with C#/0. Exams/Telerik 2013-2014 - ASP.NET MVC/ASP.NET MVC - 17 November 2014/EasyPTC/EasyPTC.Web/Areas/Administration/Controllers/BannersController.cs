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
    using EasyPTC.Web.Areas.Administration.ViewModels.Banners;
    using EasyPTC.Web.Areas.Administration.ViewModels.TextAds;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;

    public class BannersController : AdminController
    {
        public BannersController(IEasyPtcData data)
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
            var result = this.Data.Banners.All()
                             .Project()
                             .To<BannerViewModel>();

            return this.Json(result.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public BannerViewModel Create(BannerViewModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                var banner = new Banner()
                {
                    Name = model.Name,
                    Url = model.Url,
                    ImageUrl = model.ImageUrl,
                    AvailableClicks = model.AvailableClicks
                };

                this.Data.Banners.Add(banner);
                this.Data.SaveChanges();

                var mapped = Mapper.Map<BannerViewModel>(banner);
                mapped.Id = banner.Id;
                return mapped;
            }

            return null;
        }

        public JsonResult Update([DataSourceRequest]
                                 DataSourceRequest request, BannerViewModel model)
        {
            var dbModel = this.Data.Banners.GetById(model.Id);

            if (model != null && this.ModelState.IsValid)
            {
                dbModel.Name = model.Name;
                dbModel.ImageUrl = model.ImageUrl;
                dbModel.AvailableClicks = model.AvailableClicks;
                dbModel.Url = model.Url;
                this.Data.Banners.Update(dbModel);
                this.Data.SaveChanges();
            }

            return this.Json((new[] { model }.ToDataSourceResult(request, this.ModelState)), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Destroy([DataSourceRequest]
                                  DataSourceRequest request, BannerViewModel model)
        {
            var dbModel = this.Data.Banners.GetById(model.Id);
            this.Data.Banners.Delete(dbModel);
            this.Data.SaveChanges();

            return this.Json(new[] { model }, JsonRequestBehavior.AllowGet);
        }
    }
}