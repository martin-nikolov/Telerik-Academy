namespace Poker.Tests
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Poker.Models;
    using Poker.Models.Enums;
    using Poker.Models.Interfaces;

    [TestClass]
    public class HandToString
    {
        [TestMethod]
        [Description("Test on Hand.cs")]
        public void ToStringHandWithNoCards()
        {
            var emptyHand = new Hand(new List<ICard>());
            var expected = string.Empty;
            var actual = emptyHand.ToString();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [Description("Test on Hand.cs")]
        public void ToStringHandWithOneCardTenOfClubs()
        {
            var handWithOneCardTenOfClubs = new Hand(new List<ICard>()
            {
                new Card(CardFace.Ten, CardSuit.Clubs)
            });

            var expected = "10♣";
            var actual = handWithOneCardTenOfClubs.ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [Description("Test on Hand.cs")]
        public void ToStringHandWithFiveCards()
        {
            var handWithFiveCards = new Hand(new List<ICard>()
            {
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Eight, CardSuit.Diamonds)
            });

            var expected = "10♣ 7♦ A♥ 2♠ 8♦";
            var actual = handWithFiveCards.ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [Description("Test on Hand.cs")]
        public void ToStringHandWithSameCards()
        {
            var handWithFiveCards = new Hand(new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Hearts)
            });

            var expected = "A♥ A♥ A♥ A♥";
            var actual = handWithFiveCards.ToString();
            Assert.AreEqual(expected, actual);
        }
    }
}