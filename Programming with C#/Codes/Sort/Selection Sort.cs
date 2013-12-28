namespace Algorithms
{
    using System;

    public static class SelectionSortAlgorithm<T> where T : IComparable<T>
    {
        public static void Sort(T[] collection) 
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

    static class SelectionSortAlgorithmTest
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
            var unsortedNumbers = new int[] { 1, -2, 3, -4, 5, -6, 7, -8, 9, -10 };

            Console.Write(string.Join(" ", unsortedNumbers) + " -> ");
            SelectionSortAlgorithm<int>.Sort(unsortedNumbers);
            Console.WriteLine(string.Join(" ", unsortedNumbers));

            var unsortedDoubleNumbers = new double[] { 1.1, -2.2, 3.3, -4.4, 5.5, -6.6, 7.7, -8.8, 9.9, -10.10 };

            Console.Write(string.Join(" ", unsortedDoubleNumbers) + " -> ");
            SelectionSortAlgorithm<double>.Sort(unsortedDoubleNumbers);
            Console.WriteLine(string.Join(" ", unsortedDoubleNumbers));

            var unsortedSymbols = new string[] { "b", "d", "c", "a", "f", "w", "z" };

            Console.Write(string.Join(" ", unsortedSymbols) + " -> ");
            SelectionSortAlgorithm<string>.Sort(unsortedSymbols);
            Console.WriteLine(string.Join(" ", unsortedSymbols));

            var unsortedLetters = new char[] { 'z', 'b', 'd', 'c', 'w', 'a', 'f' };

            Console.Write(string.Join(" ", unsortedLetters) + " -> ");
            SelectionSortAlgorithm<char>.Sort(unsortedLetters);
            Console.WriteLine(string.Join(" ", unsortedLetters));
        }

        static void TestForPerformance(int capacity)
        {
            Stopwatch sw = new Stopwatch();
            var numbers = new int[capacity];

            for (int i = 0; i < capacity; i++)
                numbers[i] = randomGenerator.Next(int.MaxValue);

            sw.Start();
            SelectionSortAlgorithm<int>.Sort(numbers);
            sw.Stop();

            Console.WriteLine(sw.Elapsed + " -> " + capacity + " elements.");
        }
    }
}