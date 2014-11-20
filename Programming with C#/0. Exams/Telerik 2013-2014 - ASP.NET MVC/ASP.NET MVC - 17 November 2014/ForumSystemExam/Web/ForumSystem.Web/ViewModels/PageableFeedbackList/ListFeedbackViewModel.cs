namespace ForumSystem.Web.ViewModels.PageableFeedbackList
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web.Mvc;
    using AutoMapper;
    using ForumSystem.Data.Models;
    using ForumSystem.Web.Infrastructure.Mapping;

    public class ListFeedbackViewModel : IMapFrom<Feedback>, IHaveCustomMappings
    {
        [Required]
        [MaxLength(20)]
        public string Title { get; set; }

        [AllowHtml]
        public string Content { get; set; }

        public string AuthorName { get; set; }

        public DateTime CreatedOn { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Feedback, ListFeedbackViewModel>()
                         .ForMember(m => m.AuthorName, opt => opt.MapFrom(u => u.Author.UserName));
        }
    }
}