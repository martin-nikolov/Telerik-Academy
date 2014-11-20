namespace ForumSystem.Web.ViewModels.Feedbacks
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web.Mvc;
    using ForumSystem.Data.Models;
    using ForumSystem.Web.Infrastructure.Mapping;

    public class FeedbackViewModel : IMapFrom<Feedback>
    {
        [Required]
        [MaxLength(20)]
        public string Title { get; set; }

        [AllowHtml]
        public string Content { get; set; }
    }
}