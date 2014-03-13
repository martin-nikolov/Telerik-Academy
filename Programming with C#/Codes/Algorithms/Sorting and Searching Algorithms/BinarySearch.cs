namespace Algorithms
{
    using System;

    public static class BinarySearch 
    {
        public static int Search<T>(T[] collection, T item) where T : IComparable<T>
        {
            if (collection == null)
            {
                throw new ArgumentNullException("Collection");
            }

            int left = 0, right = collection.Length - 1, middle = 0;

            while (left <= right)
            {
                middle = GetMedian(left, right);

                if (collection[middle].CompareTo(item) < 0)
                {
                    left = middle + 1;
                }
                else if (collection[middle].CompareTo(item) > 0)
                {
                    right = middle - 1;
                }
                else
                {
                    return middle;
                }
            }

            return -1;
        }

        private static int GetMedian(int left, int right)
        {
            return left + ((right - left) >> 1);
        }
    }
}

namespace Algorithms.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    static class BinarySearchTest
    {
        static Random randomGenerator = new Random();

        static void Main()
        {
            TestRunner();
        }

        static void TestRunner()
        {
            IterateItems(new double[] { -9, -7, -5, -3, -1, 0, 1, 3, 5, 7, 9 }, -2);

            IterateItems(new double[] { -9.9, -7.7, -5.5, -3.3, -1.1, 0, 1.1, 3.3, 5.5, 7.7, 9.9 }, -10.10);

            IterateItems(new double[] { -9.9, -7.7, -5.5, -3.3, -1.1, 0, 1.1, 3.3, 5.5, 7.7, 9.9 }, -10.10);

            IterateItems(new string[] { "a", "b", "c", "e", "f", "g", "w", "x" }, "y");

            IterateItems(new string[] { "aaa", "bb", "cccc", "eee", "ff", "gg", "www", "xxxxx" }, "yy");

            IterateItems(new char[] { 'a', 'b', 'c', 'e', 'f', 'g', 'w', 'x' }, 'y');
        }
  
        static void IterateItems<T>(T[] collection, T extraItem) where T : IComparable<T>
        {
            Console.Write("Items: {0,-50} {1}", string.Join(" ", collection), " -> ");

            foreach (var item in collection)
                Console.Write(BinarySearch.Search(collection, item) + " ");

            Console.WriteLine(" | [{0}] {1}", extraItem, BinarySearch.Search(collection, extraItem));

            TestForSuccess(collection.ToList());
        }

        static void TestForSuccess<T>(List<T> collection) where T : IComparable<T>
        {
            foreach (var item in collection)
            {
                if (BinarySearch.Search(collection.ToArray(), item) != collection.BinarySearch(item))
                {
                    Console.WriteLine("FAIL");
                }
            }
        }
    }
}