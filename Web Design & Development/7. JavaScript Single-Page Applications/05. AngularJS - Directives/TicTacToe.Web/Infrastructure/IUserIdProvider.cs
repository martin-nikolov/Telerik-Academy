using System;
using System.Linq;

namespace TicTacToe.Web.Infrastructure
{
    public interface IUserInfoProvider
    {
        bool IsUserAuthenticated();

        string GetUsername();

        string GetUserId();
    }
}