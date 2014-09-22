namespace ForumSystem.Web
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Web.Http;
    using ForumSystem.Data;
    using ForumSystem.Data.Contracts;
    using ForumSystem.Data.UnitOfWork;
    using Microsoft.Owin;
    using Ninject;
    using Ninject.Web.Common.OwinHost;
    using Ninject.Web.WebApi.OwinHost;
    using Owin;

    [assembly: OwinStartup(typeof(ForumSystem.Web.Startup))]
    
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
            app.UseNinjectMiddleware(CreateKernel).UseNinjectWebApi(GlobalConfiguration.Configuration);
        }

        private static StandardKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            RegisterMappings(kernel);
            return kernel;
        }

        private static void RegisterMappings(StandardKernel kernel)
        {
            kernel.Bind<IForumSystemData>().To<ForumSystemData>().WithConstructorArgument("context", c => new ForumSystemContext());
        }
    }
}