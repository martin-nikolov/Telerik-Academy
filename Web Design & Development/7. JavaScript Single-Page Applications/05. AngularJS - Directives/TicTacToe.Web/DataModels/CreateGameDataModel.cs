namespace TicTacToe.Web.DataModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class CreateGameDataModel
    {
        [Required]
        [MinLength(1), MaxLength(50)]
        public string Name { get; set; }
    }
}