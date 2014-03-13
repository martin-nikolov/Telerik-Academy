namespace Algorithms.Test
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class BinarySearchTest
    {
        [TestMethod]
        public void TestOnEmptyCollection()
        {
            var collection = new SortableCollection<int>();

            var searchedNumber = 22;
            var expected = FindFirst(collection.Items, searchedNumber);
            var actual = collection.BinarySearch(searchedNumber);

            Assert.AreEqual<int>(expected, actual);
        }

        [TestMethod]
        public void TestSuccessAtBegining()
        {
            var array = new[] { 22, 11, 101, 33, 0, 101 };
            Array.Sort(array);

            var collection = new SortableCollection<int>(array);

            var searchedNumber = 0;
            var expected = FindFirst(collection.Items, searchedNumber);
            var actual = collection.BinarySearch(searchedNumber);

            Assert.AreEqual<int>(expected, actual);
        }

        [TestMethod]
        public void TestSuccessAtEnd()
        {
            var array = new[] { 22, 11, 101, 33, 0, 101, 555 };
            Array.Sort(array);

            var collection = new SortableCollection<int>(array);

            var searchedNumber = 555;
            var expected = FindFirst(collection.Items, searchedNumber);
            var actual = collection.BinarySearch(searchedNumber);

            Assert.AreEqual<int>(expected, actual);
        }

        [TestMethod]
        public void TestSuccessAtMiddle()
        {
            var array = new[] { 1, 2, 3 };
            Array.Sort(array);

            var collection = new SortableCollection<int>(array);

            var searchedNumber = 2;
            var expected = FindFirst(collection.Items, searchedNumber);
            var actual = collection.BinarySearch(searchedNumber);

            Assert.AreEqual<int>(expected, actual);
        }

        [TestMethod]
        public void TestOnOneElement()
        {
            var array = new[] { 1 };
            Array.Sort(array);

            var collection = new SortableCollection<int>(array);

            var searchedNumber = 1;
            var expected = FindFirst(collection.Items, searchedNumber);
            var actual = collection.BinarySearch(searchedNumber);

            Assert.AreEqual<int>(expected, actual);
        }

        [TestMethod]
        public void TestOnMissingElement()
        {
            var array = new[] { 1, 2, 3 };
            Array.Sort(array);

            var collection = new SortableCollection<int>(array);

            var searchedNumber = 4;
            var expected = FindFirst(collection.Items, searchedNumber);
            var actual = collection.BinarySearch(searchedNumber);

            Assert.AreEqual<int>(expected, actual);
        }

        private static int FindFirst<T>(IList<T> collection, T item) where T : IComparable<T>
        {
            var items = collection.ToArray();
            var index = Array.BinarySearch(items, item);

            return index < 0 ? -1 : index;
        }
    }
}