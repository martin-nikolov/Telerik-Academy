namespace TicketingSystem.Web.Infrastructure.Mapping
{
    using System;
    using System.Linq;
    using AutoMapper;

    public interface IHaveCustomMappings
    {
        void CreateMappings(IConfiguration configuration);
    }
}