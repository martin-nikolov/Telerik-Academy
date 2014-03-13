namespace Algorithms.Test
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class MergeSortTest
    {
        static Random rnd = new Random();

        [TestMethod]
        public void TestOnEmptyCollection()
        {
            var collection = new SortableCollection<int>();
            collection.Sort(new MergeSorter<int>());

            Assert.AreEqual(true, this.AreElementsEqual(collection));
        }

        [TestMethod]
        public void TestOnSortedAscendingElements()
        {
            var collection = new SortableCollection<int>(new[] { -5, -4, -3, -2, -1, 0, 1, 2, 3, 4, 5 });
            collection.Sort(new MergeSorter<int>());

            Assert.AreEqual(true, this.AreElementsEqual(collection));
        }

        [TestMethod]
        public void TestOnSortedDescendingElements()
        {
            var collection = new SortableCollection<int>(new[] { 5, 4, 3, 2, 1, 0, -1, -2, -3, -4, -5 });
            collection.Sort(new MergeSorter<int>());

            Assert.AreEqual(true, this.AreElementsEqual(collection));
        }

        [TestMethod]
        public void TestOnRandomNumbers()
        {
            var numbers = new List<int>(100);

            for (int i = 0; i < 10000; i++)
            {
                numbers.Add(rnd.Next(int.MinValue, int.MaxValue));
            }

            var collection = new SortableCollection<int>(new[] { 22, 11, 101, 33, 0, 101 });
            collection.Sort(new MergeSorter<int>());

            Assert.AreEqual(true, this.AreElementsEqual(collection));
        }

        [TestMethod]
        public void TestSortingOnEightNumbers()
        {
            var collection = new SortableCollection<int>(new[] { 1, -1, 2, -2, 3, -3, 4, -5 });
            collection.Sort(new MergeSorter<int>());

            Assert.AreEqual(true, this.AreElementsEqual(collection));
        }

        [TestMethod]
        public void TestSortingOnSixNegativeNumbers()
        {
            var collection = new SortableCollection<int>(new[] { -22, -11, -101, -33, -5, -101 });
            collection.Sort(new MergeSorter<int>());

            Assert.AreEqual(true, this.AreElementsEqual(collection));
        }

        [TestMethod]
        public void TestSortingOnSixPositiveNumbers()
        {
            var collection = new SortableCollection<int>(new[] { 22, 11, 101, 33, 5, 101 });
            collection.Sort(new MergeSorter<int>());

            Assert.AreEqual(true, this.AreElementsEqual(collection));
        }

        private bool AreElementsEqual<T>(SortableCollection<T> collection) where T : IComparable<T>
        {
            var clonedCollection = collection.Items.ToArray(); // New Array => different reference
            Array.Sort(clonedCollection);

            for (int i = 0; i < collection.Items.Count; i++)
            {
                if (collection.Items[i].CompareTo(clonedCollection[i]) != 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}