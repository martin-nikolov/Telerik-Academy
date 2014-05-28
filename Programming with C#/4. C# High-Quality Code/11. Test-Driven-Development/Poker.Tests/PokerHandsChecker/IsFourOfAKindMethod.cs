namespace Poker.Tests.PokerHandsChecker
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Poker.Models;
    using Poker.Models.Enums;
    using Poker.Models.Interfaces;
    using Poker.Models.Utils;

    [TestClass]
    public class IsFourOfAKindMethod
    {
        private readonly IPokerHandsChecker pokerHandsChecker = new PokerHandsChecker();

        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        [ExpectedException(typeof(InvalidPokerHandException))]
        public void TestOnHandWithNoCards()
        {
            var handWithNoCards = new Hand(new List<ICard>());
            var expected = false;
            var actual = this.pokerHandsChecker.IsFourOfAKind(handWithNoCards);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        [ExpectedException(typeof(InvalidPokerHandException))]
        public void TestOnHandWithFourDifferentCardsOnEqualSuit()
        {
            var handWithFiveDifferentCardsOnEqualSuit = new Hand(new List<ICard>()
            {
                new Card(CardFace.Ten, CardSuit.Diamonds),
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Eight, CardSuit.Diamonds)
            });

            var expected = false;
            var actual = this.pokerHandsChecker.IsFourOfAKind(handWithFiveDifferentCardsOnEqualSuit);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        [ExpectedException(typeof(InvalidPokerHandException))]
        public void TestOnHandWithThreeEqualOnSuitOfFiveCards()
        {
            var handWithFiveDifferentCardsOnEqualSuit = new Hand(new List<ICard>()
            {
                new Card(CardFace.Six, CardSuit.Clubs),
                new Card(CardFace.Six, CardSuit.Clubs),
                new Card(CardFace.Six, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Clubs),
            });

            var expected = false;
            var actual = this.pokerHandsChecker.IsFourOfAKind(handWithFiveDifferentCardsOnEqualSuit);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        public void TestOnHandWithValidFullHouse()
        {
            var handWithFiveDifferentCardsOnEqualSuit = new Hand(new List<ICard>()
            {
                new Card(CardFace.Six, CardSuit.Clubs),
                new Card(CardFace.Six, CardSuit.Diamonds),
                new Card(CardFace.Six, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Clubs),
            });

            var expected = false;
            var actual = this.pokerHandsChecker.IsFourOfAKind(handWithFiveDifferentCardsOnEqualSuit);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        [ExpectedException(typeof(InvalidPokerHandException))]
        public void TestOnHandWithInvalidFullHouse()
        {
            var handWithFiveDifferentCardsOnEqualSuit = new Hand(new List<ICard>()
            {
                new Card(CardFace.Six, CardSuit.Clubs),
                new Card(CardFace.Six, CardSuit.Clubs),
                new Card(CardFace.Six, CardSuit.Diamonds),
                new Card(CardFace.Six, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Clubs),
            });

            var expected = false;
            var actual = this.pokerHandsChecker.IsFourOfAKind(handWithFiveDifferentCardsOnEqualSuit);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        public void TestOnHandWithOnePair()
        {
            var handWithFiveDifferentCardsOnEqualSuit = new Hand(new List<ICard>()
            {
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.Seven, CardSuit.Hearts),
                new Card(CardFace.Nine, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Clubs),
            });

            var expected = false;
            var actual = this.pokerHandsChecker.IsFourOfAKind(handWithFiveDifferentCardsOnEqualSuit);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        public void TestOnHandWithTwoPair()
        {
            var handWithFiveDifferentCardsOnEqualSuit = new Hand(new List<ICard>()
            {
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.Nine, CardSuit.Hearts),
                new Card(CardFace.Nine, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Clubs),
            });

            var expected = false;
            var actual = this.pokerHandsChecker.IsFourOfAKind(handWithFiveDifferentCardsOnEqualSuit);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        [ExpectedException(typeof(InvalidPokerHandException))]
        public void TestOnHandWithTwoEqualOnSuitOfFiveCards()
        {
            var handWithFiveDifferentCardsOnEqualSuit = new Hand(new List<ICard>()
            {
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.Nine, CardSuit.Hearts),
                new Card(CardFace.Nine, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Clubs),
            });

            var expected = false;
            var actual = this.pokerHandsChecker.IsFourOfAKind(handWithFiveDifferentCardsOnEqualSuit);
            Assert.AreEqual(expected, actual);
        }
   
        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        public void TestOnHandWithThreeOfAKind()
        {
            var handWithFiveDifferentCardsOnEqualSuit = new Hand(new List<ICard>()
            {
                new Card(CardFace.Six, CardSuit.Clubs),
                new Card(CardFace.Six, CardSuit.Diamonds),
                new Card(CardFace.Six, CardSuit.Hearts),
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Clubs),
            });

            var expected = false;
            var actual = this.pokerHandsChecker.IsFourOfAKind(handWithFiveDifferentCardsOnEqualSuit);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        public void TestOnHandWithFourOfAKind()
        {
            var handWithFiveDifferentCardsOnEqualSuit = new Hand(new List<ICard>()
            {
                new Card(CardFace.Six, CardSuit.Clubs),
                new Card(CardFace.Six, CardSuit.Diamonds),
                new Card(CardFace.Six, CardSuit.Hearts),
                new Card(CardFace.Six, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Clubs),
            });

            var expected = true;
            var actual = this.pokerHandsChecker.IsFourOfAKind(handWithFiveDifferentCardsOnEqualSuit);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        public void TestOnHandWithFiveDifferentCardsOnEqualSuit()
        {
            var handWithFiveDifferentCardsOnEqualSuit = new Hand(new List<ICard>()
            {
                new Card(CardFace.Ten, CardSuit.Diamonds),
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Eight, CardSuit.Diamonds)
            });

            var expected = false;
            var actual = this.pokerHandsChecker.IsFourOfAKind(handWithFiveDifferentCardsOnEqualSuit);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        [ExpectedException(typeof(InvalidPokerHandException))]
        public void TestOnHandWithTwoEqualOfFiveCardsOnEqualSuit()
        {
            var handWithTwoEqualOfFiveCardsOnEqualSuit = new Hand(new List<ICard>()
            {
                new Card(CardFace.Ten, CardSuit.Diamonds),
                new Card(CardFace.Ten, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Eight, CardSuit.Diamonds)
            });

            var expected = false;
            var actual = this.pokerHandsChecker.IsFourOfAKind(handWithTwoEqualOfFiveCardsOnEqualSuit);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        [ExpectedException(typeof(InvalidPokerHandException))]
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
            var actual = this.pokerHandsChecker.IsFourOfAKind(handWithSixDifferentCards);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        [ExpectedException(typeof(InvalidPokerHandException))]
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
            var actual = this.pokerHandsChecker.IsFourOfAKind(handWithTwoEqualCard);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        [ExpectedException(typeof(InvalidPokerHandException))]
        public void TestOnHandWithTwoEqualOnSuitCards()
        {
            var handWithTwoEqualCard = new Hand(new List<ICard>()
            {
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Diamonds),
                new Card(CardFace.Ten, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Spades)
            });

            var expected = false;
            var actual = this.pokerHandsChecker.IsFourOfAKind(handWithTwoEqualCard);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        [ExpectedException(typeof(InvalidPokerHandException))]
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
            var actual = this.pokerHandsChecker.IsFourOfAKind(handWithFiveEqualCards);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        [ExpectedException(typeof(InvalidPokerHandException))]
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
            var actual = this.pokerHandsChecker.IsFourOfAKind(handWithTwoEqualPairOfCards);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        [ExpectedException(typeof(InvalidPokerHandException))]
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
            var actual = this.pokerHandsChecker.IsFourOfAKind(handWithTwoEqualOfFourCards);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        [ExpectedException(typeof(InvalidPokerHandException))]
        public void TestOnHandWithTwoEqualOfSixCardsWithDifferentFaces()
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
            var actual = this.pokerHandsChecker.IsFourOfAKind(handWithTwoEqualOfSixCards);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        [ExpectedException(typeof(InvalidPokerHandException))]
        public void TestOnHandWithTwoEqualOfSixCardsOnFiveWithEqualFaces()
        {
            var handWithFiveDifferentCardsOnEqualSuit = new Hand(new List<ICard>()
            {
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Diamonds),
                new Card(CardFace.Ten, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Diamonds)
            });

            var expected = false;
            var actual = this.pokerHandsChecker.IsFourOfAKind(handWithFiveDifferentCardsOnEqualSuit);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        [ExpectedException(typeof(InvalidPokerHandException))]
        public void TestOnHandWithTwoEqualOfSixCardsOnEqualSuit()
        {
            var handWithTwoEqualOfSixCardsOnEqualSuit = new Hand(new List<ICard>()
            {
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Eight, CardSuit.Clubs)
            });

            var expected = false;
            var actual = this.pokerHandsChecker.IsFourOfAKind(handWithTwoEqualOfSixCardsOnEqualSuit);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        public void TestOnHandWithValidStraight_1()
        {
            var handWithFiveDifferentCardsOnEqualSuit = new Hand(new List<ICard>()
            {
                new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.Six, CardSuit.Diamonds),
                new Card(CardFace.Seven, CardSuit.Hearts),
                new Card(CardFace.Eight, CardSuit.Diamonds),
                new Card(CardFace.Nine, CardSuit.Clubs)
            });

            var expected = false;
            var actual = this.pokerHandsChecker.IsFourOfAKind(handWithFiveDifferentCardsOnEqualSuit);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        public void TestOnHandWithValidStraight_2()
        {
            var handWithFiveDifferentCardsOnEqualSuit = new Hand(new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.Four, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Clubs)
            });

            var expected = false;
            var actual = this.pokerHandsChecker.IsFourOfAKind(handWithFiveDifferentCardsOnEqualSuit);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        public void TestOnHandWithValidStraight_3()
        {
            var handWithFiveDifferentCardsOnEqualSuit = new Hand(new List<ICard>()
            {
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Queen, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Clubs)
            });

            var expected = false;
            var actual = this.pokerHandsChecker.IsFourOfAKind(handWithFiveDifferentCardsOnEqualSuit);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        public void TestOnHandWithHighCard_1()
        {
            var handWithTwoEqualOfSixCardsOnEqualSuit = new Hand(new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.Queen, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Spades),
            });

            var expected = false;
            var actual = this.pokerHandsChecker.IsFourOfAKind(handWithTwoEqualOfSixCardsOnEqualSuit);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        public void TestOnHandWithHighCard_2()
        {
            var handWithFiveDifferentCardsOnEqualSuit = new Hand(new List<ICard>()
            {
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Seven, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Clubs)
            });

            var expected = false;
            var actual = this.pokerHandsChecker.IsFourOfAKind(handWithFiveDifferentCardsOnEqualSuit);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        public void TestOnHandWithHighCard_3()
        {
            var handWithTwoEqualOfSixCardsOnEqualSuit = new Hand(new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.Queen, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Spades),
            });

            var expected = false;
            var actual = this.pokerHandsChecker.IsFourOfAKind(handWithTwoEqualOfSixCardsOnEqualSuit);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        public void TestOnHandWithValidStraightFlush_1()
        {
            var handWithFiveDifferentCardsOnEqualSuit = new Hand(new List<ICard>()
            {
                new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.Six, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Clubs),
                new Card(CardFace.Eight, CardSuit.Clubs),
                new Card(CardFace.Nine, CardSuit.Clubs)
            });

            var expected = false;
            var actual = this.pokerHandsChecker.IsFourOfAKind(handWithFiveDifferentCardsOnEqualSuit);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        public void TestOnHandWithValidStraightFlush_2()
        {
            var handWithFiveDifferentCardsOnEqualSuit = new Hand(new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Three, CardSuit.Clubs),
                new Card(CardFace.Four, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Clubs)
            });

            var expected = false;
            var actual = this.pokerHandsChecker.IsFourOfAKind(handWithFiveDifferentCardsOnEqualSuit);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        public void TestOnHandWithValidStraightFlush_3()
        {
            var handWithFiveDifferentCardsOnEqualSuit = new Hand(new List<ICard>()
            {
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Queen, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Clubs)
            });

            var expected = false;
            var actual = this.pokerHandsChecker.IsFourOfAKind(handWithFiveDifferentCardsOnEqualSuit);
            Assert.AreEqual(expected, actual);
        }
    }
}