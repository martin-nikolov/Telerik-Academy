namespace Algorithms.Test
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class LinearSearchTest
    {
        [TestMethod]
        public void TestOnEmptyCollection()
        {
            var collection = new SortableCollection<int>();

            var searchedNumber = 22;
            var expected = FindFirst(collection.Items, searchedNumber);
            var actual = collection.LinearSearch(searchedNumber);

            Assert.AreEqual<int>(expected, actual);
        }

        [TestMethod]
        public void TestSuccessAtBegining()
        {
            var collection = new SortableCollection<int>(new[] { 22, 11, 101, 33, 0, 101 });

            var searchedNumber = 22;
            var expected = FindFirst(collection.Items, searchedNumber);
            var actual = collection.LinearSearch(searchedNumber);

            Assert.AreEqual<int>(expected, actual);
        }

        [TestMethod]
        public void TestSuccessAtEnd()
        {
            var collection = new SortableCollection<int>(new[] { 22, 11, 101, 33, 0, 101 });

            var searchedNumber = 101;
            var expected = FindFirst(collection.Items, searchedNumber);
            var actual = collection.LinearSearch(searchedNumber);

            Assert.AreEqual<int>(expected, actual);
        }

        [TestMethod]
        public void TestSuccessAtMiddle()
        {
            var collection = new SortableCollection<int>(new[] { 1, 2, 3 });

            var searchedNumber = 2;
            var expected = FindFirst(collection.Items, searchedNumber);
            var actual = collection.LinearSearch(searchedNumber);

            Assert.AreEqual<int>(expected, actual);
        }

        [TestMethod]
        public void TestOnOneElement()
        {
            var collection = new SortableCollection<int>(new[] { 1 });

            var searchedNumber = 1;
            var expected = FindFirst(collection.Items, searchedNumber);
            var actual = collection.LinearSearch(searchedNumber);

            Assert.AreEqual<int>(expected, actual);
        }

        [TestMethod]
        public void TestOnMissingElement()
        {
            var collection = new SortableCollection<int>(new[] { 1, 2, 3 });

            var searchedNumber = 4;
            var expected = FindFirst(collection.Items, searchedNumber);
            var actual = collection.LinearSearch(searchedNumber);

            Assert.AreEqual<int>(expected, actual);
        }

        private static int FindFirst<T>(IList<T> collection, T item) where T : IComparable<T>
        {
            for (int index = 0; index < collection.Count; index++)
            {
                if (collection[index].CompareTo(item) == 0)
                {
                    return index;
                }
            }

            return -1;
        }
    }
}