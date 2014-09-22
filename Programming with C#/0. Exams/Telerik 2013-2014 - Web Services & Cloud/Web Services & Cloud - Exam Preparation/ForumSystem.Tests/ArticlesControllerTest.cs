namespace ForumSystem.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Threading;
    using System.Web.Http;
    using System.Web.Http.Routing;
    using ForumSystem.Data.Contracts;
    using ForumSystem.Models;
    using ForumSystem.Web.Controllers;
    using ForumSystem.Web.Projections;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Telerik.JustMock;

    [TestClass]
    public class ArticlesControllerTest
    {
        private const int DefaultPageSize = 10;
        private readonly DataGenerator dataGenerator = new DataGenerator();

        [TestMethod]
        public void GetAllArticlesInDatabaseShouldReturnAll10Articles()
        {
            var articles = this.dataGenerator.GenerateArticles(DefaultPageSize);

            var articlesRepository = Mock.Create<IGenericRepository<Article>>();
            var forumSystemData = this.SetupUnitOfWork(articlesRepository, articles);
            var articlesController = this.SetupController(forumSystemData);

            var actionResult = articlesController.Get();
            var actionResponse = actionResult.ExecuteAsync(CancellationToken.None).Result;
            var actual = actionResponse.Content.ReadAsAsync<IEnumerable<ArticleProjection>>().Result.ToList();
            var expected = articles.AsQueryable()
                                   .Select(ArticleProjection.FromArticle)
                                   .OrderBy(a => a.DateCreated)
                                   .Take(DefaultPageSize)
                                   .ToList();

            Assert.AreEqual(DefaultPageSize, actual.Count());
            for (int i = 0; i < DefaultPageSize; i++)
            {
                Assert.AreEqual(expected[i].ID, actual[i].ID);
            }
        }

        [TestMethod]
        public void GetAllArticlesInDatabaseShouldReturnArticlesShouldReturnFirst10SortedByDate()
        {
            int numberOfArticlesToGenerate = 20;
            var articles = this.dataGenerator.GenerateArticles(numberOfArticlesToGenerate);

            var articlesRepository = Mock.Create<IGenericRepository<Article>>();
            var forumSystemData = this.SetupUnitOfWork(articlesRepository, articles);
            var articlesController = this.SetupController(forumSystemData);

            var actionResult = articlesController.Get();
            var actionResponse = actionResult.ExecuteAsync(CancellationToken.None).Result;
            var actual = actionResponse.Content.ReadAsAsync<IEnumerable<ArticleProjection>>().Result.ToList();
            var expected = articles.AsQueryable()
                                   .Select(ArticleProjection.FromArticle)
                                   .OrderBy(a => a.DateCreated)
                                   .Take(DefaultPageSize)
                                   .ToList();

            Assert.AreEqual(DefaultPageSize, actual.Count());
            for (int i = 0; i < DefaultPageSize; i++)
            {
                Assert.AreEqual(expected[i].ID, actual[i].ID);
            }
        }
 
        private IForumSystemData SetupUnitOfWork(IGenericRepository<Article> articlesRepository, IList<Article> articles)
        {
            Mock.Arrange(() => articlesRepository.All())
                .Returns(() => articles.AsQueryable());

            var forumSystemData = Mock.Create<IForumSystemData>();
            Mock.Arrange(() => forumSystemData.Articles)
                .Returns(() => articlesRepository);

            return forumSystemData;
        }

        private ArticlesController SetupController(IForumSystemData forumSystemData)
        {
            var articlesController = new ArticlesController(forumSystemData);
            this.SetupController(articlesController);
            return articlesController;
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
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });
            controller.Configuration = config;

            // Apply the routes of the controller
            controller.RequestContext.RouteData =
                new HttpRouteData(
                    route: new HttpRoute(),
                    values: new HttpRouteValueDictionary
                    {
                        { "controller", "Articles" }
                    });
        }
    }
}