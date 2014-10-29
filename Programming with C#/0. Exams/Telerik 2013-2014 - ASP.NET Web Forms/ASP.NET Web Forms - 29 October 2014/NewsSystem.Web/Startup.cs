using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NewsSystem.Web.Startup))]
namespace NewsSystem.Web
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
