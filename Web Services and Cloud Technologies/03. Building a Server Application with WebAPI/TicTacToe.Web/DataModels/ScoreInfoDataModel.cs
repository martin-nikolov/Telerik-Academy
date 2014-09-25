namespace TicTacToe.Web.DataModels
{
    using System;

    public class ScoreInfoDataModel
    {
        public string Username { get; set; }

        public int Wins { get; set; }

        public int Losses { get; set; }

        public int Points { get; set; }
    }
}