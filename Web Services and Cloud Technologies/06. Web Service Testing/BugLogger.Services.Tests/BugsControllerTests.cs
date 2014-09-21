namespace BugLogger.Services.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Web.Http;
    using System.Web.Http.Routing;
    using BugLogger.Data.Contracts;
    using BugLogger.Models;
    using BugLogger.Services.Controllers;
    using BugLogger.Services.Models;
    using BugLogger.Services.Tests.FakeUnitOfWork;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Telerik.JustMock;

    [TestClass]
    public class BugsControllerTests
    {
        [TestMethod]
        public void GetAllBugsShouldReturnBugsCollection()
        {
            // Arrange
            var bugs = this.GenerateBugsCollection();
            var bugLoggerFakeData = new BugLoggerFakeUoW();
            bugLoggerFakeData.AddBugEntities(bugs);

            var bugsController = new BugsController(bugLoggerFakeData);

            // Act
            var result = bugsController.All();

            // Assert
            Assert.AreEqual(bugs.Count, result.Count());
            CollectionAssert.AreEquivalent(bugs.ToList(), result.ToList());
        }

        [TestMethod]
        public void AddValidBugShouldBeAddedToRepository()
        {
            // Arrange
            var bugLoggerFakeData = new BugLoggerFakeUoW();
            var bug = new CreateBugModel()
            {
                Description = "bug-1",
                LogDate = DateTime.Now
            };

            var bugsController = new BugsController(bugLoggerFakeData);
            this.SetupController(bugsController);

            // Act
            bugsController.Create(bug);

            // Assert
            Assert.AreEqual(bugLoggerFakeData.Bugs.All().Count(), 1);

            var bugInDatabase = bugLoggerFakeData.Bugs.All().First();
            Assert.AreEqual(bug.Description, bugInDatabase.Description);
            Assert.AreEqual(BugStatus.Pending, bugInDatabase.Status);
            Assert.IsNotNull(bugInDatabase.LogDate);
            Assert.IsTrue(bugLoggerFakeData.IsSaveChangedCalled);
        }

        [TestMethod]
        public void AddBugWithEmptyDescriptionShouldNotBeAddedToRepository()
        {
            // Arrange
            var bugLoggerFakeData = new BugLoggerFakeUoW();
            var bug = new CreateBugModel()
            {
                Description = string.Empty,
                LogDate = DateTime.Now
            };

            var bugsController = new BugsController(bugLoggerFakeData);
            this.SetupController(bugsController);

            // Act
            bugsController.Create(bug);

            // Assert
            Assert.AreEqual(bugLoggerFakeData.Bugs.All().Count(), 0);
        }

        [TestMethod]
        public void AddBugWithNullDescriptionShouldNotBeAddedToRepository()
        {
            // Arrange
            var bugLoggerFakeData = new BugLoggerFakeUoW();
            var bug = new CreateBugModel()
            {
                Description = null,
                LogDate = DateTime.Now
            };

            var bugsController = new BugsController(bugLoggerFakeData);
            this.SetupController(bugsController);

            // Act
            bugsController.Create(bug);

            // Assert
            Assert.AreEqual(bugLoggerFakeData.Bugs.All().Count(), 0);
        }

        [TestMethod]
        public void AddBugWithValidDescriptionAndWithoutLogDateShouldNotBeAddedToRepository()
        {
            // Arrange
            var bugLoggerFakeData = new BugLoggerFakeUoW();
            var bug = new CreateBugModel()
            {
                Description = "bug-1"
            };

            var bugsController = new BugsController(bugLoggerFakeData);
            this.SetupController(bugsController);

            // Act
            bugsController.Create(bug);

            // Assert
            Assert.AreEqual(bugLoggerFakeData.Bugs.All().Count(), 0);
        }

        [TestMethod]
        public void AddBugWithoutBothDescriptionAndLogDateShouldNotBeAddedToRepository()
        {
            // Arrange
            var bugLoggerFakeData = new BugLoggerFakeUoW();
            var bug = new CreateBugModel();

            var bugsController = new BugsController(bugLoggerFakeData);
            this.SetupController(bugsController);

            // Act
            bugsController.Create(bug);

            // Assert
            Assert.AreEqual(bugLoggerFakeData.Bugs.All().Count(), 0);
        }

        [TestMethod]
        public void GetAllBugsShouldReturnBugsCollection_Mocking()
        {
            // Arrange
            var bugs = this.GenerateBugsCollection();
            var bugLoggerFakeData = this.MockUnitOfWorkForActionAll(bugs);
            var bugsController = new BugsController(bugLoggerFakeData);
            
            // Act
            var result = bugsController.All();

            // Assert
            CollectionAssert.AreEquivalent(bugs.ToList(), result.ToList());
        }

        [TestMethod]
        public void AddValidBugShouldBeAddedToRepository_Mocking()
        {
            // Arrange
            var bug = new CreateBugModel()
            {
                Description = "bug-1",
                LogDate = DateTime.Now
            };

            var bugs = new List<Bug>();
            var bugLoggerFakeData = this.MockUnitOfWorkForActionAll(bugs);
            var bugsController = new BugsController(bugLoggerFakeData);
            this.SetupController(bugsController);

            // Act
            bugsController.Create(bug);

            // Assert
            Assert.AreEqual(bugLoggerFakeData.Bugs.All().Count(), 1);

            var bugInDatabase = bugLoggerFakeData.Bugs.All().First();
            Assert.AreEqual(bug.Description, bugInDatabase.Description);
            Assert.AreEqual(BugStatus.Pending, bugInDatabase.Status);
            Assert.IsNotNull(bugInDatabase.LogDate);
        }

        private IList<Bug> GenerateBugsCollection()
        {
            var bugs = new List<Bug>()
            {
                new Bug()
                {
                    BugId = 1,
                    Description = "bug-1"
                },
                new Bug()
                {
                    BugId = 2,
                    Description = "bug-2"
                },
                new Bug()
                {
                    BugId = 3,
                    Description = "bug-3"
                }
            };

            return bugs;
        }

        private IBugLoggerData MockUnitOfWorkForActionAll(IList<Bug> bugs)
        {
            var bugFakeRepository = Mock.Create<IBugRepository>();
            
            Mock.Arrange(() => bugFakeRepository.All())
                .Returns(() => bugs.AsQueryable());

            Mock.Arrange(() => bugFakeRepository.Add(Arg.IsAny<Bug>()))
                .DoInstead<Bug>((b) => bugs.Add(b));

            var bugLoggerData = Mock.Create<IBugLoggerData>();
            Mock.Arrange(() => bugLoggerData.Bugs)
                .Returns(() => bugFakeRepository);

            return bugLoggerData;
        }

        private void SetupController(ApiController controller)
        {
            string serverUrl = "http://test-url.com";

            // Setup the Request object of the controller
            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri(serverUrl)
            };
            controller.Request = request;

            // Setup the configuration of the controller
            var config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional });
            controller.Configuration = config;

            // Apply the routes of the controller
            controller.RequestContext.RouteData =
                new HttpRouteData(
                    route: new HttpRoute(),
                    values: new HttpRouteValueDictionary
                    {
                        { "controller", "Bugs" }
                    });
        }
    }
}