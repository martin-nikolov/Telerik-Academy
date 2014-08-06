namespace Computers.Models.Abstracts
{
    using System;
    using System.Linq;
    using Computers.Models.Contracts;

    public abstract class Computer : Machine, IComputer
    {
        private const int MinValue = 1;
        private const int MaxValue = 10;
        private const string YouWinMessage = "You win!";
        private const string NotGuessedNumberMessage = "You didn't guess the number {0}.";

        public virtual void Play(int guessNumber)
        {
            this.Cpu.SetRandomRamValue(MinValue, MaxValue);
            var numberFromRam = this.Motherboard.LoadRamValue();

            if (numberFromRam != guessNumber)
            {
                this.Motherboard.DrawOnVideoCard(string.Format(NotGuessedNumberMessage, numberFromRam));
            }
            else
            {
                this.Motherboard.DrawOnVideoCard(YouWinMessage);
            }
        }
    }
}