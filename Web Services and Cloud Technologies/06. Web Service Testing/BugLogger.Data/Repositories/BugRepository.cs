namespace BugLogger.Data.Repositories
{
    using System;
    using System.Linq;
    using BugLogger.Data.Contracts;
    using BugLogger.Models;

    public class BugRepository : GenericRepository<Bug>, IBugRepository
    {
        public BugRepository()
            : this(new BugLoggerDbContext())
        {
        }

        public BugRepository(IBugLoggerDbContext context)
            : base(context)
        {
        }

        public virtual IQueryable<Bug> GetAllByStatus(BugStatus status)
        {
            return this.DbSet.Where(b => b.Status == status);
        }

        public virtual IQueryable<Bug> GetAllFromDate(DateTime fromDate)
        {
            return this.GetAllInDateRange(fromDate, DateTime.MaxValue);
        }

        public virtual IQueryable<Bug> GetAllToDate(DateTime toDate)
        {
            return this.GetAllInDateRange(DateTime.MinValue, toDate);
        }

        public virtual IQueryable<Bug> GetAllInDateRange(DateTime fromDate, DateTime toDate)
        {
            return this.DbSet.Where(b => b.LogDate >= fromDate && b.LogDate <= toDate);
        }
    }
}