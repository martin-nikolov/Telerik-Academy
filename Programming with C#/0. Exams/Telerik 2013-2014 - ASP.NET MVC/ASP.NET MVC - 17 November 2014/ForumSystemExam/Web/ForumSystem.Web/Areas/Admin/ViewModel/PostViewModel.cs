namespace ForumSystem.Web.Areas.Admin.ViewModel
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web.Mvc;
    using AutoMapper;
    using ForumSystem.Data.Models;
    using ForumSystem.Web.Infrastructure.Mapping;

    public class PostViewModel : IMapFrom<Post>, IHaveCustomMappings
    {
        [Editable(false)]
        [HiddenInput]
        public int Id { get; set; }

        [MaxLength(100)]
        [UIHint("SingleLineText")]
        public string Title { get; set; }

        [UIHint("MultiLineText")]
        public string Content { get; set; }

        [Editable(false)]
        [HiddenInput]
        public string AuthorName { get; set; }

        [Editable(false)]
        [HiddenInput]
        public DateTime CreatedOn { get; set; }

        [Editable(false)]
        [HiddenInput]
        public DateTime? ModifiedOn { get; set; }

        [Editable(false)]
        [HiddenInput]
        public bool IsDeleted { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Post, PostViewModel>()
                         .ForMember(m => m.AuthorName, opt => opt.MapFrom(u => u.Author.UserName));
        }
    }
}