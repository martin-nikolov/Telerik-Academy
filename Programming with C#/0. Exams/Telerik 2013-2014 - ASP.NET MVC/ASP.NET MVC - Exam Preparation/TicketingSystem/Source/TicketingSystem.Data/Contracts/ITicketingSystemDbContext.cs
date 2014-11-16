namespace TicketingSystem.Data.Contracts
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Microsoft.AspNet.Identity.EntityFramework;
    using TicketingSystem.Data.Models;

    public interface ITicketingSystemDbContext : IDbContext
    {
        IDbSet<User> Users { get; set; }

        IDbSet<IdentityRole> Roles { get; set; }

        IDbSet<IdentityUserRole> UserRoles { get; set; }

        IDbSet<Ticket> Tickets { get; set; }

        IDbSet<Category> Categories { get; set; }

        IDbSet<Comment> Comments { get; set; }

        IDbSet<Image> Images { get; set; }
    }
}