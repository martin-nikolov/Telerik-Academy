namespace TicTacToe.Web.DataModels
{
    using System;
    using TicTacToe.Models;

    public class GameInfoDataModel
    {
        public Guid Id { get; set; }

        public string Board { get; set; }

        public string FirstPlayerName { get; set; }

        public string SecondPlayerName { get; set; }

        public GameState State { get; set; }
    }
}