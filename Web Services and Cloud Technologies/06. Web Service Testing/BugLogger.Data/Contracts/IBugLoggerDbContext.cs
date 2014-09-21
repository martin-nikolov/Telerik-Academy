namespace BugLogger.Data.Contracts
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using BugLogger.Models;

    public interface IBugLoggerDbContext : IDbContext
    {
        IDbSet<Bug> Bugs { get; set; }
    }
}