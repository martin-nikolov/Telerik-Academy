namespace Algorithms
{
    using System;

    public static class QuickSorter
    {
        public static void Sort<T>(T[] collection) where T : IComparable<T>
        {
            QuickSort(collection, 0, collection.Length - 1);
        }

        /// <summary>
        /// Quick sorting (sorting by partitions)
        /// The program below apply classical recursive implementation of the method QuickSort
        /// </summary>
        private static void QuickSort<T>(T[] collection, int leftIndex, int rightIndex) where T : IComparable<T>
        {
            /* QUICKSORT(A,p,r)
            1  if p < r
            2      then q  PARTITION(A,p,r)
            3           QUICKSORT(A,p,q)
            4           QUICKSORT(A,q + 1,r)*/

            if (leftIndex >= rightIndex) return;

            T frontier;
            int leftPointer = leftIndex;
            int rightPointer = rightIndex;

            // 1. Pick a pivot value somewhere in the middle.
            frontier = collection[leftIndex + (rightIndex - leftIndex >> 1)];

            // 2. Loop until pointers meet on the pivot.
            while (leftPointer <= rightPointer)
            {
                // 3. Find a larger value to the right of the pivot.
                //    If there is non we end up at the pivot.
                while (collection[leftPointer].CompareTo(frontier) < 0) leftPointer++;

                // 4. Find a smaller value to the left of the pivot.
                //    If there is non we end up at the pivot.
                while (collection[rightPointer].CompareTo(frontier) > 0) rightPointer--;

                // 5. Check if both pointers are not on the pivot.
                if (leftPointer <= rightPointer)
                {
                    // 6. Swap both values to the right side.
                    T swap = collection[leftPointer];
                    collection[leftPointer] = collection[rightPointer];
                    collection[rightPointer] = swap;

                    leftPointer++;
                    rightPointer--;
                }
            }

            // Here's where the pivot value is in the right spot

            // 7. Recursively call the algorithm on the unsorted array
            //    to the left of the pivot (if exists).
            if (rightPointer > leftIndex) QuickSort(collection, leftIndex, rightPointer);

            // 8. Recursively call the algorithm on the unsorted array
            //    to the right of the pivot (if exists).
            if (leftPointer < rightIndex) QuickSort(collection, leftPointer, rightIndex);

            // 9. The algorithm returns when all sub arrays are sorted.
        }
    }
}

namespace Algorithms.Tests
{
    using System;
    using System.Diagnostics;
    using System.Linq;

    static class QuickSortTest
    {
        static Random randomGenerator = new Random();

        static void Main()
        {
            TestRunner();
            TestForPerformance(300000);
            TestForPerformance(600000);
            TestForPerformance(1200000);
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
            QuickSorter.Sort(collection);
            Console.WriteLine(string.Join(" ", collection));
        }

        static void TestForPerformance(int capacity)
        {
            Stopwatch sw = new Stopwatch();
            var collection = new int[capacity];

            for (int i = 0; i < capacity; i++)
                collection[i] = randomGenerator.Next(int.MaxValue);

            sw.Start();
            QuickSorter.Sort(collection);
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