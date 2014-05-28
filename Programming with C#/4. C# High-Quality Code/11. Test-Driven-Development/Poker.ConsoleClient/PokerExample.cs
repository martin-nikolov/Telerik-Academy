/*
 * 1. Write a class Card implementing the ICard interface. 
 * Implement the properties. Write a constructor. 
 * Implement the ToString() method. 
 * Test all cases.
 * 
 * 2. Write a class Hand implementing the IHand interface. 
 * Implement the properties. Write a constructor. 
 * Implement the ToString() method. 
 * Test all cases.
 * 
 * 3. Write a class PokerHandsChecker (+ tests) and start 
 * implementing the IPokerHandsChecker interface. 
 * Implement the IsValidHand(IHand). 
 * A hand is valid when it consists of exactly 5 different cards.
 */

namespace Poker.ConsoleClient
{
    using System;
    using System.Collections.Generic;
    using Poker.Models;
    using Poker.Models.Enums;
    using Poker.Models.Interfaces;

    internal class PokerExample
    {
        internal static void Main()
        {
            ICard card = new Card(CardFace.Ace, CardSuit.Clubs);
            Console.WriteLine(card);

            IHand hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Five, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Spades),
                new Card(CardFace.Nine, CardSuit.Clubs),
                new Card(CardFace.Nine, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Hearts),
            });
            Console.WriteLine(hand);

            IHand otherHand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Six, CardSuit.Hearts),
                new Card(CardFace.Six, CardSuit.Spades),
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.Three, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Clubs),
            });
            Console.WriteLine(otherHand);

            IPokerHandsChecker checker = new PokerHandsChecker();
            Console.WriteLine(checker.IsStraightFlush(hand));
            Console.WriteLine(checker.IsStraight(hand));
            Console.WriteLine(checker.IsThreeOfAKind(hand));
            Console.WriteLine(checker.IsFlush(hand));
            Console.WriteLine(checker.IsOnePair(hand));
            Console.WriteLine(checker.IsTwoPair(hand));

            Console.WriteLine(checker.CompareHands(hand, otherHand));
        }
    }
}