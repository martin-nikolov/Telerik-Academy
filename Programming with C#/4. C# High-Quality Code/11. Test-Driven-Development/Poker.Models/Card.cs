namespace Poker.Models
{
    using System;
    using Poker.Models.Enums;
    using Poker.Models.Interfaces;
    using Poker.Models.Utils;

    public class Card : ICard
    {
        public Card(CardFace face, CardSuit suit)
        {
            this.Face = face;
            this.Suit = suit;
        }

        public CardFace Face { get; private set; }

        public CardSuit Suit { get; private set; }
     
        public override string ToString()
        {
            var faceToString = EnumExtension.Description(this.Face);
            var siutToString = EnumExtension.Description(this.Suit);
            return faceToString + siutToString;
        }
    }
}