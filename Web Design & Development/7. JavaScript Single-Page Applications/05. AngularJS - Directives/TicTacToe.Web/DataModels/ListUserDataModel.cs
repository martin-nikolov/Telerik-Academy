namespace TicTacToe.Web.DataModels
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using TicTacToe.Models;

    public class ListUserDataModel
    {
        public static Expression<Func<User, ListUserDataModel>> FromUser
        {
            get
            {
                return user => new ListUserDataModel
                {
                    Username = user.UserName,
                    DateRegistration = user.DateRegistration
                };
            }
        }

        public string Username { get; set; }

        public DateTime DateRegistration { get; set; }
    }
}