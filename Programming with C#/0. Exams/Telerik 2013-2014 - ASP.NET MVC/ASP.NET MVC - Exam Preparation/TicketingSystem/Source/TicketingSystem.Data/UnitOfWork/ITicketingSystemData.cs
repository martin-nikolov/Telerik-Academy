namespace TicketingSystem.Data.UnitOfWork
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Microsoft.AspNet.Identity.EntityFramework;
    using TicketingSystem.Data.Contracts;
    using TicketingSystem.Data.Models;

    public interface ITicketingSystemData : IDisposable
    {
        DbContext Context { get; }

        IGenericRepository<User> Users { get; }

        IGenericRepository<IdentityUserRole> UserRoles { get; }

        IGenericRepository<IdentityRole> Roles { get; }

        IGenericRepository<Category> Categories { get; }

        IGenericRepository<Comment> Comments { get; }

        IGenericRepository<Image> Images { get; }

        IGenericRepository<Ticket> Tickets { get; }

        int SaveChanges();
    }
}