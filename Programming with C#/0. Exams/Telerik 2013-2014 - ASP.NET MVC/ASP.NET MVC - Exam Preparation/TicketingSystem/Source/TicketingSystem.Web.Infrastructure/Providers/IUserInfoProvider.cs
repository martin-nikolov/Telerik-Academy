namespace TicketingSystem.Web.Infrastructure.Providers
{
    public interface IUserInfoProvider
    {
        string GetUserId();

        string GetUsername();
    }
}