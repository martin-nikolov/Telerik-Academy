namespace TicketingSystem.Web.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using TicketingSystem.Data.UnitOfWork;
    using TicketingSystem.Web.Infrastructure.Caching;
    using TicketingSystem.Web.Services.Base;
    using TicketingSystem.Web.Services.Contracts;

    public class CategoriesService : BaseService, ICategoriesService
    {
        private readonly ICacheService cacheService;

        public CategoriesService(ITicketingSystemData data, ICacheService cacheService)
            : base(data)
        {
            this.cacheService = cacheService;
        }

        public IEnumerable<SelectListItem> GetTicketCategories()
        {
            var categories = this.cacheService.Get<IEnumerable<SelectListItem>>("categories",
                () =>
                {
                    return this.Data.Categories.All()
                               .Select(c => new SelectListItem
                                      {
                                          Value = c.CategoryId.ToString(),
                                          Text = c.Name
                                      })
                               .ToList();
                });

            return categories;
        }

        /// <summary>
        /// Removes category along its tickets and ticket's comments
        /// </summary>
        public void RemoveCategoryById(int categoryId)
        {
            var category = this.Data.Categories.Find(categoryId);

            foreach (var ticketId in category.Tickets.Select(t => t.TicketId).ToList())
            {
                var comments = this.GetCommentsIdsByTicketId(ticketId);
                this.RemoveCommentsByListOfIds(comments);

                this.Data.SaveChanges();
                this.Data.Tickets.Remove(ticketId);
            }

            this.Data.SaveChanges();
            this.Data.Categories.Remove(category);
            this.Data.SaveChanges();
        }
 
        private IEnumerable<int> GetCommentsIdsByTicketId(int ticketId)
        {
            var comments = this.Data.Comments
                               .All()
                               .Where(c => c.TicketId == ticketId)
                               .Select(c => c.CommentId)
                               .ToList();
            return comments;
        }

        private void RemoveCommentsByListOfIds(IEnumerable<int> comments)
        {
            foreach (var commentId in comments)
            {
                this.Data.Comments.Remove(commentId);
            }
        }
    }
}