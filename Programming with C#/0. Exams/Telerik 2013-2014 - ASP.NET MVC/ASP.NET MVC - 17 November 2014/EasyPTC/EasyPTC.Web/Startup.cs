using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EasyPTC.Web.Startup))]
namespace EasyPTC.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
