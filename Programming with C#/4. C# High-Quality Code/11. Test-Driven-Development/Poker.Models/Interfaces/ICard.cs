using Poker.Models.Enums;

namespace Poker.Models.Interfaces
{
    public interface ICard
    {
        CardFace Face { get; }

        CardSuit Suit { get; }

        string ToString();
    }
}