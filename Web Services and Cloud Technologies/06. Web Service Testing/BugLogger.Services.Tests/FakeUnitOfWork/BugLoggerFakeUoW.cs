namespace BugLogger.Services.Tests.FakeUnitOfWork
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using BugLogger.Data.Contracts;
    using BugLogger.Models;
    using BugLogger.Services.Tests.FakeRepositories;

    public class BugLoggerFakeUoW : IBugLoggerData
    {
        private readonly BugFakeRepository bugFakeRepository = new BugFakeRepository();

        public IBugRepository Bugs
        {
            get
            {
                return this.bugFakeRepository;
            }
        }

        public bool IsSaveChangedCalled { get; set; }

        public void AddBugEntities(IList<Bug> entities)
        {
            this.bugFakeRepository.Entities = entities;
        }

        public int SaveChanges()
        {
            this.IsSaveChangedCalled = true;
            return 1;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}