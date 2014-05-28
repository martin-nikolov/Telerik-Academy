namespace Poker.Models.Utils
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Poker.Models.Interfaces;

    public class CardEqualityComparer : IEqualityComparer<ICard>
    {
        public bool Equals(ICard x, ICard y)
        {
            if (x.Face == y.Face && x.Suit == y.Suit)
            {
                return true;
            }

            return false;
        }

        public int GetHashCode(ICard card)
        {
            int hashFace = card.Face.GetHashCode();
            int hashSuit = card.Suit.GetHashCode();

            return hashFace ^ hashSuit;
        }
    }
}