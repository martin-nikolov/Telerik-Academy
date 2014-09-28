namespace TicTacToe.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Game
    {
        private ICollection<Score> score;

        public Game()
        {
            this.GameId = Guid.NewGuid();
            this.Board = "---------";
            this.State = GameState.WaitingForSecondPlayer;
            this.score = new HashSet<Score>();
        }

        public Guid GameId { get; set; }

        [Required]
        [MinLength(1), MaxLength(50)]
        public string Name { get; set; }

        [StringLength(9)]
        [Column(TypeName = "char")]
        public string Board { get; set; }

        public DateTime DateCreated { get; set; }

        public GameState State { get; set; }

        [Required]
        public string FirstPlayerId { get; set; }

        public virtual User FirstPlayer { get; set; }

        public string SecondPlayerId { get; set; }

        public virtual User SecondPlayer { get; set; }

        public virtual ICollection<Score> Scores
        {
            get
            {
                return this.score;
            }
            set
            {
                this.score = value;
            }
        }
    }
}