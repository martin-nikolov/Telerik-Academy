namespace TicTacToe.Web.DataModels
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using TicTacToe.Models;

    public class ListGameDataModel
    {
        public static Expression<Func<Game, ListGameDataModel>> FromGame
        {
            get
            {
                return game => new ListGameDataModel
                {
                    Id = game.GameId,
                    Name = game.Name,
                    Creator = game.FirstPlayer.UserName,
                    Opponent = game.SecondPlayer.UserName,
                    DateCreated = game.DateCreated,
                    Status = game.State
                };
            }
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Creator { get; set; }

        public string Opponent { get; set; }

        public GameState Status { get; set; }

        public DateTime DateCreated { get; set; }
    }
}