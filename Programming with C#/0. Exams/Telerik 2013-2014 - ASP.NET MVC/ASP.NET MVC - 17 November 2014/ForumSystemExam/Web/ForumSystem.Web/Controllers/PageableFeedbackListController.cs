namespace ForumSystem.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Caching;
    using System.Web.Mvc;
    using AutoMapper.QueryableExtensions;
    using ForumSystem.Data.Common.Repository;
    using ForumSystem.Data.Models;
    using ForumSystem.Web.ViewModels.PageableFeedbackList;

    [Authorize]
    public class PageableFeedbackListController : Controller
    {
        private const int DefaultPageSize = 4;
        private const int CacheTimeInMinutes = 1;

        private IDeletableEntityRepository<Feedback> feedbacks;

        public PageableFeedbackListController(IDeletableEntityRepository<Feedback> feedbacks)
        {
            this.feedbacks = feedbacks;
        }

        public ActionResult Index(int? page)
        {
            int currentPage = page.HasValue ? page.Value : 1;

            var cacheKey = this.BuildCacheKey(currentPage);
            var feedbacksList = this.GetOrCreateListFeedbackViewModelFromCache(cacheKey, currentPage);

            var numberOfFeedbacks = this.feedbacks.All().Count();
            var numberOfPages = (int)Math.Ceiling((double)numberOfFeedbacks / DefaultPageSize);

            this.ViewBag.CurrentPage = currentPage;
            this.ViewBag.NumberOfPages = numberOfPages;

            return this.View(feedbacksList);
        }

        private IList<ListFeedbackViewModel> GetOrCreateListFeedbackViewModelFromCache(string key, int page)
        {
            if (this.HttpContext.Cache[key] == null)
            {
                this.HttpContext.Cache.Insert(
                    key: key,
                    value: this.GetFeedbackList(page),
                    dependencies: null,
                    absoluteExpiration: DateTime.Now.AddMinutes(CacheTimeInMinutes),
                    slidingExpiration: TimeSpan.Zero,
                    priority: CacheItemPriority.Default,
                    onRemoveCallback: null);
            }

            var feedbackList = this.HttpContext.Cache[key] as IList<ListFeedbackViewModel>;
            return feedbackList;
        }

        private IList<ListFeedbackViewModel> GetFeedbackList(int page)
        {
            var feedbacksList = this.feedbacks.All()
                                    .OrderBy(f => f.Id)
                                    .Skip((page - 1) * DefaultPageSize)
                                    .Take(DefaultPageSize)
                                    .Project()
                                    .To<ListFeedbackViewModel>()
                                    .ToList();
            return feedbacksList;
        }

        private string BuildCacheKey(int page)
        {
            var cipher = "feedbackList-" + page;
            return cipher;
        }
    }
}