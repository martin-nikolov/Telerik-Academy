namespace TicketingSystem.Data.UnitOfWork
{
    using System;
    using System.Linq;
    using Microsoft.AspNet.Identity.EntityFramework;
    using TicketingSystem.Data.Contracts;
    using TicketingSystem.Data.Models;

    public interface ITicketingSystemData : IDisposable
    {
        IGenericRepository<User> Users { get; }

        IGenericRepository<IdentityUserRole> UserRoles { get; }

        IGenericRepository<IdentityRole> Roles { get; }

        int SaveChanges();
    }
}