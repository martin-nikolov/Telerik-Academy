namespace TicketingSystem.Web.ViewModels.Home
{
    using System;
    using System.Linq;
    using AutoMapper;
    using TicketingSystem.Data.Models;
    using TicketingSystem.Web.Infrastructure.Mapping;

    public class TicketViewModel : IMapFrom<Ticket>, IHaveCustomMappings
    {
        public int TicketId { get; set; }

        public string Title { get; set; }

        public string Category { get; set; }

        public string Author { get; set; }

        public int NumberOfComments { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Ticket, TicketViewModel>()
                         .ForMember(m => m.Category, opt => opt.MapFrom(u => u.Category.Name));

            configuration.CreateMap<Ticket, TicketViewModel>()
                         .ForMember(m => m.Author, opt => opt.MapFrom(u => u.Author.UserName));

            configuration.CreateMap<Ticket, TicketViewModel>()
                         .ForMember(m => m.NumberOfComments, opt => opt.MapFrom(u => u.Comments.Count()));
        }
    }
}