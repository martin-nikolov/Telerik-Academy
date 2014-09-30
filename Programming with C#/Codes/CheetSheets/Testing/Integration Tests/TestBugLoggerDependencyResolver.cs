using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Dependencies;
using BugLogger.DataLayer;
using BugLogger.Repositories;
using BugLogger.RestApi.Controllers;

namespace BugLogger.RestApi.Tests
{
    class TestBugsDependencyResolver<T> : IDependencyResolver
    {
        private IRepository<T> repository;

        public IRepository<T> Repository
        {
            get
            {
                return this.repository;
            }
            set
            {
                this.repository = value;
            }
        }

        public IDependencyScope BeginScope()
        {
            return this;
        }

        public object GetService(Type serviceType)
        {
            //add all controllers
            if (serviceType == typeof(BugsController))
            {
                return new BugsController(this.Repository as IRepository<Bug>);
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
