namespace NewsSystem.Web
{
    using System;
    using System.Web.Routing;
    using Microsoft.AspNet.FriendlyUrls;

    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            var settings = new FriendlyUrlSettings();
            settings.AutoRedirectMode = RedirectMode.Permanent;
            routes.EnableFriendlyUrls(settings);
        }
    }
}