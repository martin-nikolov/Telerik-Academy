namespace BugLogger.Data.Contracts
{
    using System;
    using System.Linq;

    public interface IBugLoggerData : IDisposable
    {
        IBugRepository Bugs { get; }

        int SaveChanges();
    }
}