namespace ForumSystem.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using ForumSystem.Data.Common.Repository;
    using ForumSystem.Data.Models;
    using ForumSystem.Web.ViewModels.Feedbacks;
    using Microsoft.AspNet.Identity;

    public class FeedbackController : Controller
    {
        private const string SuccessfulMessageOnCreateNewFeedback = "You successfully created a new feedback!";

        private IDeletableEntityRepository<Feedback> feedbacks;

        public FeedbackController(IDeletableEntityRepository<Feedback> feedbacks)
        {
            this.feedbacks = feedbacks;
        }

        [HttpGet]
        public ActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult Create(FeedbackViewModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                var feedback = AutoMapper.Mapper.Map<Feedback>(model);
                
                var userId = this.GetCurrentUserId();
                if (userId != null)
                {
                    feedback.AuthorId = userId;
                }

                this.feedbacks.Add(feedback);
                this.feedbacks.SaveChanges();

                this.SetSuccessfullMessage(SuccessfulMessageOnCreateNewFeedback);
                return this.RedirectToAction("Index", "Home");
            }

            return this.View(model);
        }
 
        private void SetSuccessfullMessage(string message)
        {
            this.TempData["successfulMessage"] = message;
        }

        private string GetCurrentUserId()
        {
            var userId = this.User.Identity.GetUserId();
            return userId;
        }
    }
}