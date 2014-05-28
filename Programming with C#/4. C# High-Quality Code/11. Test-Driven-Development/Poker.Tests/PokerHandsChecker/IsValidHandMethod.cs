namespace Poker.Tests.PokerHandsChecker
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Poker.Models;
    using Poker.Models.Enums;
    using Poker.Models.Interfaces;

    [TestClass]
    public class IsValidHandMethod
    {
        private readonly IPokerHandsChecker pokerHandsChecker = new PokerHandsChecker();

        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        public void TestOnHandWithNoCards()
        {
            var handWithNoCards = new Hand(new List<ICard>());
            var expected = false;
            var actual = this.pokerHandsChecker.IsValidHand(handWithNoCards);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        public void TestOnHandWithFiveDifferentCards()
        {
            var handWithFiveDifferentCards = new Hand(new List<ICard>()
            {
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Eight, CardSuit.Diamonds)
            });

            var expected = true;
            var actual = this.pokerHandsChecker.IsValidHand(handWithFiveDifferentCards);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        public void TestOnHandWithSixDifferentCards()
        {
            var handWithSixDifferentCards = new Hand(new List<ICard>()
            {
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Eight, CardSuit.Diamonds),
                new Card(CardFace.Three, CardSuit.Spades)
            });

            var expected = false;
            var actual = this.pokerHandsChecker.IsValidHand(handWithSixDifferentCards);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        public void TestOnHandWithTwoEqualCards()
        {
            var handWithTwoEqualCard = new Hand(new List<ICard>()
            {
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Eight, CardSuit.Diamonds)
            });

            var expected = false;
            var actual = this.pokerHandsChecker.IsValidHand(handWithTwoEqualCard);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        public void TestOnHandWithFiveEqualCards()
        {
            var handWithFiveEqualCards = new Hand(new List<ICard>()
            {
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Clubs)
            });

            var expected = false;
            var actual = this.pokerHandsChecker.IsValidHand(handWithFiveEqualCards);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        public void TestOnHandWithTwoEqualPairOfCards()
        {
            var handWithTwoEqualPairOfCards = new Hand(new List<ICard>()
            {
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Eight, CardSuit.Diamonds)
            });

            var expected = false;
            var actual = this.pokerHandsChecker.IsValidHand(handWithTwoEqualPairOfCards);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        public void TestOnHandWithTwoEqualOfFourCards()
        {
            var handWithTwoEqualOfFourCards = new Hand(new List<ICard>()
            {
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Eight, CardSuit.Diamonds)
            });

            var expected = false;
            var actual = this.pokerHandsChecker.IsValidHand(handWithTwoEqualOfFourCards);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        public void TestOnHandWithTwoEqualOfSixCards()
        {
            var handWithTwoEqualOfSixCards = new Hand(new List<ICard>()
            {
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Eight, CardSuit.Diamonds)
            });

            var expected = false;
            var actual = this.pokerHandsChecker.IsValidHand(handWithTwoEqualOfSixCards);
            Assert.AreEqual(expected, actual);
        }
    }
}