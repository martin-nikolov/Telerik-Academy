namespace Algorithms
{
    using System;

    public static class MergeSortAlgorithm<T> where T : IComparable<T>
    {
        private static T[] temp;

        public static void Sort(T[] collection)
        {
            temp = new T[collection.Length];
            Partitioning(collection, 0, collection.Length - 1);
        }

        private static void Partitioning(T[] collection, int left, int right)
        {
            // Array with 1 element
            if (left >= right) return;

            // Define a middle of the array
            int middle = (left + right) / 2;

            Partitioning(collection, left, middle);
            Partitioning(collection, middle + 1, right);

            Merge(collection, left, middle, right);
        }

        private static void Merge(T[] collection, int left, int middle, int right) 
        {
            int i = left; // 'temp' indexes
            int l = left, m = middle + 1; // 'arr' indexes

            while (l <= middle && m <= right)
                if (collection[l].CompareTo(collection[m]) < 0) temp[i++] = collection[l++];
                else temp[i++] = collection[m++];

            while (l <= middle) temp[i++] = collection[l++];

            while (m <= right) temp[i++] = collection[m++];

            Array.Copy(temp, left, collection, left, right - left + 1);
        }
    }
}

namespace Algorithms.Tests
{
    using System;
    using System.Diagnostics;

    static class MergeSortAlgorithmTest
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
            var unsortedNumbers = new int[] { 1, -2, 3, -4, 5, -6, 7, -8, 9, -10 };

            Console.Write(string.Join(" ", unsortedNumbers) + " -> ");
            MergeSortAlgorithm<int>.Sort(unsortedNumbers);
            Console.WriteLine(string.Join(" ", unsortedNumbers));

            var unsortedDoubleNumbers = new double[] { 1.1, -2.2, 3.3, -4.4, 5.5, -6.6, 7.7, -8.8, 9.9, -10.10 };

            Console.Write(string.Join(" ", unsortedDoubleNumbers) + " -> ");
            MergeSortAlgorithm<double>.Sort(unsortedDoubleNumbers);
            Console.WriteLine(string.Join(" ", unsortedDoubleNumbers));

            var unsortedSymbols = new string[] { "b", "d", "c", "a", "f", "w", "z" };

            Console.Write(string.Join(" ", unsortedSymbols) + " -> ");
            MergeSortAlgorithm<string>.Sort(unsortedSymbols);
            Console.WriteLine(string.Join(" ", unsortedSymbols));

            var unsortedLetters = new char[] { 'z', 'b', 'd', 'c', 'w', 'a', 'f' };

            Console.Write(string.Join(" ", unsortedLetters) + " -> ");
            MergeSortAlgorithm<char>.Sort(unsortedLetters);
            Console.WriteLine(string.Join(" ", unsortedLetters));
        }

        static void TestForPerformance(int capacity)
        {
            Stopwatch sw = new Stopwatch();
            var numbers = new int[capacity];

            for (int i = 0; i < capacity; i++)
                numbers[i] = randomGenerator.Next(int.MaxValue);

            sw.Start();
            MergeSortAlgorithm<int>.Sort(numbers);
            sw.Stop();

            Console.WriteLine(sw.Elapsed + " -> " + capacity + " elements.");
        }
    }
}