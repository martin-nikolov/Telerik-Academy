namespace LinearDataStructures.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class LongestSubsequenceOfEqualsTests
    {
        [TestMethod]
        public void ShouldReturnLastLongestSubsequence_1()
        {
            var collection = new List<int>() { 1, 1, 1, 2, 2, 3, 3, 3 };
            var longestSubsequence = LongestSubsequenceOfEquals.FindLongestSubsequence(collection).ToList();
            var expectedLongestSubsequence = new List<int>() { 3, 3, 3 };

            CollectionAssert.AreEqual(expectedLongestSubsequence, longestSubsequence);
        }

        [TestMethod]
        public void ShouldReturnLastLongestSubsequence_2()
        {
            var collection = new List<int>() { 1, 1, 1, 1, 2, 2, 3, 3, 3, 3 };
            var longestSubsequence = LongestSubsequenceOfEquals.FindLongestSubsequence(collection).ToList();
            var expectedLongestSubsequence = new List<int>() { 3, 3, 3, 3 };

            CollectionAssert.AreEqual(expectedLongestSubsequence, longestSubsequence);
        }

        [TestMethod]
        public void ShouldReturnLastLongestSubsequence_3()
        {
            var collection = new List<int>() { 1, 2, 3, 4 };
            var longestSubsequence = LongestSubsequenceOfEquals.FindLongestSubsequence(collection).ToList();
            var expectedLongestSubsequence = new List<int>() { 4 };

            CollectionAssert.AreEqual(expectedLongestSubsequence, longestSubsequence);
        }

        [TestMethod]
        public void ShouldReturnLongestSubsequenceAtTheBeginning()
        {
            var collection = new List<int>() { 1, 1, 1, 1, 2, 2, 3, 3, 3 };
            var longestSubsequence = LongestSubsequenceOfEquals.FindLongestSubsequence(collection).ToList();
            var expectedLongestSubsequence = new List<int>() { 1, 1, 1, 1 };

            CollectionAssert.AreEqual(expectedLongestSubsequence, longestSubsequence);
        }

        [TestMethod]
        public void ShouldReturnOnlyOneSubsequenceAtTheEnd()
        {
            var collection = new List<int>() { 1, 2, 2, 3, 3, 3, 4, 4, 4, 4 };
            var longestSubsequence = LongestSubsequenceOfEquals.FindLongestSubsequence(collection).ToList();
            var expectedLongestSubsequence = new List<int>() { 4, 4, 4, 4 };

            CollectionAssert.AreEqual(expectedLongestSubsequence, longestSubsequence);
        }

        [TestMethod]
        public void ShouldReturnOnlyOneSubsequenceAtTheMiddle()
        {
            var collection = new List<int>() { 1, 2, 2, 3, 3, 3, 3, 4, 4, 4 };
            var longestSubsequence = LongestSubsequenceOfEquals.FindLongestSubsequence(collection).ToList();
            var expectedLongestSubsequence = new List<int>() { 3, 3, 3, 3 };

            CollectionAssert.AreEqual(expectedLongestSubsequence, longestSubsequence);
        }

        [TestMethod]
        public void ShouldReturnOnlyOneSubsequenceAtTheMiddleOnStrings()
        {
            var collection = new List<string>() { "a", "b", "b", "b", "c", "c" };
            var longestSubsequence = LongestSubsequenceOfEquals.FindLongestSubsequence(collection).ToList();
            var expectedLongestSubsequence = new List<string>() { "b", "b", "b" };

            CollectionAssert.AreEqual(expectedLongestSubsequence, longestSubsequence);
        }
    }
}