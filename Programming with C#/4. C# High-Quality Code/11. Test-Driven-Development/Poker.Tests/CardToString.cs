namespace Poker.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Poker.Models;
    using Poker.Models.Enums;

    [TestClass]
    public class CardToString
    {
        [TestMethod]
        [Description("Test on Card.cs")]
        public void ToStringOfTenOfClubs()
        {
            var tenClubes = new Card(CardFace.Ten, CardSuit.Clubs);
            var expected = "10♣";
            var actual = tenClubes.ToString();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [Description("Test on Card.cs")]
        public void ToStringOfSevenOfDiamonds()
        {
            var sevenDiamonds = new Card(CardFace.Seven, CardSuit.Diamonds);
            var expected = "7♦";
            var actual = sevenDiamonds.ToString();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [Description("Test on Card.cs")]
        public void ToStringOfAceOfHearts()
        {
            var aceHearts = new Card(CardFace.Ace, CardSuit.Hearts);
            var expected = "A♥";
            var actual = aceHearts.ToString();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [Description("Test on Card.cs")]
        public void ToStringOfTwoOfSpades()
        {
            var twoSpades = new Card(CardFace.Two, CardSuit.Spades);
            var expected = "2♠";
            var actual = twoSpades.ToString();

            Assert.AreEqual(expected, actual);
        }
    }
}