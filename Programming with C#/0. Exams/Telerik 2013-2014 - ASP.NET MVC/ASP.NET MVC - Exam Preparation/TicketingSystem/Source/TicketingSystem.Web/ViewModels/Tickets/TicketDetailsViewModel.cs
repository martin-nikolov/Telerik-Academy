namespace TicketingSystem.Web.ViewModels.Tickets
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using TicketingSystem.Data.Models;
    using TicketingSystem.Data.Models.Enums;
    using TicketingSystem.Web.Infrastructure.Mapping;
    using TicketingSystem.Web.ViewModels.Comments;

    public class TicketDetailsViewModel : IMapFrom<Ticket>, IHaveCustomMappings
    {
        public int TicketId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public PriorityType Priority { get; set; }

        public int? ImageId { get; set; }

        public string CategoryName { get; set; }

        public string AuthorName { get; set; }

        public IEnumerable<CommentViewModel> Comments { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Ticket, TicketDetailsViewModel>()
                         .ForMember(m => m.CategoryName, opt => opt.MapFrom(u => u.Category.Name));

            configuration.CreateMap<Ticket, TicketDetailsViewModel>()
                         .ForMember(m => m.AuthorName, opt => opt.MapFrom(u => u.Author.UserName));
        }
    }
}