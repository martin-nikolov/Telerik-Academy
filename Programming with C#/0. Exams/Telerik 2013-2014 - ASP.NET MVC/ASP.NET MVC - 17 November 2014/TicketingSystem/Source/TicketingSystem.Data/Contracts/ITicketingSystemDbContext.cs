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
    }
}