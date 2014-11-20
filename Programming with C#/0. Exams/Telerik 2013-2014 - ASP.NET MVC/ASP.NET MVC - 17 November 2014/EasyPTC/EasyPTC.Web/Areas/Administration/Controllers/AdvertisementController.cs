namespace EasyPTC.Web.Areas.Administration.Controllers
{
    using System.Collections;
    using System.Linq;
    using System.Web.Mvc;
    using EasyPTC.Data;
    using EasyPTC.Models;
    using EasyPTC.Web.Areas.Administration.Controllers.Base;
    using Kendo.Mvc.UI;
    using Model = EasyPTC.Models.Advertisement;
    using ViewModel = EasyPTC.Web.Areas.Administration.ViewModels.Advertisements.AdvertisementViewModel;

    public class AdvertisementController : KendoGridAdministrationController
    {
        public AdvertisementController(IEasyPtcData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult Create([DataSourceRequest]
                                   DataSourceRequest request, ViewModel model)
        {
            var dbModel = base.Create<Model>(model);
            if (dbModel != null)
                model.Id = dbModel.Id;
            return this.GridOperation(model, request);
        }

        [HttpPost]
        public ActionResult Update([DataSourceRequest]
                                   DataSourceRequest request, ViewModel model)
        {
            base.Update<Model, ViewModel>(model, model.Id);
            return this.GridOperation(model, request);
        }

        [HttpPost]
        public ActionResult Destroy([DataSourceRequest]
                                    DataSourceRequest request, ViewModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                this.Data.Advertisements.Delete(model.Id.Value);
                this.Data.SaveChanges();
            }

            return this.GridOperation(model, request);
        }

        protected override IEnumerable GetData()
        {
            return this.Data.Advertisements.All()
                       .OfType<Advertisement>();
        }

        protected override T GetById<T>(object id)
        {
            return this.Data.Advertisements.GetById(id) as T;
        }
    }
}