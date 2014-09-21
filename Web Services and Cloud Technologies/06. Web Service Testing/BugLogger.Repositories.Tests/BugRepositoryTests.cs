namespace BugLogger.Repositories.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Validation;
    using System.Linq;
    using System.Transactions;
    using BugLogger.Data;
    using BugLogger.Data.Repositories;
    using BugLogger.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class BugRepositoryTests
    {
        private static TransactionScope transaction;

        [TestInitialize]
        public void Initialize()
        {
            transaction = new TransactionScope();
        }

        [TestCleanup]
        public void CleanUp()
        {
            transaction.Dispose();
        }

        [TestMethod]
        public void GetAllBugsShouldReturnBugsCollection()
        {
            // Arrange -> Prepare the objects
            var bugs = this.GenerateBugsCollection();

            // Act -> Test the objects

            var bugRepository = new BugRepository(new BugLoggerDbContext());
            var bugsInDatabaseCountOld = bugRepository.All().Count();
            foreach (var bug in bugs)
            {
                bugRepository.Add(bug);
            }
            bugRepository.SaveChanges();

            // Assert -> Validate the result
            Assert.AreEqual(bugsInDatabaseCountOld + bugs.Count, bugRepository.All().Count());
            CollectionAssert.AreEquivalent(bugs.ToList(), bugRepository.All().OrderBy(b => b.BugId).Skip(bugsInDatabaseCountOld).Take(bugs.Count).ToList());
        }

        [TestMethod]
        public void AddBugShouldBeAddedToDatabaseAndShouldBeReturnedFromRepository()
        {
            // Arrange -> Prepare the objects
            var bug = new Bug()
            {
                Description = "bug-1",
                LogDate = DateTime.Now
            };
   
            // Act -> Test the objects
            var bugRepository = new BugRepository(new BugLoggerDbContext());
            bugRepository.Add(bug);
            bugRepository.SaveChanges();

            // Assert -> Validate the result
            var bugFromDb = bugRepository.Find(bug.BugId);

            Assert.IsNotNull(bugFromDb);
            Assert.AreEqual(bug.Description, bugFromDb.Description);
        }

        [TestMethod]
        [ExpectedException(typeof(DbEntityValidationException))]
        public void AddBugWithEmptyDescriptionShouldThrowsValidationException()
        {
            // Arrange -> Prepare the objects
            var bug = new Bug()
            {
                Description = string.Empty,
                LogDate = DateTime.Now
            };

            // Act -> Test the objects
            var bugRepository = new BugRepository(new BugLoggerDbContext());
            bugRepository.Add(bug);
            bugRepository.SaveChanges();

            // Assert -> Validate the result
            var bugFromDb = bugRepository.Find(bug.BugId);

            Assert.IsNotNull(bugFromDb);
            Assert.AreEqual(bug.Description, bugFromDb.Description);
        }

        [TestMethod]
        [ExpectedException(typeof(DbEntityValidationException))]
        public void AddBugWithNullDescriptionShouldThrowsValidationException()
        {
            // Arrange -> Prepare the objects
            var bug = new Bug()
            {
                Description = null,
                LogDate = DateTime.Now
            };

            // Act -> Test the objects
            var bugRepository = new BugRepository(new BugLoggerDbContext());
            bugRepository.Add(bug);
            bugRepository.SaveChanges();

            // Assert -> Validate the result
            var bugFromDb = bugRepository.Find(bug.BugId);

            Assert.IsNotNull(bugFromDb);
            Assert.AreEqual(bug.Description, bugFromDb.Description);
        }

        [TestMethod]
        [ExpectedException(typeof(DbUpdateException))]
        public void AddBugWithoutLogDateShouldThrowsValidationException()
        {
            // Arrange -> Prepare the objects
            var bug = new Bug()
            {
                Description = "bug-1"
            };

            // Act -> Test the objects
            var bugRepository = new BugRepository(new BugLoggerDbContext());
            bugRepository.Add(bug);
            bugRepository.SaveChanges();

            // Assert -> Validate the result
            var bugFromDb = bugRepository.Find(bug.BugId);

            Assert.IsNotNull(bugFromDb);
            Assert.AreEqual(bug.Description, bugFromDb.Description);
        }

        [TestMethod]
        [ExpectedException(typeof(DbEntityValidationException))]
        public void AddBugWithoutBothDescriptionAndLogDateShouldThrowsValidationException()
        {
            // Arrange -> Prepare the objects
            var bug = new Bug();

            // Act -> Test the objects
            var bugRepository = new BugRepository(new BugLoggerDbContext());
            bugRepository.Add(bug);
            bugRepository.SaveChanges();

            // Assert -> Validate the result
            var bugFromDb = bugRepository.Find(bug.BugId);

            Assert.IsNotNull(bugFromDb);
            Assert.AreEqual(bug.Description, bugFromDb.Description);
        }

        private IList<Bug> GenerateBugsCollection()
        {
            var bugs = new List<Bug>()
            {
                new Bug()
                {
                    Description = "bug-1",
                    LogDate = DateTime.Now
                },
                new Bug()
                {
                    Description = "bug-2",
                    LogDate = DateTime.Now
                },
                new Bug()
                {
                    Description = "bug-3",
                    LogDate = DateTime.Now
                }
            };

            return bugs;
        }
    }
}