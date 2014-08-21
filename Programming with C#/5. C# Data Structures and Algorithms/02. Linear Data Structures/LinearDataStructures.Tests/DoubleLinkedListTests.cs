namespace LinearDataStructures.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using DynamicList;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class DoubleLinkedListTests
    {
        [TestMethod]
        public void TestCountOnAddFirstMethod()
        {
            var linkedList = new DoubleLinkedList<int>();
            linkedList.AddFirst(3);
            linkedList.AddFirst(2);
            linkedList.AddFirst(1);

            Assert.AreEqual(3, linkedList.Count);
        }

        [TestMethod]
        public void TestCountOnAddLastMethod()
        {
            var linkedList = new DoubleLinkedList<int>();
            linkedList.AddLast(3);
            linkedList.AddLast(2);
            linkedList.AddLast(1);

            Assert.AreEqual(3, linkedList.Count);
        }

        [TestMethod]
        public void TestCountOnAddFirstAndAddLastMethods()
        {
            var linkedList = new DoubleLinkedList<int>();
            linkedList.AddFirst(1);
            linkedList.AddFirst(2);
            linkedList.AddLast(3);
            linkedList.AddLast(4);

            Assert.AreEqual(4, linkedList.Count);
        }

        [TestMethod]
        public void TestFirstElementOnAddFirstMethod()
        {
            var linkedList = new DoubleLinkedList<int>();
            linkedList.AddFirst(1);

            Assert.AreEqual(1, linkedList.First.Value);
            Assert.AreEqual(1, linkedList.Last.Value);
            Assert.AreEqual(1, linkedList.Count);
        }

        [TestMethod]
        public void TestLastElementOnAddFirstMethod()
        {
            var linkedList = new DoubleLinkedList<int>();
            linkedList.AddLast(1);

            Assert.AreEqual(1, linkedList.First.Value);
            Assert.AreEqual(1, linkedList.Last.Value);
            Assert.AreEqual(1, linkedList.Count);
        }

        [TestMethod]
        public void TestFirstMiddleLastElementsOnAddFirstMethod()
        {
            var linkedList = new DoubleLinkedList<int>();
            linkedList.AddFirst(1);
            linkedList.AddFirst(2);
            linkedList.AddFirst(3);

            Assert.AreEqual(3, linkedList.First.Value);
            Assert.AreEqual(2, linkedList.First.Next.Value);
            Assert.AreEqual(1, linkedList.Last.Value);
            Assert.AreEqual(3, linkedList.Count);
        }

        [TestMethod]
        public void TestFirstMiddleLastElementsOnAddLastMethod()
        {
            var linkedList = new DoubleLinkedList<int>();
            linkedList.AddLast(1);
            linkedList.AddLast(2);
            linkedList.AddLast(3);

            Assert.AreEqual(1, linkedList.First.Value);
            Assert.AreEqual(2, linkedList.First.Next.Value);
            Assert.AreEqual(3, linkedList.Last.Value);
            Assert.AreEqual(3, linkedList.Count);
        }

        [TestMethod]
        public void TestFirstMiddleLastElementsOnAddFirstAndAddLastMethod()
        {
            var linkedList = new DoubleLinkedList<int>();
            linkedList.AddFirst(2);
            linkedList.AddLast(3);
            linkedList.AddFirst(1);
            linkedList.AddLast(4);

            Assert.AreEqual(1, linkedList.First.Value);
            Assert.AreEqual(2, linkedList.First.Next.Value);
            Assert.AreEqual(3, linkedList.Last.Previous.Value);
            Assert.AreEqual(4, linkedList.Last.Value);
            Assert.AreEqual(4, linkedList.Count);
        }

        [TestMethod]
        public void TestFindMethodOnExistedElementsThatIsPlacedAtTheBeginning()
        {
            var linkedList = new DoubleLinkedList<int>();
            linkedList.AddFirst(3);
            linkedList.AddFirst(2);
            linkedList.AddFirst(1);

            Assert.IsNotNull(linkedList.Find(1));
            Assert.AreEqual(1, linkedList.Find(1).Value);
            Assert.AreEqual(3, linkedList.Count);
        }

        [TestMethod]
        public void TestFindMethodOnExistedElementThatIsPlacedAtTheEnd()
        {
            var linkedList = new DoubleLinkedList<int>();
            linkedList.AddFirst(3);
            linkedList.AddFirst(2);
            linkedList.AddFirst(1);
            linkedList.AddLast(4); 
            linkedList.AddLast(7); 

            Assert.IsNotNull(linkedList.Find(4));
            Assert.AreEqual(4, linkedList.Find(4).Value);
            Assert.AreEqual(5, linkedList.Count);
        }

        [TestMethod]
        public void TestFindMethodShouldReturnNull()
        {
            var linkedList = new DoubleLinkedList<int>();
            linkedList.AddFirst(3);
            linkedList.AddFirst(2);

            Assert.IsNull(linkedList.Find(4));
        }

        [TestMethod]
        public void TestAddBeforeMethod()
        {
            var linkedList = new DoubleLinkedList<int>();
            linkedList.AddFirst(4);
            linkedList.AddFirst(2);
            linkedList.AddBefore(linkedList.First, 0);
            linkedList.AddBefore(linkedList.Last, 3);
            linkedList.AddBefore(linkedList.Find(2), 1);

            CollectionAssert.AreEqual(new List<int> { 0, 1, 2, 3, 4 }, linkedList.ToList());
        }

        [TestMethod]
        public void TestAddAfterMethod()
        {
            var linkedList = new DoubleLinkedList<int>();
            linkedList.AddFirst(4);
            linkedList.AddFirst(1);
            linkedList.AddAfter(linkedList.First, 2);
            linkedList.AddAfter(linkedList.Last, 5);
            linkedList.AddAfter(linkedList.Find(2), 3);

            CollectionAssert.AreEqual(new List<int> { 1, 2, 3, 4, 5 }, linkedList.ToList());
        }

        [TestMethod]
        public void TestRemoveMethodShouldChangeCount()
        {
            var linkedList = new DoubleLinkedList<int>();
            linkedList.AddFirst(4);
            linkedList.AddFirst(4);
            linkedList.AddFirst(1);
            linkedList.AddFirst(1);

            linkedList.Remove(4);
            Assert.AreEqual(3, linkedList.Count);

            linkedList.Remove(4);
            Assert.AreEqual(2, linkedList.Count);
        }

        [TestMethod]
        public void TestRemoveMethodShouldNotChangeCount()
        {
            var linkedList = new DoubleLinkedList<int>();
            linkedList.AddFirst(4);
            linkedList.AddFirst(1);

            linkedList.Remove(5);
            Assert.AreEqual(2, linkedList.Count);
        }

        [TestMethod]
        public void TestRemoveFirstMethod()
        {
            var linkedList = new DoubleLinkedList<int>();
            linkedList.AddFirst(3);
            linkedList.AddFirst(2);
            linkedList.AddFirst(1);

            Assert.AreEqual(1, linkedList.First.Value);
            Assert.AreEqual(3, linkedList.Count);

            linkedList.RemoveFirst();
            Assert.AreEqual(2, linkedList.First.Value);
            Assert.AreEqual(2, linkedList.Count);

            linkedList.RemoveFirst();
            Assert.AreEqual(3, linkedList.First.Value);
            Assert.AreEqual(1, linkedList.Count);

            linkedList.RemoveFirst();
            Assert.IsNull(linkedList.First);
            Assert.AreEqual(0, linkedList.Count);
        }

        [TestMethod]
        public void TestRemoveLastMethod()
        {
            var linkedList = new DoubleLinkedList<int>();
            linkedList.AddFirst(3);
            linkedList.AddFirst(2);
            linkedList.AddFirst(1);

            Assert.AreEqual(3, linkedList.Last.Value);
            Assert.AreEqual(3, linkedList.Count);

            linkedList.RemoveLast();
            Assert.AreEqual(2, linkedList.Last.Value);
            Assert.AreEqual(2, linkedList.Count);

            linkedList.RemoveLast();
            Assert.AreEqual(1, linkedList.Last.Value);
            Assert.AreEqual(1, linkedList.Count);

            linkedList.RemoveLast();
            Assert.IsNull(linkedList.Last);
            Assert.AreEqual(0, linkedList.Count);
        }

        [TestMethod]
        public void TestGetEnumeratorMethod()
        {
            var linkedList = new DoubleLinkedList<int>();
            linkedList.AddFirst(3);
            linkedList.AddFirst(2);
            linkedList.AddFirst(1);

            var elements = new List<int>();

            foreach (var node in linkedList)
            {
                elements.Add(node);
            }

            CollectionAssert.AreEqual(elements, linkedList.ToList());
        }

        [TestMethod]
        public void TestClearMethod()
        {
            var linkedList = new DoubleLinkedList<int>();
            linkedList.AddFirst(3);
            linkedList.AddLast(2);
            linkedList.AddAfter(linkedList.First, 1);
            linkedList.AddBefore(linkedList.Last, 3);

            linkedList.Clear();

            Assert.AreEqual(0, linkedList.Count);
            Assert.IsNull(linkedList.First);
            Assert.IsNull(linkedList.Last);
        }
    }
}