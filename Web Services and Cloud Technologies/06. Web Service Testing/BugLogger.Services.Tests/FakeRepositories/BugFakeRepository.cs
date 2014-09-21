namespace BugLogger.Services.Tests.FakeRepositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using BugLogger.Data.Contracts;
    using BugLogger.Models;

    public class BugFakeRepository : IGenericRepository<Bug>, IBugRepository
    {
        private IList<Bug> entities;

        public BugFakeRepository()
        {
            this.entities = new List<Bug>();
        }

        public IList<Bug> Entities
        {
            get
            {
                return this.entities;
            }
            set
            {
                this.entities = value;
            }
        }

        public bool IsSaveChangedCalled { get; set; }

        public IQueryable<Bug> All()
        {
            return this.Entities.AsQueryable();
        }

        public IQueryable<Bug> Search(Expression<Func<Bug, bool>> condition)
        {
            return this.Entities.AsQueryable().Where(condition);
        }

        public Bug Find(int id)
        {
            return this.Entities.AsQueryable().FirstOrDefault(b => b.BugId == id);
        }

        public void Add(Bug entity)
        {
            this.Entities.Add(entity);
        }

        public void Update(Bug entity)
        {
            var bug = this.Find(entity.BugId);
            if (bug != null)
            {
                bug = entity;
            }
        }

        public void Delete(Bug entity)
        {
            this.Delete(entity.BugId);
        }

        public void Delete(int id)
        {
            var bug = this.Find(id);
            if (bug != null)
            {
                this.Entities.Remove(bug);
            }
        }

        public IQueryable<Bug> GetAllByStatus(BugStatus status)
        {
            return this.Entities.AsQueryable().Where(b => b.Status == status);
        }

        public IQueryable<Bug> GetAllFromDate(DateTime fromDate)
        {
            return this.GetAllInDateRange(fromDate, DateTime.MaxValue);
        }

        public IQueryable<Bug> GetAllToDate(DateTime toDate)
        {
            return this.GetAllInDateRange(DateTime.MinValue, toDate);
        }

        public IQueryable<Bug> GetAllInDateRange(DateTime fromDate, DateTime toDate)
        {
            return this.Entities.AsQueryable().Where(b => b.LogDate >= fromDate && b.LogDate <= toDate);
        }

        public void Detach(Bug entity)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            this.IsSaveChangedCalled = true;
        }
    }
}