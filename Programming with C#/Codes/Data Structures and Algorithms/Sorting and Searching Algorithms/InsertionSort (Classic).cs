namespace Algorithms
{
    using System;

    public static class InsertionSort<T> where T : IComparable<T>
    {
        public static void Sort(ref T[] collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("Collection cannot be null.");
            }

            T x = default(T);
            int j;

            for (int i = 0; i < collection.Length; i++)
            {
                x = collection[i];
                j = i - 1;

                while (j >= 0 && x.CompareTo(collection[j]) < 0)
                {
                    collection[j + 1] = collection[j--];    
                }

                collection[j + 1] = x;
            }
        }
    }
}

namespace Algorithms.Tests
{
    using System;
    using System.Diagnostics;
    using System.Linq;

    static class InsertionSortTest
    {
        static Random randomGenerator = new Random();

        static void Main()
        {
            TestRunner();
            TestForPerformance(30000);
            TestForPerformance(60000);
            TestForPerformance(120000);
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
            InsertionSort<T>.Sort(ref collection);
            Console.WriteLine(string.Join(" ", collection));
        }

        static void TestForPerformance(int capacity)
        {
            Stopwatch sw = new Stopwatch();
            var collection = new int[capacity];

            for (int i = 0; i < capacity; i++)
                collection[i] = randomGenerator.Next(int.MaxValue);

            sw.Start();
            InsertionSort<int>.Sort(ref collection);
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