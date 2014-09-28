namespace TicTacToe.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public class Score
    {
        [Key]
        public int ScoreId { get; set; }

        [Obsolete("Use ScoreStatus")]
        public bool IsWin { get; set; }

        [ForeignKey("Game")]
        public Guid GameId { get; set; }

        public virtual Game Game { get; set; }

        [Required]
        public Guid PlayerId { get; set; }

        public ScoreStatus ScoreStatus { get; set; }
    }
}