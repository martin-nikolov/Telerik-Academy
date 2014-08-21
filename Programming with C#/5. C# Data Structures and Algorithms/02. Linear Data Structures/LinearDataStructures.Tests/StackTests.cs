using System;
using AbstractDataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinearDataStructures.Tests
{
    [TestClass]
    public class StackTests
    {
        [TestMethod]
        public void TestPushFuncionality()
        {
            var stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            Assert.AreEqual(3, stack.Count);
        }

        [TestMethod]
        public void PeekShouldNotChangeCount()
        {
            var stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            Assert.AreEqual(3, stack.Count);
            Assert.AreEqual(3, stack.Peek());
            Assert.AreEqual(3, stack.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestPeekFunctionalityOnEmptyStackShouldThrowException()
        {
            var stack = new Stack<int>();
            stack.Peek();
        }

        [TestMethod]
        public void TestPopFunctionality()
        {
            var stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            Assert.AreEqual(3, stack.Count);
            Assert.AreEqual(3, stack.Pop());

            Assert.AreEqual(2, stack.Count);
            Assert.AreEqual(2, stack.Pop());

            Assert.AreEqual(1, stack.Count);
            Assert.AreEqual(1, stack.Pop());

            Assert.AreEqual(0, stack.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestPopFunctionalityOnEmptyStackShouldThrowException()
        {
            var stack = new Stack<int>();
            stack.Pop();
        }

        [TestMethod]
        public void TestCountAndCapacity()
        {
            var elementsToAdd = 930;

            var stack = new Stack<int>();
            for (int i = 0; i < elementsToAdd; i++)
            {
                stack.Push(i);
            }

            Assert.AreEqual(elementsToAdd, stack.Count);
            Assert.AreEqual(1024, stack.Capacity);
        }

        [TestMethod]
        public void TestTrimExcessFunctionalityShouldNotTrimCapacity()
        {
            var elementsToAdd = 930;

            var stack = new Stack<int>();
            for (int i = 0; i < elementsToAdd; i++)
            {
                stack.Push(i);
            }

            stack.TrimExcess();

            Assert.AreEqual(elementsToAdd, stack.Count);
            Assert.AreEqual(1024, stack.Capacity);
        }

        [TestMethod]
        public void TestTrimExcessFunctionalityShouldTrimCapacity()
        {
            var elementsToAdd = 930;
            var elementsToRemove = 10;

            var stack = new Stack<int>();

            for (int i = 0; i < elementsToAdd; i++)
            {
                stack.Push(i);
            }

            for (int i = 0; i < elementsToRemove; i++)
            {
                stack.Pop();
            }

            stack.TrimExcess();

            Assert.AreEqual(elementsToAdd - elementsToRemove, stack.Count);
            Assert.AreEqual(elementsToAdd - elementsToRemove, stack.Capacity);
        }

        [TestMethod]
        public void TestClearFunctionality()
        {
            var stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            stack.Clear();
            Assert.AreEqual(0, stack.Count);
            Assert.AreEqual(4, stack.Capacity);
        }

        [TestMethod]
        public void TestTrimExcessAfterClearStack()
        {
            var stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            stack.Clear();
            stack.TrimExcess();

            Assert.AreEqual(0, stack.Count);
            Assert.AreEqual(0, stack.Capacity);
        }
    }
}