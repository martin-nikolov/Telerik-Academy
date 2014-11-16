namespace TicketingSystem.Web.Areas.Admin.Controllers
{
    using System;
    using System.Collections;
    using System.Linq;
    using System.Web.Mvc;
    using AutoMapper.QueryableExtensions;
    using Kendo.Mvc.UI;
    using TicketingSystem.Data.UnitOfWork;
    using TicketingSystem.Web.Areas.Admin.Controllers.Base;
    using TicketingSystem.Web.Infrastructure.Caching;
    using TicketingSystem.Web.Services.Contracts;
    using Model = TicketingSystem.Data.Models.Category;
    using ViewModel = TicketingSystem.Web.Areas.Admin.ViewModels.Categories.CategoryViewModel;

    public class CategoriesController : KendoGridAdminController
    {
        private readonly ICacheService cacheService;
        private readonly ICategoriesService categoriesService;

        public CategoriesController(ITicketingSystemData data, ICategoriesService categoriesService, ICacheService cacheService)
            : base(data)
        {
            this.categoriesService = categoriesService;
            this.cacheService = cacheService;
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
            {
                model.CategoryId = dbModel.CategoryId;
            }

            this.ClearCategoryCache();
            return this.GridOperation(model, request);
        }

        [HttpPost]
        public ActionResult Update([DataSourceRequest]
                                   DataSourceRequest request, ViewModel model)
        {
            base.Update<Model, ViewModel>(model, model.CategoryId);

            this.ClearCategoryCache();
            return this.GridOperation(model, request);
        }

        [HttpPost]
        public ActionResult Destroy([DataSourceRequest]
                                    DataSourceRequest request, ViewModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                if (model.CategoryId.HasValue)
                {
                    this.categoriesService.RemoveCategoryById(model.CategoryId.Value);
                }
            }

            this.ClearCategoryCache();
            return this.GridOperation(model, request);
        }
 
        protected override IEnumerable GetData()
        {
            return this.Data.Categories.All()
                       .Project()
                       .To<ViewModel>();
        }

        protected override T GetById<T>(object id)
        {
            return this.Data.Categories.Find(id) as T;
        }

        private void ClearCategoryCache()
        {
            this.cacheService.Clear("categories");
        }
    }
}