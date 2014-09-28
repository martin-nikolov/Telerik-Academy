namespace TicTacToe.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;
    using TicTacToe.Data.Contracts;
    using TicTacToe.Data.UnitOfWork;
    using TicTacToe.Models;
    using TicTacToe.Web.DataModels;

    public class ScoresController : BaseApiController
    {
        public ScoresController()
            : this(new TicTacToeData())
        {
        }

        public ScoresController(ITicTacToeData ticTacToeData)
            : base(ticTacToeData)
        {
        }

        [HttpGet]
        public IQueryable<ScoreInfoDataModel> Top()
        {
            var scores = new List<ScoreInfoDataModel>();
            var users = this.Data.Users
                            .All()
                            .Select(u => new
                            {
                                Id = u.Id,
                                Username = u.UserName
                            })
                            .ToList();

            foreach (var user in users)
            {
                var wins = this.Data.Scores.All().Count(s => s.PlayerId.ToString() == user.Id && s.ScoreStatus == ScoreStatus.Win);
                var losses = this.Data.Scores.All().Count(s => s.PlayerId.ToString() == user.Id && s.ScoreStatus == ScoreStatus.Loss);
                var draws = this.Data.Scores.All().Count(s => s.PlayerId.ToString() == user.Id && s.ScoreStatus == ScoreStatus.Draw);
                scores.Add(new ScoreInfoDataModel()
                {
                    Wins = wins,
                    Losses = losses,
                    Draws = draws,
                    Username = user.Username,
                    Points = 100 * wins + 30 * draws + 15 * losses
                });
            }

            return scores.OrderByDescending(s => s.Points).ThenBy(s => s.Wins).Take(10).AsQueryable();
        }
    }
}