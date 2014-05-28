namespace Poker.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Poker.Models.Interfaces;

    public class Hand : IHand
    {
        public Hand(IList<ICard> cards)
        {
            this.Cards = cards;
        }

        public IList<ICard> Cards { get; private set; }

        public override string ToString()
        {
            var output = string.Join(" ", this.Cards);
            return output;
        }
    }
}