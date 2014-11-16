namespace TicketingSystem.Web.ViewModels.Comments
{
    using System;
    using System.Linq;
    using AutoMapper;
    using TicketingSystem.Data.Models;
    using TicketingSystem.Web.Infrastructure.Mapping;

    public class CommentViewModel : IMapFrom<Comment>, IHaveCustomMappings
    {
        public int CommentId { get; set; }

        public string AuthorName { get; set; }

        public string Content { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Comment, CommentViewModel>()
                         .ForMember(c => c.AuthorName, opt => opt.MapFrom(c => c.Author.UserName));
        }
    }
}