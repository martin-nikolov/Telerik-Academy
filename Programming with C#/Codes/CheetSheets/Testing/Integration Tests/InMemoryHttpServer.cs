using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Web.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using BugLogger.Repositories;
using Newtonsoft.Json;
using Newtonsoft.Json;
using Telerik.JustMock;
using BugLogger.RestApi.Tests;

namespace BugLogger.RestApi.IntegrationTests
{
    public class InMemoryHttpServer<T>
    {
        private readonly HttpClient client;
        private string baseUrl;

        public InMemoryHttpServer(string baseUrl, IRepository<T> repository)
        {
            this.baseUrl = baseUrl;
            var config = new HttpConfiguration();
            this.AddHttpRoutes(config.Routes);
            config.IncludeErrorDetailPolicy =
                IncludeErrorDetailPolicy.Always;

            var resolver = new TestBugsDependencyResolver<T>();
            resolver.Repository = repository;
            config.DependencyResolver = resolver;

            var server = new HttpServer(config);
            this.client = new HttpClient(server);
        }

        public HttpResponseMessage CreateGetRequest(string requestUrl, string mediaType = "application/json")
        {
            var url = requestUrl;
            var request = new HttpRequestMessage();
            request.RequestUri = new Uri(baseUrl + url);
            request.Headers.Accept.Add(
                new MediaTypeWithQualityHeaderValue(mediaType));
            request.Method = HttpMethod.Get;

            var response = this.client.SendAsync(request).Result;
            return response;
        }

        public Task<HttpResponseMessage> CreateGetRequestAsync(string requestUrl, string mediaType = "application/json")
        {
            var url = requestUrl;
            var request = new HttpRequestMessage();
            request.RequestUri = new Uri(baseUrl + url);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(mediaType));
            request.Method = HttpMethod.Get;

            var response = 
                this.client.SendAsync(request);
            return response;
        }

        public HttpResponseMessage CreatePostRequest(string requestUrl, object data, string mediaType = "application/json")
        {
            var url = requestUrl;
            var request = new HttpRequestMessage();
            request.RequestUri = new Uri(baseUrl + url);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(mediaType));
            request.Method = HttpMethod.Post;
            request.Content = new StringContent(JsonConvert.SerializeObject(data));
            request.Content.Headers.ContentType = new MediaTypeHeaderValue(mediaType);

            var response = this.client.SendAsync(request).Result;
            return response;
        }

        public HttpRequestMessage CreatePutRequest(string requestUrl, object data)
        {
            throw new NotImplementedException();
        }
        public HttpRequestMessage CreateDeleteRequest(string requestUrl)
        {
            throw new NotImplementedException();
        }

        private void AddHttpRoutes(HttpRouteCollection routeCollection)
        {
            var routes = GetRoutes();
            routes.ForEach(route => routeCollection.MapHttpRoute(route.Name, route.Template, route.Defaults));
        }

        private List<Route> GetRoutes()
        {
            return new List<Route>
            {
                new Route(
                    "DefaultApi",
                    "api/{controller}/{id}",
                    new { id = RouteParameter.Optional })
            };
        }

        private class Route
        {
            public Route(string name, string template, object defaults)
            {
                this.Name = name;
                this.Template = template;
                this.Defaults = defaults;
            }

            public object Defaults { get; set; }

            public string Name { get; set; }

            public string Template { get; set; }
        }
    }
}