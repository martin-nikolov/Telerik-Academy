namespace AdvancedDataStructures.Tests
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class PriorityQueueTests
    {
        [TestMethod]
        public void TestWithPrimitiveType()
        {
            var priorityQueueInts = new PriorityQueue<int>();

            priorityQueueInts.Add(5);
            priorityQueueInts.Add(10);
            priorityQueueInts.Add(-5);
            priorityQueueInts.Add(1);
            priorityQueueInts.Add(13);
            priorityQueueInts.Add(13);
            priorityQueueInts.Add(0);
            priorityQueueInts.Add(25);

            var numbersActualOrder = new List<int>();

            while (priorityQueueInts.Count > 0)
            {
                numbersActualOrder.Add(priorityQueueInts.RemoveFirst());  
            }

            var numbersExpectedOrder = new List<int>() { -5, 0, 1, 5, 10, 13, 13, 25 };

            CollectionAssert.AreEqual(numbersExpectedOrder, numbersActualOrder);
        }

        [TestMethod]
        public void TestWithClassHumanImplementsIComparableByAge()
        {
            // Test with class Human implements IComparable (by Age):
            var priorityQueueHumans = new PriorityQueue<Human>();

            priorityQueueHumans.Add(new Human("Ivan", 25));
            priorityQueueHumans.Add(new Human("Georgi", 13));
            priorityQueueHumans.Add(new Human("Cvetelina", 18));
            priorityQueueHumans.Add(new Human("Plamena", 22));
            priorityQueueHumans.Add(new Human("Gergana", 23));
            priorityQueueHumans.Add(new Human("Qna", 21));

            var numbersActualOrder = new List<string>();

            while (priorityQueueHumans.Count > 0)
            {
                numbersActualOrder.Add(priorityQueueHumans.RemoveFirst().Name);
            }

            var numbersExpectedOrder = new List<string>() { "Georgi", "Cvetelina", "Qna", "Plamena", "Gergana", "Ivan" };

            CollectionAssert.AreEqual(numbersExpectedOrder, numbersActualOrder);
        }

        internal class Human : IComparable
        {
            public Human(string name, int age)
            {
                this.Name = name;
                this.Age = age;
            }

            public string Name { get; set; }

            public int Age { get; set; }

            public int CompareTo(object obj)
            {
                var other = obj as Human;

                if (ReferenceEquals(other, null))
                {
                    return -1;
                }

                var comparisonByAge = this.Age.CompareTo(other.Age);
                return comparisonByAge;
            }

            public override string ToString()
            {
                return string.Format("Name: {0}, Age: {1}", this.Name, this.Age);
            }
        }
    }
}