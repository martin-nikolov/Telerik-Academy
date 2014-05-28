namespace Poker.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Poker.Models.Enums;
    using Poker.Models.Interfaces;
    using Poker.Models.Utils;

    public class PokerHandsChecker : IPokerHandsChecker
    {
        public bool IsValidHand(IHand hand)
        {
            var handWithUniqueCards = this.GetHandWithUniqueCards(hand);
            var areAllCardsDifferent = this.IsValidHand(handWithUniqueCards, hand);
            return areAllCardsDifferent;
        }

        public bool IsFlush(IHand hand)
        {
            var handType = this.TryGetHandTypeOrThrowException(hand);
            return handType == HandType.Flush;
        }

        public bool IsThreeOfAKind(IHand hand)
        {
            var handType = this.TryGetHandTypeOrThrowException(hand);
            return handType == HandType.ThreeOfAKind;
        }

        public bool IsFourOfAKind(IHand hand)
        {
            var handType = this.TryGetHandTypeOrThrowException(hand);
            return handType == HandType.FourOfAKind;
        }

        public bool IsOnePair(IHand hand)
        {
            var handType = this.TryGetHandTypeOrThrowException(hand);
            return handType == HandType.OnePair;
        }

        public bool IsTwoPair(IHand hand)
        {
            var handType = this.TryGetHandTypeOrThrowException(hand);
            return handType == HandType.TwoPair;
        }

        public bool IsFullHouse(IHand hand)
        {
            var handType = this.TryGetHandTypeOrThrowException(hand);
            return handType == HandType.FullHouse;
        }

        public bool IsStraightFlush(IHand hand)
        {
            var handType = this.TryGetHandTypeOrThrowException(hand);
            return handType == HandType.StraightFlush;
        }

        public bool IsStraight(IHand hand)
        {
            var handType = this.TryGetHandTypeOrThrowException(hand);
            return handType == HandType.Straight;
        }

        public bool IsHighCard(IHand hand)
        {
            var handType = this.TryGetHandTypeOrThrowException(hand);
            return handType == HandType.HighCard;
        }

        public int CompareHands(IHand firstHand, IHand secondHand)
        {
            var firstHandType = this.TryGetHandTypeOrThrowException(firstHand);
            var secondHandType = this.TryGetHandTypeOrThrowException(secondHand);
            var comparisonResult = 0;

            if (!this.AreValidPokerHands(firstHand, secondHand))
            {
                throw new InvalidPokerHandException("Two poker hands cannot contain a common card.");
            }

            if (firstHandType > secondHandType)
            {
                comparisonResult = 1;
            }
            else if (firstHandType < secondHandType)
            {
                comparisonResult = -1;
            }
            else if (firstHandType == HandType.OnePair)
            {
                var firstGroupedByFace = firstHand.Cards.GroupBy(c => c.Face).OrderByDescending(g => g.Count()).ToArray();
                var secondGroupedByFace = secondHand.Cards.GroupBy(c => c.Face).OrderByDescending(g => g.Count()).ToArray();

                comparisonResult = firstGroupedByFace[0].First().Face.CompareTo(secondGroupedByFace[0].First().Face);

                if (comparisonResult == 0)
                {
                    var firstOtherCards = firstGroupedByFace.Skip(1).Select(g => g.First()).OrderByDescending(c => c.Face).ToArray();
                    var secondOtherCards = secondGroupedByFace.Skip(1).Select(g => g.First()).OrderByDescending(c => c.Face).ToArray();

                    for (int i = 0; i < firstOtherCards.Length; i++)
                    {
                        var comparison = firstOtherCards[i].Face.CompareTo(secondOtherCards[i].Face);
                        if (comparison != 0)
                        {
                            comparisonResult = comparison;
                            break;
                        }
                    }
                }
            }
            else if (firstHandType == HandType.TwoPair)
            {
                var firstGroupedByFace = firstHand.Cards.GroupBy(c => c.Face).OrderByDescending(g => g.Count()).ToArray();
                var secondGroupedByFace = secondHand.Cards.GroupBy(c => c.Face).OrderByDescending(g => g.Count()).ToArray();

                var firstHandCards = new List<ICard>();
                firstHandCards.Add(firstGroupedByFace[0].First());
                firstHandCards.Add(firstGroupedByFace[1].First());
                firstHandCards = firstHandCards.OrderByDescending(c => c.Face).ToList();
                firstHandCards.Add(firstGroupedByFace[2].First());

                var secondHandCards = new List<ICard>();
                secondHandCards.Add(secondGroupedByFace[0].First());
                secondHandCards.Add(secondGroupedByFace[1].First());
                secondHandCards = secondHandCards.OrderByDescending(c => c.Face).ToList();
                secondHandCards.Add(secondGroupedByFace[2].First());

                comparisonResult = firstHandCards[0].Face.CompareTo(secondHandCards[0].Face);

                if (comparisonResult == 0)
                {
                    comparisonResult = firstHandCards[1].Face.CompareTo(secondHandCards[1].Face);

                    if (comparisonResult == 0)
                    {
                        comparisonResult = firstHandCards[2].Face.CompareTo(secondHandCards[2].Face);
                    }
                }
            }
            else if (firstHandType == HandType.FullHouse)
            {
                var firstGroupedByFace = firstHand.Cards.GroupBy(c => c.Face).OrderByDescending(g => g.Count()).ToArray();
                var secondGroupedByFace = secondHand.Cards.GroupBy(c => c.Face).OrderByDescending(g => g.Count()).ToArray();

                comparisonResult = firstGroupedByFace[0].First().Face.CompareTo(secondGroupedByFace[0].First().Face);
            }
            else if (firstHandType == HandType.Flush || firstHandType == HandType.HighCard)
            {
                var firstSortedByFace = firstHand.Cards.OrderByDescending(c => c.Face).ToArray();
                var secondSortedByFace = secondHand.Cards.OrderByDescending(c => c.Face).ToArray();

                for (int i = 0; i < firstSortedByFace.Length; i++)
                {
                    var comparison = firstSortedByFace[i].Face.CompareTo(secondSortedByFace[i].Face);
                    if (comparison != 0)
                    {
                        comparisonResult = comparison;
                        break;
                    }
                }
            }
            else if (firstHandType == HandType.ThreeOfAKind || firstHandType == HandType.FourOfAKind)
            {
                var firstGroupedByFace = firstHand.Cards.GroupBy(c => c.Face).OrderByDescending(g => g.Count()).ToArray();
                var secondGroupedByFace = secondHand.Cards.GroupBy(c => c.Face).OrderByDescending(g => g.Count()).ToArray();

                comparisonResult = firstGroupedByFace[0].First().Face.CompareTo(secondGroupedByFace[0].First().Face);
            }
            else if (firstHandType == HandType.Straight || firstHandType == HandType.StraightFlush)
            {
                var firstSortedByFace = firstHand.Cards.OrderByDescending(c => c.Face).ToArray();
                var secondSortedByFace = secondHand.Cards.OrderByDescending(c => c.Face).ToArray();

                comparisonResult = firstSortedByFace[0].Face.CompareTo(secondSortedByFace[0].Face);
            }

            return comparisonResult;
        }

        private HandType TryGetHandTypeOrThrowException(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                throw new InvalidPokerHandException();
            }

            var handWithUniqueCards = this.GetHandWithUniqueCards(hand);
            var groupedByCardFace = handWithUniqueCards.GroupBy(c => c.Face)
                                                       .OrderByDescending(g => g.Count())
                                                       .ToArray();

            if (groupedByCardFace.Length == 2)
            {
                if (groupedByCardFace[0].Count() == 4)
                {
                    return HandType.FourOfAKind;
                }
                else if (groupedByCardFace[0].Count() == 3 && groupedByCardFace[1].Count() == 2)
                {
                    return HandType.FullHouse;
                }
            }
            else if (groupedByCardFace.Length == 3)
            {
                if (groupedByCardFace[0].Count() == 3)
                {
                    return HandType.ThreeOfAKind;
                }
                else if (groupedByCardFace[0].Count() == 2 && groupedByCardFace[1].Count() == 2)
                {
                    return HandType.TwoPair;
                }
            }
            else if (groupedByCardFace.Length == 4)
            {
                return HandType.OnePair;
            }

            var isFlush = handWithUniqueCards.Select(c => c.Suit).Distinct().Count() == 1;
            var isStraight = this.IsStraight(handWithUniqueCards);

            if (isFlush && isStraight)
            {
                return HandType.StraightFlush;
            }
            else if (isFlush)
            {
                return HandType.Flush;
            }
            else if (isStraight)
            {
                return HandType.Straight;
            }
            else
            {
                return HandType.HighCard;
            }
        }

        private bool IsStraight(IEnumerable<ICard> handWithUniqueCards)
        {
            var cardsSortedByFace = handWithUniqueCards.ToArray();
            Array.Sort(cardsSortedByFace, ((a, b) => a.Face.CompareTo(b.Face)));

            bool isStraight = cardsSortedByFace[cardsSortedByFace.Length - 1].Face - cardsSortedByFace[0].Face == 4 ||
                              (cardsSortedByFace[cardsSortedByFace.Length - 1].Face == CardFace.Ace &&
                               cardsSortedByFace[cardsSortedByFace.Length - 2].Face == CardFace.Five);
            return isStraight;
        }

        private IEnumerable<ICard> GetHandWithUniqueCards(IHand hand, bool orderByFaceThenBySuit = false)
        {
            var handWithUniqueCards = hand.Cards.Distinct(new CardEqualityComparer());

            if (orderByFaceThenBySuit)
            {
                handWithUniqueCards = handWithUniqueCards.OrderBy(c => c.Face).ThenBy(a => a.Suit);
            }

            return handWithUniqueCards;
        }

        private bool IsValidHand(IEnumerable<ICard> handWithUniqueCards, IHand hand)
        {
            var isValidHand = handWithUniqueCards.Count() == 5 && handWithUniqueCards.Count() == hand.Cards.Count;
            return isValidHand;
        }

        private bool AreValidPokerHands(IHand firstHand, IHand secondHand)
        {
            var firstHandCards = this.GetHandWithUniqueCards(firstHand);
            var secondHandCards = this.GetHandWithUniqueCards(secondHand);
            var areValidPokerHands = true;

            foreach (var card in firstHandCards)
            {
                if (secondHandCards.Contains(card, new CardEqualityComparer()))
                {
                    areValidPokerHands = false;
                    break;
                }
            }

            return areValidPokerHands;
        }
    }
}