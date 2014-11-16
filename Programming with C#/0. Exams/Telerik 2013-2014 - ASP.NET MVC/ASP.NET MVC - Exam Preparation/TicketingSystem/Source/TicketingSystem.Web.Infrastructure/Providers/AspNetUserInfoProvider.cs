namespace TicketingSystem.Web.Infrastructure.Providers
{
    using System.Threading;
    using Microsoft.AspNet.Identity;

    public class AspNetUserInfoProvider : IUserInfoProvider
    {
        public string GetUserId()
        {
            return Thread.CurrentPrincipal.Identity.GetUserId();
        }

        public string GetUsername()
        {
            return Thread.CurrentPrincipal.Identity.GetUserName();
        }
    }
}