namespace TicTacToe.Web.DataModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class GameParamModel
    {
        [Required]
        public string GameId { get; set; }
    }
}