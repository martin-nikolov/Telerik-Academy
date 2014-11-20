namespace ForumSystem.Web.Areas.Admin.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using ForumSystem.Data.Common.Repository;
    using ForumSystem.Data.Models;
    using ForumSystem.Web.Areas.Admin.ViewModel;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Microsoft.AspNet.Identity;

    public class AdminPostsController : Controller
    {
        private IDeletableEntityRepository<Post> posts;

        public AdminPostsController(IDeletableEntityRepository<Post> posts)
        {
            this.posts = posts;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public JsonResult Read([DataSourceRequest]
                               DataSourceRequest request)
        {
            var result = this.posts.All()
                             .Project()
                             .To<PostViewModel>();

            return this.Json(result.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public PostViewModel Create(PostViewModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                var post = new Post()
                {
                    Title = model.Title,
                    Content = model.Content,
                    AuthorId = this.User.Identity.GetUserId(),
                    CreatedOn = DateTime.Now
                };

                this.posts.Add(post);
                this.posts.SaveChanges();

                var mapped = Mapper.Map<PostViewModel>(post);
                mapped.Id = post.Id;
                return mapped;
            }

            return null;
        }

        public JsonResult Update([DataSourceRequest]
                                 DataSourceRequest request, PostViewModel model)
        {
            var dbModel = this.posts.GetById(model.Id);

            if (model != null && this.ModelState.IsValid)
            {
                dbModel.Title = model.Title;
                dbModel.Content = model.Content;
                this.posts.Update(dbModel);
                this.posts.SaveChanges();

                model.ModifiedOn = dbModel.ModifiedOn;
            }

            return this.Json((new[] { model }.ToDataSourceResult(request, this.ModelState)), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Destroy([DataSourceRequest]
                                  DataSourceRequest request, PostViewModel model)
        {
            var dbModel = this.posts.GetById(model.Id);
            this.posts.Delete(dbModel);
            this.posts.SaveChanges();

            return this.Json(new[] { model }, JsonRequestBehavior.AllowGet);
        }
    }
}