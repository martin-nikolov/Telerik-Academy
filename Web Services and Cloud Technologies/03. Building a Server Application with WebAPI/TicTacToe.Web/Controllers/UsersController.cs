namespace TicTacToe.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;
    using TicTacToe.Data.Contracts;
    using TicTacToe.Data.UnitOfWork;
    using TicTacToe.Web.DataModels;

    public class UsersController : BaseApiController
    {
        public UsersController()
            : this(new TicTacToeData())
        {
        }

        public UsersController(ITicTacToeData ticTacToeData)
            : base(ticTacToeData)
        {
        }

        [HttpGet]
        public IQueryable<ListUserDataModel> All()
        {
            var users = this.Data.Users
                            .All()
                            .Select(ListUserDataModel.FromUser);
            return users;
        }
    }
}