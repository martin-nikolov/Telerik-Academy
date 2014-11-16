using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TicketingSystem.Web.Startup))]
namespace TicketingSystem.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
