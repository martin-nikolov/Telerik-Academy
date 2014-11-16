namespace TicketingSystem.Web.ViewModels.Tickets
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using TicketingSystem.Data.Models;
    using TicketingSystem.Web.Infrastructure.Mapping;
    using TicketingSystem.Web.ViewModels.Comments;

    public class ListTicketViewModel : IMapFrom<Ticket>, IHaveCustomMappings
    {
        public int TicketId { get; set; }

        public string Title { get; set; }

        public string Priority { get; set; }

        public string CategoryName { get; set; }

        public string AuthorName { get; set; }

        public ICollection<CommentViewModel> Comments { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Ticket, ListTicketViewModel>()
                         .ForMember(m => m.Priority, opt => opt.MapFrom(u => u.Priority.ToString()));

            configuration.CreateMap<Ticket, ListTicketViewModel>()
                         .ForMember(m => m.CategoryName, opt => opt.MapFrom(u => u.Category.Name));

            configuration.CreateMap<Ticket, ListTicketViewModel>()
                         .ForMember(m => m.AuthorName, opt => opt.MapFrom(u => u.Author.UserName));
        }
    }
}