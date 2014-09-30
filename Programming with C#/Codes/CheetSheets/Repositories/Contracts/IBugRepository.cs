namespace BugLogger.Data.Contracts
{
    using System;
    using System.Linq;
    using BugLogger.Models;

    public interface IBugRepository : IGenericRepository<Bug>
    {
        IQueryable<Bug> GetAllByStatus(BugStatus status);

        IQueryable<Bug> GetAllFromDate(DateTime fromDate);

        IQueryable<Bug> GetAllToDate(DateTime toDate);

        IQueryable<Bug> GetAllInDateRange(DateTime fromDate, DateTime toDate);
    }
}