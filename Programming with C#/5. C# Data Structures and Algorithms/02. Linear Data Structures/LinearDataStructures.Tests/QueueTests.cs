using System;
using AbstractDataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinearDataStructures.Tests
{
    [TestClass]
    public class QueueTests
    {
        [TestMethod]
        public void TestEnqueueFuncionality()
        {
            var queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            Assert.AreEqual(3, queue.Count);
        }

        [TestMethod]
        public void PeekShouldNotChangeCount()
        {
            var queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            Assert.AreEqual(3, queue.Count);
            Assert.AreEqual(1, queue.Peek());
            Assert.AreEqual(3, queue.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestPeekFunctionalityOnEmptyStackShouldThrowException()
        {
            var queue = new Queue<int>();
            queue.Peek();
        }

        [TestMethod]
        public void TestDequeueFunctionality()
        {
            var queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            Assert.AreEqual(3, queue.Count);
            Assert.AreEqual(1, queue.Dequeue());

            Assert.AreEqual(2, queue.Count);
            Assert.AreEqual(2, queue.Dequeue());

            Assert.AreEqual(1, queue.Count);
            Assert.AreEqual(3, queue.Dequeue());

            Assert.AreEqual(0, queue.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestDequeueFunctionalityOnEmptyQueueShouldThrowException()
        {
            var queue = new Queue<int>();
            queue.Dequeue();
        }

        [TestMethod]
        public void TestClearFunctionality()
        {
            var queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            queue.Clear();
            Assert.AreEqual(0, queue.Count);
        }
    }
}