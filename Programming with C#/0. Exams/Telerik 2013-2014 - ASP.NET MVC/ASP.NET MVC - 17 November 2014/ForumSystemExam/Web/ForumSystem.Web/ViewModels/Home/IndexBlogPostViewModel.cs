namespace ForumSystem.Web.ViewModels.Home
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using ForumSystem.Data.Models;
    using ForumSystem.Web.Infrastructure.Mapping;

    public class IndexBlogPostViewModel : IMapFrom<Post>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int? Votes { get; set; }

        public ICollection<TagViewModel> Tags { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Post, IndexBlogPostViewModel>()
                         .ForMember(m => m.Tags, opt => opt.MapFrom(u => u.Tags.ToList().Select(a => new TagViewModel() { Title = a.Name })));

            configuration.CreateMap<Post, IndexBlogPostViewModel>()
                         .ForMember(m => m.Votes, opt => opt.MapFrom(u => u.Votes.Sum(a => a.Value)));
        }
    }
}