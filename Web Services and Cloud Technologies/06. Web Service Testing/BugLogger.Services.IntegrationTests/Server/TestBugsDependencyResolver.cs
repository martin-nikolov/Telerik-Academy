namespace BugLogger.Services.IntegrationTests.Server
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http.Dependencies;
    using BugLogger.Data;
    using BugLogger.Data.Contracts;
    using BugLogger.Services.Controllers;

    public class TestBugsDependencyResolver<T> : IDependencyResolver
    {
        private IBugLoggerData bugLoggerData;

        public IBugLoggerData BugLoggerData
        {
            get
            {
                return this.bugLoggerData;
            }
            set
            {
                this.bugLoggerData = value;
            }
        }
   
        public IDependencyScope BeginScope()
        {
            return this;
        }

        public object GetService(Type serviceType)
        {
            // Add all controllers
            if (serviceType == typeof(BugsController))
            {
                return new BugsController(new BugLoggerData());
            }

            return null;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return new List<object>();
        }

        public void Dispose()
        {
        }
    }
}