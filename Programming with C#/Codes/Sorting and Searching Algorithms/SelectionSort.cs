namespace Algorithms
{
    using System;

    public static class SelectionSort
    {
        public static void Sort<T>(T[] collection) where T : IComparable<T>
        {
            int swapIndex = 0;

            for (int i = 0; i < collection.Length - 1; i++)
            {
                swapIndex = i;

                for (int j = i + 1; j < collection.Length; j++)
                    if (collection[j].CompareTo(collection[swapIndex]) < 0)
                        swapIndex = j;

                T swap = collection[i];
                collection[i] = collection[swapIndex];
                collection[swapIndex] = swap;
            }
        }
    }
}

namespace Algorithms.Tests
{
    using System;
    using System.Diagnostics;
    using System.Linq;

    static class SelectionSortTest
    {
        static Random randomGenerator = new Random();

        static void Main()
        {
            TestRunner();
            TestForPerformance(10000);
            TestForPerformance(20000);
            TestForPerformance(30000);
        }

        static void TestRunner()
        {
            SortAndPrintResult(new int[] { 1, -2, 3, -4, 5, -6, 7, -8, 9, -10 });

            SortAndPrintResult(new double[] { 1.1, -2.2, 3.3, -4.4, 5.5, -6.6, 7.7, -8.8, 9.9, -10.10 });

            SortAndPrintResult(new string[] { "b", "d", "c", "a", "f", "w", "z" });

            SortAndPrintResult(new char[] { 'z', 'b', 'd', 'c', 'w', 'a', 'f' });
        }

        static void SortAndPrintResult<T>(T[] collection) where T : IComparable<T>
        {
            Console.Write(string.Join(" ", collection) + " -> ");
            SelectionSort.Sort(collection);
            Console.WriteLine(string.Join(" ", collection));
        }

        static void TestForPerformance(int capacity)
        {
            Stopwatch sw = new Stopwatch();
            var collection = new int[capacity];

            for (int i = 0; i < capacity; i++)
                collection[i] = randomGenerator.Next(int.MaxValue);

            sw.Start();
            SelectionSort.Sort(collection);
            sw.Stop();

            IsSortedCollection(collection);

            Console.WriteLine(sw.Elapsed + " -> " + capacity + " elements.");
        }

        static void IsSortedCollection<T>(T[] collection) where T : IComparable<T>
        {
            var sortedCollection = new T[collection.Length];
            Array.Copy(collection, sortedCollection, collection.Length);
            Array.Sort(sortedCollection);

            if (!sortedCollection.SequenceEqual(collection))
            {
                throw new InvalidOperationException();
            }
        }
    }
}