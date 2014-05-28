namespace Poker.Models.Utils
{
    using System;
    using System.Linq;

    public class InvalidPokerHandException : Exception
    {
        private const string ErrorMessage = "Invalid poker hand. By the poker rules all the cards must be different.";

        public InvalidPokerHandException(string message = ErrorMessage, Exception innerEx = null)
            : base(message, innerEx)
        {
        }
    }
}