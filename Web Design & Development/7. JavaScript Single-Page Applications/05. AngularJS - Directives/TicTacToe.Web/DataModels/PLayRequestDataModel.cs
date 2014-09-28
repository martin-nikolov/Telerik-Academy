namespace TicTacToe.Web.DataModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class PlayRequestDataModel
    {
        [Required]
        public string GameId { get; set; }

        [Range(1, 3)]
        public int Row { get; set; }

        [Range(1, 3)]
        public int Col { get; set; }
    }
}