using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ForumSystem.Web.Startup))]
namespace ForumSystem.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
