namespace BugLogger.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using BugLogger.Common;
    using BugLogger.Data.Contracts;
    using BugLogger.Data.Migrations;
    using BugLogger.Models;

    public class BugLoggerDbContext : DbContext, IBugLoggerDbContext
    {
        public BugLoggerDbContext()
            : base(ConnectionStrings.BugLoggerConnectionString)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BugLoggerDbContext, Configuration>());
        }

        public IDbSet<Bug> Bugs { get; set; }

        public IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public void SaveChanges()
        {
            base.SaveChanges();
        }
    }
}