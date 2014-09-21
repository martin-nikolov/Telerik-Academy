namespace BugLogger.Services.IntegrationTests
{
    using System;
    using System.Linq;
    using System.Net;
    using BugLogger.Data.Contracts;
    using BugLogger.Models;
    using BugLogger.Services.IntegrationTests.Server;
    using BugLogger.Services.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Telerik.JustMock;

    [TestClass]
    public class BugsControllerIntegrationTests
    {
        private const string InMemoryServerUrl = "http://localhost:4444";

        [TestMethod]
        public void GetAllWhenThereAreBugsInDatabaseShouldReturnStatus200AndNonEmptyContent()
        {
            var bugLoggerData = this.MockUnitOfWorkForActionAll();

            var server = new InMemoryHttpServer<Bug>(InMemoryServerUrl, bugLoggerData);
            var response = server.CreateGetRequest("/api/Bugs/All");

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response.Content);
        }

        [TestMethod]
        public void PostNewValidBugShouldReturn201()
        {
            var bugLoggerData = this.MockUnitOfWorkForActionAll();
            var bug = new CreateBugModel()
            {
                Description = "bug-1",
                LogDate = DateTime.Now
            };

            var server = new InMemoryHttpServer<Bug>(InMemoryServerUrl, bugLoggerData);
            var response = server.CreatePostRequest("/api/Bugs/Create", bug);

            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
        }

        [TestMethod]
        public void PostNewBugWhenDescriptionIsEmptyShouldReturn400()
        {
            var bugLoggerData = this.MockUnitOfWorkForActionAll();
            var bug = new CreateBugModel()
            {
                Description = string.Empty,
                LogDate = DateTime.Now
            };

            var server = new InMemoryHttpServer<Bug>(InMemoryServerUrl, bugLoggerData);
            var response = server.CreatePostRequest("/api/Bugs/Create", bug);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void PostNewBugWhenDescriptionIsNullShouldReturn400()
        {
            var bugLoggerData = this.MockUnitOfWorkForActionAll();
            var bug = new CreateBugModel()
            {
                Description = null,
                LogDate = DateTime.Now
            };

            var server = new InMemoryHttpServer<Bug>(InMemoryServerUrl, bugLoggerData);
            var response = server.CreatePostRequest("/api/Bugs/Create", bug);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void PostNewBugWithoutLogDateShouldReturn400()
        {
            var bugLoggerData = this.MockUnitOfWorkForActionAll();
            var bug = new CreateBugModel()
            {
                Description = "bug-1",
            };

            var server = new InMemoryHttpServer<Bug>(InMemoryServerUrl, bugLoggerData);
            var response = server.CreatePostRequest("/api/Bugs/Create", bug);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void PostNewBugWithoutLogDateAndEmptyDescriptionShouldReturn400()
        {
            var bugLoggerData = this.MockUnitOfWorkForActionAll();
            var bug = new CreateBugModel();

            var server = new InMemoryHttpServer<Bug>(InMemoryServerUrl, bugLoggerData);
            var response = server.CreatePostRequest("/api/Bugs/Create", bug);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        private IBugLoggerData MockUnitOfWorkForActionAll()
        {
            var bugFakeRepository = Mock.Create<IBugRepository>();
            var bugLoggerData = Mock.Create<IBugLoggerData>();
            Mock.Arrange(() => bugLoggerData.Bugs)
                .Returns(() => bugFakeRepository);

            return bugLoggerData;
        }
    }
}