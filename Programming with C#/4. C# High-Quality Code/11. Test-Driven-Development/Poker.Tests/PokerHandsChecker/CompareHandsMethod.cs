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
    public class CompareHandsMethod
    {
        private readonly IPokerHandsChecker pokerHandsChecker = new PokerHandsChecker();

        private const int LeftIsBigger = 1;
        private const int RightIsBigger = -1;

        #region [Some type of hands - examples]
        
        private readonly IHand handWithNoCards = new Hand(new List<ICard>());

        private readonly IHand handWithHighCard = new Hand(new List<ICard>()
        {
            new Card(CardFace.Ace, CardSuit.Spades),
            new Card(CardFace.King, CardSuit.Diamonds),
            new Card(CardFace.Queen, CardSuit.Clubs),
            new Card(CardFace.Ten, CardSuit.Spades),
            new Card(CardFace.Two, CardSuit.Spades),
        });

        private readonly IHand handWithOnePair = new Hand(new List<ICard>()
        {
            new Card(CardFace.Two, CardSuit.Clubs),
            new Card(CardFace.Two, CardSuit.Diamonds),
            new Card(CardFace.Seven, CardSuit.Spades),
            new Card(CardFace.Nine, CardSuit.Clubs),
            new Card(CardFace.Ten, CardSuit.Clubs),
        });

        private readonly IHand handWithTwoPair = new Hand(new List<ICard>()
        {
            new Card(CardFace.King, CardSuit.Diamonds),
            new Card(CardFace.King, CardSuit.Clubs),
            new Card(CardFace.Nine, CardSuit.Hearts),
            new Card(CardFace.Nine, CardSuit.Diamonds),
            new Card(CardFace.Ace, CardSuit.Spades),
        });

        private readonly IHand handWithThreeOfAKind = new Hand(new List<ICard>()
        {
            new Card(CardFace.Three, CardSuit.Clubs),
            new Card(CardFace.Three, CardSuit.Spades),
            new Card(CardFace.Three, CardSuit.Hearts),
            new Card(CardFace.Seven, CardSuit.Clubs),
            new Card(CardFace.Ace, CardSuit.Clubs),
        });

        private readonly IHand handWithStraight = new Hand(new List<ICard>()
        {
            new Card(CardFace.Five, CardSuit.Clubs),
            new Card(CardFace.Six, CardSuit.Spades),
            new Card(CardFace.Seven, CardSuit.Diamonds),
            new Card(CardFace.Eight, CardSuit.Spades),
            new Card(CardFace.Nine, CardSuit.Clubs)
        });

        private readonly IHand handWithFlush = new Hand(new List<ICard>()
        {
            new Card(CardFace.Ten, CardSuit.Hearts),
            new Card(CardFace.Seven, CardSuit.Hearts),
            new Card(CardFace.Ace, CardSuit.Hearts),
            new Card(CardFace.Two, CardSuit.Hearts),
            new Card(CardFace.Eight, CardSuit.Hearts)
        });

        private readonly IHand handWithFullHouse = new Hand(new List<ICard>()
        {
            new Card(CardFace.Four, CardSuit.Clubs),
            new Card(CardFace.Four, CardSuit.Diamonds),
            new Card(CardFace.Four, CardSuit.Hearts),
            new Card(CardFace.King, CardSuit.Hearts),
            new Card(CardFace.King, CardSuit.Spades),
        });

        private readonly IHand handWithFourOfAKind = new Hand(new List<ICard>()
        {
            new Card(CardFace.Jack, CardSuit.Clubs),
            new Card(CardFace.Jack, CardSuit.Diamonds),
            new Card(CardFace.Jack, CardSuit.Hearts),
            new Card(CardFace.Jack, CardSuit.Spades),
            new Card(CardFace.Ace, CardSuit.Diamonds),
        });

        private readonly IHand handWithStraightFlush = new Hand(new List<ICard>()
        {
            new Card(CardFace.Five, CardSuit.Clubs),
            new Card(CardFace.Six, CardSuit.Clubs),
            new Card(CardFace.Seven, CardSuit.Clubs),
            new Card(CardFace.Eight, CardSuit.Clubs),
            new Card(CardFace.Nine, CardSuit.Clubs)
        });

        #endregion 
        
        #region [Tests -> High card vs. other types]

        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        [ExpectedException(typeof(InvalidPokerHandException))]
        public void TestOnHighCardАgainstNoCards()
        {
            var actual = this.pokerHandsChecker.CompareHands(this.handWithHighCard, this.handWithNoCards);
        }

        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        public void TestOnHighCardАgainstOnePair()
        {
            var actual = this.pokerHandsChecker.CompareHands(this.handWithHighCard, this.handWithOnePair);
            Assert.AreEqual(RightIsBigger, actual);
        }

        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        public void TestOnHighCardАgainstTwoPair()
        {
            var handWithTwoPair = new Hand(new List<ICard>()
            {
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.Nine, CardSuit.Hearts),
                new Card(CardFace.Nine, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Hearts),
            });

            var actual = this.pokerHandsChecker.CompareHands(this.handWithHighCard, handWithTwoPair);
            Assert.AreEqual(RightIsBigger, actual);
        }

        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        public void TestOnHighCardАgainstThreeOfAKind()
        {
            var actual = this.pokerHandsChecker.CompareHands(this.handWithHighCard, this.handWithThreeOfAKind);
            Assert.AreEqual(RightIsBigger, actual);
        }

        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        public void TestOnHighCardАgainstStraight()
        {
            var actual = this.pokerHandsChecker.CompareHands(this.handWithHighCard, this.handWithStraight);
            Assert.AreEqual(RightIsBigger, actual);
        }

        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        public void TestOnHighCardАgainstFlush()
        {
            var actual = this.pokerHandsChecker.CompareHands(this.handWithHighCard, this.handWithFlush);
            Assert.AreEqual(RightIsBigger, actual);
        }

        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        public void TestOnHighCardАgainstFullHouse()
        {
            var actual = this.pokerHandsChecker.CompareHands(this.handWithHighCard, this.handWithFullHouse);
            Assert.AreEqual(RightIsBigger, actual);
        }

        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        public void TestOnHighCardАgainstFourOfAKind()
        {
            var actual = this.pokerHandsChecker.CompareHands(this.handWithHighCard, this.handWithFourOfAKind);
            Assert.AreEqual(RightIsBigger, actual);
        }

        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        public void TestOnHighCardАgainstStraightFlush()
        {
            var actual = this.pokerHandsChecker.CompareHands(this.handWithHighCard, this.handWithStraightFlush);
            Assert.AreEqual(RightIsBigger, actual);
        }

        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        public void TestOnHighCardАgainstUpperHighCard_1()
        {
            var handWithUpperHighCard = new Hand(new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Queen, CardSuit.Spades),
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Three, CardSuit.Spades),
            });

            var actual = this.pokerHandsChecker.CompareHands(this.handWithHighCard, handWithUpperHighCard);
            Assert.AreEqual(RightIsBigger, actual);
        }

        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        public void TestOnHighCardАgainstUpperHighCard_2()
        {
            var handWithUpperHighCard = new Hand(new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Ten, CardSuit.Diamonds),
                new Card(CardFace.Nine, CardSuit.Spades),
                new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.Four, CardSuit.Clubs),
            });

            var handWithLowerHighCard = new Hand(new List<ICard>()
            {
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.Queen, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Eight, CardSuit.Hearts),
                new Card(CardFace.Seven, CardSuit.Hearts),
            });

            var actual = this.pokerHandsChecker.CompareHands(handWithLowerHighCard, handWithUpperHighCard);
            Assert.AreEqual(RightIsBigger, actual);
        }

        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        public void TestOnHighCardАgainstUpperHighCard_3()
        {
            var handWithUpperHighCard = new Hand(new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Queen, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Clubs),
            });

            var handWithLowerHighCard = new Hand(new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Ten, CardSuit.Diamonds),
                new Card(CardFace.Nine, CardSuit.Spades),
                new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.Four, CardSuit.Clubs),
            });

            var actual = this.pokerHandsChecker.CompareHands(handWithUpperHighCard, handWithLowerHighCard);
            Assert.AreEqual(LeftIsBigger, actual);
        }

        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        public void TestOnHighCardАgainstLowerHighCard()
        {
            var handWithLowerHighCard = new Hand(new List<ICard>()
            {
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Queen, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Hearts),
                new Card(CardFace.Eight, CardSuit.Spades),
            });

            var actual = this.pokerHandsChecker.CompareHands(this.handWithHighCard, handWithLowerHighCard);
            Assert.AreEqual(LeftIsBigger, actual);
        }

        #endregion

        #region [Tests -> One pair vs. other types]

        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        [ExpectedException(typeof(InvalidPokerHandException))]
        public void TestOnOnePairАgainstNoCards()
        {
            var actual = this.pokerHandsChecker.CompareHands(this.handWithOnePair, this.handWithNoCards);
        }

        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        public void TestOnOnePairAgainstHighCard()
        {
            var actual = this.pokerHandsChecker.CompareHands(this.handWithOnePair, this.handWithHighCard);
            Assert.AreEqual(LeftIsBigger, actual);
        }

        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        public void TestOnOnePairАgainstTwoPair()
        {
            var actual = this.pokerHandsChecker.CompareHands(this.handWithOnePair, this.handWithTwoPair);
            Assert.AreEqual(RightIsBigger, actual);
        }

        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        public void TestOnOnePairАgainstThreeOfAKind()
        {
            var actual = this.pokerHandsChecker.CompareHands(this.handWithOnePair, this.handWithThreeOfAKind);
            Assert.AreEqual(RightIsBigger, actual);
        }

        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        public void TestOnOnePairАgainstStraight()
        {
            var handWithOnePair = new Hand(new List<ICard>()
            {
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Seven, CardSuit.Spades),
                new Card(CardFace.Nine, CardSuit.Diamonds),
                new Card(CardFace.Ten, CardSuit.Clubs),
            });

            var actual = this.pokerHandsChecker.CompareHands(handWithOnePair, this.handWithStraight);
            Assert.AreEqual(RightIsBigger, actual);
        }

        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        public void TestOnOnePairАgainstFlush()
        {
            var actual = this.pokerHandsChecker.CompareHands(this.handWithOnePair, this.handWithFlush);
            Assert.AreEqual(RightIsBigger, actual);
        }

        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        public void TestOnOnePairАgainstFullHouse()
        {
            var actual = this.pokerHandsChecker.CompareHands(this.handWithOnePair, this.handWithFullHouse);
            Assert.AreEqual(RightIsBigger, actual);
        }

        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        public void TestOnOnePairАgainstFourOfAKind()
        {
            var actual = this.pokerHandsChecker.CompareHands(this.handWithOnePair, this.handWithFourOfAKind);
            Assert.AreEqual(RightIsBigger, actual);
        }

        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        public void TestOnOnePairАgainstStraightFlush()
        {
            var handWithOnePair = new Hand(new List<ICard>()
            {
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Seven, CardSuit.Spades),
                new Card(CardFace.Nine, CardSuit.Diamonds),
                new Card(CardFace.Ten, CardSuit.Clubs),
            });

            var actual = this.pokerHandsChecker.CompareHands(handWithOnePair, this.handWithStraightFlush);
            Assert.AreEqual(RightIsBigger, actual);
        }

        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        public void TestOnOnePairАgainstUpperOnePair_1()
        {
            var handWithUpperOnePair = new Hand(new List<ICard>()
            {
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.Seven, CardSuit.Hearts),
                new Card(CardFace.Nine, CardSuit.Diamonds),
                new Card(CardFace.Queen, CardSuit.Clubs),
            });

            var actual = this.pokerHandsChecker.CompareHands(this.handWithOnePair, handWithUpperOnePair);
            Assert.AreEqual(RightIsBigger, actual);
        }

        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        public void TestOnOnePairАgainstUpperOnePair_2()
        {
            var handWithUpperOnePair = new Hand(new List<ICard>()
            {
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Six, CardSuit.Spades),
                new Card(CardFace.Four, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Hearts),
            });

            var handWithLowerOnePair = new Hand(new List<ICard>()
            {
                new Card(CardFace.Nine, CardSuit.Hearts),
                new Card(CardFace.Nine, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Queen, CardSuit.Diamonds),
                new Card(CardFace.Ten, CardSuit.Diamonds),
            });

            var actual = this.pokerHandsChecker.CompareHands(handWithLowerOnePair, handWithUpperOnePair);
            Assert.AreEqual(RightIsBigger, actual);
        }

        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        public void TestOnOnePairАgainstUpperOnePair_3()
        {
            var handWithUpperOnePair = new Hand(new List<ICard>()
            {
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Eight, CardSuit.Spades),
                new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.Four, CardSuit.Clubs),
            });

            var handWithLowerOnePair = new Hand(new List<ICard>()
            {
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Eight, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Hearts),
                new Card(CardFace.Three, CardSuit.Hearts),
            });

            var actual = this.pokerHandsChecker.CompareHands(handWithUpperOnePair, handWithLowerOnePair);
            Assert.AreEqual(LeftIsBigger, actual);
        }

        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        public void TestOnOnePairАgainstLowerOnePair()
        {
            var handWithUpperOnePair = new Hand(new List<ICard>()
            {
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Hearts),
                new Card(CardFace.Nine, CardSuit.Diamonds),
                new Card(CardFace.Ten, CardSuit.Clubs)
            });

            var handWithLowerOnePair = new Hand(new List<ICard>()
            {
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.Six, CardSuit.Hearts),
                new Card(CardFace.Nine, CardSuit.Spades),
                new Card(CardFace.Ten, CardSuit.Hearts)
            });

            var actual = this.pokerHandsChecker.CompareHands(handWithUpperOnePair, handWithLowerOnePair);
            Assert.AreEqual(LeftIsBigger, actual);
        }

        #endregion

        #region [Tests -> Two pair vs. other types]

        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        [ExpectedException(typeof(InvalidPokerHandException))]
        public void TestOnTwoPairАgainstNoCards()
        {
            var actual = this.pokerHandsChecker.CompareHands(this.handWithTwoPair, this.handWithNoCards);
        }

        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        public void TestOnTwoPairAgainstHighCard()
        {
            var handWithTwoPair = new Hand(new List<ICard>()
            {
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.Nine, CardSuit.Hearts),
                new Card(CardFace.Nine, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Hearts),
            });

            var actual = this.pokerHandsChecker.CompareHands(handWithTwoPair, this.handWithHighCard);
            Assert.AreEqual(LeftIsBigger, actual);
        }

        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        public void TestOnTwoPairAgainstOnePair()
        {
            var actual = this.pokerHandsChecker.CompareHands(this.handWithTwoPair, this.handWithOnePair);
            Assert.AreEqual(LeftIsBigger, actual);
        }

        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        public void TestOnTwoPairАgainstThreeOfAKind()
        {
            var actual = this.pokerHandsChecker.CompareHands(this.handWithTwoPair, this.handWithThreeOfAKind);
            Assert.AreEqual(RightIsBigger, actual);
        }

        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        public void TestOnTwoPairАgainstStraight()
        {
            var actual = this.pokerHandsChecker.CompareHands(this.handWithTwoPair, this.handWithStraight);
            Assert.AreEqual(RightIsBigger, actual);
        }

        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        public void TestOnTwoPairАgainstFlush()
        {
            var actual = this.pokerHandsChecker.CompareHands(this.handWithTwoPair, this.handWithFlush);
            Assert.AreEqual(RightIsBigger, actual);
        }

        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        public void TestOnTwoPairАgainstFullHouse()
        {
            var actual = this.pokerHandsChecker.CompareHands(this.handWithTwoPair, this.handWithFullHouse);
            Assert.AreEqual(RightIsBigger, actual);
        }

        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        public void TestOnTwoPairАgainstFourOfAKind()
        {
            var actual = this.pokerHandsChecker.CompareHands(this.handWithTwoPair, this.handWithFourOfAKind);
            Assert.AreEqual(RightIsBigger, actual);
        }

        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        public void TestOnTwoPairАgainstStraightFlush()
        {
            var actual = this.pokerHandsChecker.CompareHands(this.handWithTwoPair, this.handWithStraightFlush);
            Assert.AreEqual(RightIsBigger, actual);
        }

        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        public void TestOnTwoPairАgainstUpperTwoPair_1()
        {
            var handWithUpperTwoPair = new Hand(new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Nine, CardSuit.Spades),
                new Card(CardFace.Nine, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Spades),
            });

            var actual = this.pokerHandsChecker.CompareHands(this.handWithTwoPair, handWithUpperTwoPair);
            Assert.AreEqual(RightIsBigger, actual);
        }

        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        public void TestOnTwoPairАgainstUpperTwoPair_2()
        {
            var handWithUpperTwoPair = new Hand(new List<ICard>()
            {
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Hearts),
            });

            var handWithLowerTwoPair = new Hand(new List<ICard>()
            {
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Spades),
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Nine, CardSuit.Spades),
            });

            var actual = this.pokerHandsChecker.CompareHands(handWithLowerTwoPair, handWithUpperTwoPair);
            Assert.AreEqual(RightIsBigger, actual);
        }

        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        public void TestOnTwoPairАgainstUpperTwoPair_3()
        {
            var handWithUpperTwoPair = new Hand(new List<ICard>()
            {
                new Card(CardFace.Nine, CardSuit.Clubs),
                new Card(CardFace.Nine, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Hearts),
            });

            var handWithLowerTwoPair = new Hand(new List<ICard>()
            {
                new Card(CardFace.Four, CardSuit.Hearts),
                new Card(CardFace.Four, CardSuit.Spades),
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.Three, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Clubs),
            });

            var actual = this.pokerHandsChecker.CompareHands(handWithUpperTwoPair, handWithLowerTwoPair);
            Assert.AreEqual(LeftIsBigger, actual);
        }

        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        public void TestOnTwoPairАgainstUpperTwoPair_4()
        {
            var handWithUpperTwoPair = new Hand(new List<ICard>()
            {
                new Card(CardFace.Five, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Spades),
                new Card(CardFace.Nine, CardSuit.Clubs),
                new Card(CardFace.Nine, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Hearts),
            });

            var handWithLowerTwoPair = new Hand(new List<ICard>()
            {
                new Card(CardFace.Six, CardSuit.Hearts),
                new Card(CardFace.Six, CardSuit.Spades),
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.Three, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Clubs),
            });

            var actual = this.pokerHandsChecker.CompareHands(handWithUpperTwoPair, handWithLowerTwoPair);
            Assert.AreEqual(LeftIsBigger, actual);
        }

        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        public void TestOnTwoPairАgainstLowerTwoPair()
        {
            var handWithUpperTwoPair = new Hand(new List<ICard>()
            {
                new Card(CardFace.Four, CardSuit.Spades),
                new Card(CardFace.Four, CardSuit.Clubs),
                new Card(CardFace.Three, CardSuit.Spades),
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Diamonds)
            });

            var handWithLowerTwoPair = new Hand(new List<ICard>()
            {
                new Card(CardFace.Four, CardSuit.Hearts),
                new Card(CardFace.Four, CardSuit.Diamonds),
                new Card(CardFace.Three, CardSuit.Diamonds),
                new Card(CardFace.Three, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Spades)
            });

            var actual = this.pokerHandsChecker.CompareHands(handWithUpperTwoPair, handWithLowerTwoPair);
            Assert.AreEqual(LeftIsBigger, actual);
        }
        
        #endregion

        #region [Tests -> Three of a kind vs. other types]
        
        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        [ExpectedException(typeof(InvalidPokerHandException))]
        public void TestOnThreeOfAKindАgainstNoCards()
        {
            var actual = this.pokerHandsChecker.CompareHands(this.handWithThreeOfAKind, this.handWithNoCards);
        }
        
        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        public void TestOnThreeOfAKindAgainstHighCard()
        {
            var actual = this.pokerHandsChecker.CompareHands(this.handWithThreeOfAKind, this.handWithHighCard);
            Assert.AreEqual(LeftIsBigger, actual);
        }
        
        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        public void TestOnThreeOfAKindAgainstOnePair()
        {
            var actual = this.pokerHandsChecker.CompareHands(this.handWithThreeOfAKind, this.handWithOnePair);
            Assert.AreEqual(LeftIsBigger, actual);
        }
        
        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        public void TestOnThreeOfAKindАgainstTwoPair()
        {
            var actual = this.pokerHandsChecker.CompareHands(this.handWithThreeOfAKind, this.handWithTwoPair);
            Assert.AreEqual(LeftIsBigger, actual);
        }
        
        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        public void TestOnThreeOfAKindАgainstStraight()
        {
            var actual = this.pokerHandsChecker.CompareHands(this.handWithThreeOfAKind, this.handWithStraight);
            Assert.AreEqual(RightIsBigger, actual);
        }
        
        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        public void TestOnThreeOfAKindАgainstFlush()
        {
            var actual = this.pokerHandsChecker.CompareHands(this.handWithThreeOfAKind, this.handWithFlush);
            Assert.AreEqual(RightIsBigger, actual);
        }
        
        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        public void TestOnThreeOfAKindАgainstFullHouse()
        {
            var actual = this.pokerHandsChecker.CompareHands(this.handWithThreeOfAKind, this.handWithFullHouse);
            Assert.AreEqual(RightIsBigger, actual);
        }
        
        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        public void TestOnThreeOfAKindАgainstFourOfAKind()
        {
            var actual = this.pokerHandsChecker.CompareHands(this.handWithThreeOfAKind, this.handWithFourOfAKind);
            Assert.AreEqual(RightIsBigger, actual);
        }
        
        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        public void TestOnThreeOfAKindАgainstStraightFlush()
        {
            var handWithThreeOfAKind = new Hand(new List<ICard>()
            {
                new Card(CardFace.Seven, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Seven, CardSuit.Hearts),
                new Card(CardFace.Eight, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Spades),
            });

            var actual = this.pokerHandsChecker.CompareHands(handWithThreeOfAKind, this.handWithStraightFlush);
            Assert.AreEqual(RightIsBigger, actual);
        }

        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        public void TestOnThreeOfAKindАgainstUpperThreeOfAKind()
        {
            var handWithUpperThreeOfAKind = new Hand(new List<ICard>()
            {
                new Card(CardFace.Seven, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Seven, CardSuit.Hearts),
                new Card(CardFace.Eight, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Spades),
            });

            var actual = this.pokerHandsChecker.CompareHands(this.handWithThreeOfAKind, handWithUpperThreeOfAKind);
            Assert.AreEqual(RightIsBigger, actual);
        }

        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        public void TestOnThreeOfAKindАgainstLowerThreeOfAKind()
        {
            var handWithLowerThreeOfAKind = new Hand(new List<ICard>()
            {
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Spades),
            });

            var actual = this.pokerHandsChecker.CompareHands(this.handWithThreeOfAKind, handWithLowerThreeOfAKind);
            Assert.AreEqual(LeftIsBigger, actual);
        }

        #endregion
        
        #region [Tests -> Straight vs. other types]

        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        [ExpectedException(typeof(InvalidPokerHandException))]
        public void TestOnStraightАgainstNoCards()
        {
            var actual = this.pokerHandsChecker.CompareHands(this.handWithStraight, this.handWithNoCards);
        }

        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        public void TestOnStraightAgainstHighCard()
        {
            var actual = this.pokerHandsChecker.CompareHands(this.handWithStraight, this.handWithHighCard);
            Assert.AreEqual(LeftIsBigger, actual);
        }
        
        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        public void TestOnStraightAgainstOnePair()
        {
            var handWithStraight = new Hand(new List<ICard>()
            {
                new Card(CardFace.Five, CardSuit.Diamonds),
                new Card(CardFace.Six, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Eight, CardSuit.Spades),
                new Card(CardFace.Nine, CardSuit.Hearts)
            });

            var actual = this.pokerHandsChecker.CompareHands(handWithStraight, this.handWithOnePair);
            Assert.AreEqual(LeftIsBigger, actual);
        }
        
        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        public void TestOnStraightАgainstTwoPair()
        {
            var actual = this.pokerHandsChecker.CompareHands(this.handWithStraight, this.handWithTwoPair);
            Assert.AreEqual(LeftIsBigger, actual);
        }
        
        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        public void TestOnStraightАgainstThreeOfAKind()
        {
            var actual = this.pokerHandsChecker.CompareHands(this.handWithStraight, this.handWithThreeOfAKind);
            Assert.AreEqual(LeftIsBigger, actual);
        }
        
        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        public void TestOnStraightАgainstFlush()
        {
            var actual = this.pokerHandsChecker.CompareHands(this.handWithStraight, this.handWithFlush);
            Assert.AreEqual(RightIsBigger, actual);
        }
        
        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        public void TestOnStraightАgainstFullHouse()
        {
            var actual = this.pokerHandsChecker.CompareHands(this.handWithStraight, this.handWithFullHouse);
            Assert.AreEqual(RightIsBigger, actual);
        }
        
        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        public void TestOnStraightАgainstFourOfAKind()
        {
            var actual = this.pokerHandsChecker.CompareHands(this.handWithStraight, this.handWithFourOfAKind);
            Assert.AreEqual(RightIsBigger, actual);
        }
        
        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        public void TestOnStraightАgainstStraightFlush()
        {
            var handWithStraight = new Hand(new List<ICard>()
            {
                new Card(CardFace.Five, CardSuit.Diamonds),
                new Card(CardFace.Six, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Eight, CardSuit.Spades),
                new Card(CardFace.Nine, CardSuit.Hearts)
            });

            var actual = this.pokerHandsChecker.CompareHands(handWithStraight, this.handWithStraightFlush);
            Assert.AreEqual(RightIsBigger, actual);
        }

        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        public void TestOnStraightАgainstUpperStraight()
        {
            var handWithUpperStraight = new Hand(new List<ICard>()
            {
                new Card(CardFace.Six, CardSuit.Diamonds),
                new Card(CardFace.Seven, CardSuit.Hearts),
                new Card(CardFace.Eight, CardSuit.Diamonds),
                new Card(CardFace.Nine, CardSuit.Spades),
                new Card(CardFace.Ten, CardSuit.Clubs)
            });

            var actual = this.pokerHandsChecker.CompareHands(this.handWithStraight, handWithUpperStraight);
            Assert.AreEqual(RightIsBigger, actual);
        }

        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        public void TestOnStraightАgainstLowerStraight()
        {
            var handWithLowerStraight = new Hand(new List<ICard>()
            {
                new Card(CardFace.Four, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Hearts),
                new Card(CardFace.Six, CardSuit.Diamonds),
                new Card(CardFace.Seven, CardSuit.Clubs),
                new Card(CardFace.Eight, CardSuit.Clubs)
            });

            var actual = this.pokerHandsChecker.CompareHands(this.handWithStraight, handWithLowerStraight);
            Assert.AreEqual(LeftIsBigger, actual);
        }

        #endregion
        
        #region [Tests -> Flush vs. other types]

        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        [ExpectedException(typeof(InvalidPokerHandException))]
        public void TestOnFlushАgainstNoCards()
        {
            var actual = this.pokerHandsChecker.CompareHands(this.handWithFlush, this.handWithNoCards);
        }

        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        public void TestOnFlushAgainstHighCard()
        {
            var actual = this.pokerHandsChecker.CompareHands(this.handWithFlush, this.handWithHighCard);
            Assert.AreEqual(LeftIsBigger, actual);
        }
        
        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        public void TestOnFlushAgainstOnePair()
        {
            var actual = this.pokerHandsChecker.CompareHands(this.handWithFlush, this.handWithOnePair);
            Assert.AreEqual(LeftIsBigger, actual);
        }
        
        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        public void TestOnFlushАgainstTwoPair()
        {
            var actual = this.pokerHandsChecker.CompareHands(this.handWithFlush, this.handWithTwoPair);
            Assert.AreEqual(LeftIsBigger, actual);
        }
        
        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        public void TestOnFlushАgainstThreeOfAKind()
        {
            var actual = this.pokerHandsChecker.CompareHands(this.handWithFlush, this.handWithThreeOfAKind);
            Assert.AreEqual(LeftIsBigger, actual);
        }
        
        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        public void TestOnFlushАgainstStraight()
        {
            var actual = this.pokerHandsChecker.CompareHands(this.handWithFlush, this.handWithStraight);
            Assert.AreEqual(LeftIsBigger, actual);
        }
        
        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        public void TestOnFlushАgainstFullHouse()
        {
            var actual = this.pokerHandsChecker.CompareHands(this.handWithFlush, this.handWithFullHouse);
            Assert.AreEqual(RightIsBigger, actual);
        }
        
        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        public void TestOnFlushАgainstFourOfAKind()
        {
            var actual = this.pokerHandsChecker.CompareHands(this.handWithFlush, this.handWithFourOfAKind);
            Assert.AreEqual(RightIsBigger, actual);
        }
        
        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        public void TestOnFlushАgainstStraightFlush()
        {
            var actual = this.pokerHandsChecker.CompareHands(this.handWithFlush, this.handWithStraightFlush);
            Assert.AreEqual(RightIsBigger, actual);
        }

        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        public void TestOnFlushАgainstUpperFlush_1()
        {
            var handWithUpperFlush = new Hand(new List<ICard>()
            {
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Eight, CardSuit.Spades)
            });

            var actual = this.pokerHandsChecker.CompareHands(this.handWithFlush, handWithUpperFlush);
            Assert.AreEqual(RightIsBigger, actual);
        }

        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        public void TestOnFlushАgainstUpperFlush_2()
        {
            var handWithUpperFlush = new Hand(new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Queen, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Hearts),
                new Card(CardFace.Five, CardSuit.Hearts),
                new Card(CardFace.Three, CardSuit.Hearts)
            });

            var handWithLowerFlush = new Hand(new List<ICard>()
            {
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Queen, CardSuit.Spades),
                new Card(CardFace.Jack, CardSuit.Spades),
                new Card(CardFace.Nine, CardSuit.Spades),
                new Card(CardFace.Six, CardSuit.Spades)
            });

            var actual = this.pokerHandsChecker.CompareHands(handWithLowerFlush, handWithUpperFlush);
            Assert.AreEqual(RightIsBigger, actual);
        }

        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        public void TestOnFlushАgainstUpperFlush_3()
        {
            var handWithUpperFlush = new Hand(new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Six, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Diamonds)
            });

            var handWithLowerFlush = new Hand(new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Queen, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Hearts),
                new Card(CardFace.Five, CardSuit.Hearts),
                new Card(CardFace.Three, CardSuit.Hearts)
            });

            var actual = this.pokerHandsChecker.CompareHands(handWithUpperFlush, handWithLowerFlush);
            Assert.AreEqual(LeftIsBigger, actual);
        }

        #endregion
        
        #region [Tests -> Full House vs. other types]

        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        [ExpectedException(typeof(InvalidPokerHandException))]
        public void TestOnFullHouseАgainstNoCards()
        {
            var actual = this.pokerHandsChecker.CompareHands(this.handWithFullHouse, this.handWithNoCards);
        }

        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        public void TestOnFullHouseAgainstHighCard()
        {
            var actual = this.pokerHandsChecker.CompareHands(this.handWithFullHouse, this.handWithHighCard);
            Assert.AreEqual(LeftIsBigger, actual);
        }
        
        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        public void TestOnFullHouseAgainstOnePair()
        {
            var actual = this.pokerHandsChecker.CompareHands(this.handWithFullHouse, this.handWithOnePair);
            Assert.AreEqual(LeftIsBigger, actual);
        }
        
        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        public void TestOnFullHouseАgainstTwoPair()
        {
            var actual = this.pokerHandsChecker.CompareHands(this.handWithFullHouse, this.handWithTwoPair);
            Assert.AreEqual(LeftIsBigger, actual);
        }
        
        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        public void TestOnFullHouseАgainstThreeOfAKind()
        {
            var actual = this.pokerHandsChecker.CompareHands(this.handWithFullHouse, this.handWithThreeOfAKind);
            Assert.AreEqual(LeftIsBigger, actual);
        }
        
        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        public void TestOnFullHouseАgainstStraight()
        {
            var actual = this.pokerHandsChecker.CompareHands(this.handWithFullHouse, this.handWithStraight);
            Assert.AreEqual(LeftIsBigger, actual);
        }
        
        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        public void TestOnFullHouseАgainstFlush()
        {
            var actual = this.pokerHandsChecker.CompareHands(this.handWithFullHouse, this.handWithFlush);
            Assert.AreEqual(LeftIsBigger, actual);
        }
        
        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        public void TestOnFullHouseАgainstFourOfAKind()
        {
            var actual = this.pokerHandsChecker.CompareHands(this.handWithFullHouse, this.handWithFourOfAKind);
            Assert.AreEqual(RightIsBigger, actual);
        }
        
        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        public void TestOnFullHouseАgainstStraightFlush()
        {
            var actual = this.pokerHandsChecker.CompareHands(this.handWithFullHouse, this.handWithStraightFlush);
            Assert.AreEqual(RightIsBigger, actual);
        }

        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        public void TestOnFullHouseАgainstUpperFullHouse()
        {
            var handWithUpperFullHouse = new Hand(new List<ICard>()
            {
                new Card(CardFace.Seven, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Seven, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Clubs),
            });

            var actual = this.pokerHandsChecker.CompareHands(this.handWithFullHouse, handWithUpperFullHouse);
            Assert.AreEqual(RightIsBigger, actual);
        }

        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        public void TestOnFullHouseАgainstLowerFullHouse()
        {
            var handWithUpperFullHouse = new Hand(new List<ICard>()
            {
                new Card(CardFace.Three, CardSuit.Clubs),
                new Card(CardFace.Three, CardSuit.Diamonds),
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Clubs),
            });

            var actual = this.pokerHandsChecker.CompareHands(this.handWithFullHouse, handWithUpperFullHouse);
            Assert.AreEqual(LeftIsBigger, actual);
        }

        #endregion
        
        #region [Tests -> Four of a kind vs. other types]

        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        [ExpectedException(typeof(InvalidPokerHandException))]
        public void TestOnFourOfAKindАgainstNoCards()
        {
            var actual = this.pokerHandsChecker.CompareHands(this.handWithFourOfAKind, this.handWithNoCards);
        }

        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        public void TestOnFourOfAKindAgainstHighCard()
        {
            var actual = this.pokerHandsChecker.CompareHands(this.handWithFourOfAKind, this.handWithHighCard);
            Assert.AreEqual(LeftIsBigger, actual);
        }
        
        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        public void TestOnFourOfAKindAgainstOnePair()
        {
            var actual = this.pokerHandsChecker.CompareHands(this.handWithFourOfAKind, this.handWithOnePair);
            Assert.AreEqual(LeftIsBigger, actual);
        }
        
        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        public void TestOnFourOfAKindАgainstTwoPair()
        {
            var actual = this.pokerHandsChecker.CompareHands(this.handWithFourOfAKind, this.handWithTwoPair);
            Assert.AreEqual(LeftIsBigger, actual);
        }
        
        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        public void TestOnFourOfAKindАgainstThreeOfAKind()
        {
            var actual = this.pokerHandsChecker.CompareHands(this.handWithFourOfAKind, this.handWithThreeOfAKind);
            Assert.AreEqual(LeftIsBigger, actual);
        }
        
        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        public void TestOnFourOfAKindАgainstStraight()
        {
            var actual = this.pokerHandsChecker.CompareHands(this.handWithFourOfAKind, this.handWithStraight);
            Assert.AreEqual(LeftIsBigger, actual);
        }
        
        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        public void TestOnFourOfAKindАgainstFlush()
        {
            var actual = this.pokerHandsChecker.CompareHands(this.handWithFourOfAKind, this.handWithFlush);
            Assert.AreEqual(LeftIsBigger, actual);
        }
        
        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        public void TestOnFourOfAKindАgainstFullHouse()
        {
            var actual = this.pokerHandsChecker.CompareHands(this.handWithFourOfAKind, this.handWithFullHouse);
            Assert.AreEqual(LeftIsBigger, actual);
        }
        
        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        public void TestOnFourOfAKindАgainstStraightFlush()
        {
            var actual = this.pokerHandsChecker.CompareHands(this.handWithFourOfAKind, this.handWithStraightFlush);
            Assert.AreEqual(RightIsBigger, actual);
        }

        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        public void TestOnFourOfAKindАgainstUpperFourOfAKind()
        {
            var handWithUpperFourOfAKind = new Hand(new List<ICard>()
            {
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Clubs),
            });

            var actual = this.pokerHandsChecker.CompareHands(this.handWithFourOfAKind, handWithUpperFourOfAKind);
            Assert.AreEqual(RightIsBigger, actual);
        }

        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        public void TestOnFourOfAKindАgainstLowerFourOfAKind()
        {
            var handWithLowerFourOfAKind = new Hand(new List<ICard>()
            {
                new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Hearts),
                new Card(CardFace.Five, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Clubs),
            });

            var actual = this.pokerHandsChecker.CompareHands(this.handWithFourOfAKind, handWithLowerFourOfAKind);
            Assert.AreEqual(LeftIsBigger, actual);
        }

        #endregion
        
        #region [Tests -> Straight Flush vs. other types]

        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        [ExpectedException(typeof(InvalidPokerHandException))]
        public void TestOnStraightFlushАgainstNoCards()
        {
            var actual = this.pokerHandsChecker.CompareHands(this.handWithStraightFlush, this.handWithNoCards);
        }

        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        public void TestOnStraightFlushAgainstHighCard()
        {
            var actual = this.pokerHandsChecker.CompareHands(this.handWithStraightFlush, this.handWithHighCard);
            Assert.AreEqual(LeftIsBigger, actual);
        }
        
        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        public void TestOnStraightFlushAgainstOnePair()
        {
            var handWithOnePair = new Hand(new List<ICard>()
            {
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Seven, CardSuit.Hearts),
                new Card(CardFace.Nine, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Hearts),
            });

            var actual = this.pokerHandsChecker.CompareHands(this.handWithStraightFlush, handWithOnePair);
            Assert.AreEqual(LeftIsBigger, actual);
        }
        
        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        public void TestOnStraightFlushАgainstTwoPair()
        {
            var actual = this.pokerHandsChecker.CompareHands(this.handWithStraightFlush, this.handWithTwoPair);
            Assert.AreEqual(LeftIsBigger, actual);
        }
        
        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        public void TestOnStraightFlushАgainstThreeOfAKind()
        {
            var handWithStraightFlush = new Hand(new List<ICard>()
            {
                new Card(CardFace.Six, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Spades),
                new Card(CardFace.Eight, CardSuit.Spades),
                new Card(CardFace.Nine, CardSuit.Spades),
                new Card(CardFace.Ten, CardSuit.Spades)
            });

            var actual = this.pokerHandsChecker.CompareHands(handWithStraightFlush, this.handWithThreeOfAKind);
            Assert.AreEqual(LeftIsBigger, actual);
        }
        
        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        public void TestOnStraightFlushАgainstStraight()
        {
            var handWithStraight = new Hand(new List<ICard>()
            {
                new Card(CardFace.Five, CardSuit.Diamonds),
                new Card(CardFace.Six, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Eight, CardSuit.Spades),
                new Card(CardFace.Nine, CardSuit.Spades)
            });

            var actual = this.pokerHandsChecker.CompareHands(this.handWithStraightFlush, handWithStraight);
            Assert.AreEqual(LeftIsBigger, actual);
        }
        
        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        public void TestOnStraightFlushАgainstFlush()
        {
            var actual = this.pokerHandsChecker.CompareHands(this.handWithStraightFlush, this.handWithFlush);
            Assert.AreEqual(LeftIsBigger, actual);
        }
        
        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        public void TestOnStraightFlushАgainstFullHouse()
        {
            var actual = this.pokerHandsChecker.CompareHands(this.handWithStraightFlush, this.handWithFullHouse);
            Assert.AreEqual(LeftIsBigger, actual);
        }
        
        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        public void TestOnStraightFlushАgainstFourOfAKind()
        {
            var actual = this.pokerHandsChecker.CompareHands(this.handWithStraightFlush, this.handWithFourOfAKind);
            Assert.AreEqual(LeftIsBigger, actual);
        }

        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        public void TestOnStraightFlushАgainstUpperStraightFlush()
        {
            var handWithUpperStraightFlush = new Hand(new List<ICard>()
            {
                new Card(CardFace.Six, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Spades),
                new Card(CardFace.Eight, CardSuit.Spades),
                new Card(CardFace.Nine, CardSuit.Spades),
                new Card(CardFace.Ten, CardSuit.Spades)
            });

            var actual = this.pokerHandsChecker.CompareHands(this.handWithStraightFlush, handWithUpperStraightFlush);
            Assert.AreEqual(RightIsBigger, actual);
        }

        [TestMethod]
        [Description("Test on PokerHandsChecker.cs")]
        public void TestOnStraightFlushАgainstLowerStraightFlush()
        {
            var handWithLowerStraightFlush = new Hand(new List<ICard>()
            {
                new Card(CardFace.Four, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Diamonds),
                new Card(CardFace.Six, CardSuit.Diamonds),
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Eight, CardSuit.Diamonds),
            });

            var actual = this.pokerHandsChecker.CompareHands(this.handWithStraightFlush, handWithLowerStraightFlush);
            Assert.AreEqual(LeftIsBigger, actual);
        }
        
        #endregion
    }
}