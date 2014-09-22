namespace ForumSystem.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;
    using ForumSystem.Data.Contracts;
    using ForumSystem.Data.UnitOfWork;
    using ForumSystem.Web.Projections;

    public class CategoriesController : BaseApiController
    {
        //public CategoriesController()
        //    : base(new ForumSystemData())
        //{
        //}

        public CategoriesController(IForumSystemData forumSystemData)
            : base(forumSystemData)
        {
        }
        
        [HttpGet]
        [Authorize]
        public IQueryable<CategoryProjection> Get()
        {
            return this.ForumSystemData.Categories
                       .All()
                       .Select(CategoryProjection.FromCategory);
        }

        [HttpGet]
        [Authorize]
        public IHttpActionResult Get(int id)
        {
            var category = this.ForumSystemData.Categories
                               .All()
                               .Select(CategoryProjection.FromCategory)
                               .FirstOrDefault(c => c.ID == id);

            if (category == null)
            {
                return this.BadRequest(string.Format("Category with id={0} does not exists!", id));
            }

            return this.Ok(category);
        }
    }
}