namespace ForumSystem.Data.Contracts
{
    using System;
    using System.Linq;
    using ForumSystem.Models;

    public interface IAlertsData : IDisposable
    {
        IGenericRepository<Alert> Alerts { get; }

        int SaveChanges();
    }
}