namespace Algorithms
{
    using System;

    public static class BubbleSortAlgorithm<T> where T : IComparable<T>
    {
        public static void Sort(T[] collection)
        {
            bool flag = false;

            for (int i = 0; i < collection.Length - 1; i++)
            {
                for (int j = 0; j < collection.Length - i - 1; j++)
                {
                    if (collection[j].CompareTo(collection[j + 1]) > 0)
                    {
                        T swap = collection[j];
                        collection[j] = collection[j + 1];
                        collection[j + 1] = swap;
                        flag = true;
                    }
                }

                if (!flag) break;
            }
        }
    }
}

namespace Algorithms.Tests
{
    using System;
    using System.Diagnostics;

    static class BubbleSortAlgorithmTest
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
            BubbleSortAlgorithm<int>.Sort(unsortedNumbers);
            Console.WriteLine(string.Join(" ", unsortedNumbers));

            var unsortedDoubleNumbers = new double[] { 1.1, -2.2, 3.3, -4.4, 5.5, -6.6, 7.7, -8.8, 9.9, -10.10 };

            Console.Write(string.Join(" ", unsortedDoubleNumbers) + " -> ");
            BubbleSortAlgorithm<double>.Sort(unsortedDoubleNumbers);
            Console.WriteLine(string.Join(" ", unsortedDoubleNumbers));

            var unsortedSymbols = new string[] { "b", "d", "c", "a", "f", "w", "z" };

            Console.Write(string.Join(" ", unsortedSymbols) + " -> ");
            BubbleSortAlgorithm<string>.Sort(unsortedSymbols);
            Console.WriteLine(string.Join(" ", unsortedSymbols));

            var unsortedLetters = new char[] { 'z', 'b', 'd', 'c', 'w', 'a', 'f' };

            Console.Write(string.Join(" ", unsortedLetters) + " -> ");
            BubbleSortAlgorithm<char>.Sort(unsortedLetters);
            Console.WriteLine(string.Join(" ", unsortedLetters));
        }

        static void TestForPerformance(int capacity)
        {
            Stopwatch sw = new Stopwatch();
            var numbers = new int[capacity];

            for (int i = 0; i < capacity; i++)
                numbers[i] = randomGenerator.Next(int.MaxValue);

            sw.Start();
            BubbleSortAlgorithm<int>.Sort(numbers);
            sw.Stop();

            Console.WriteLine(sw.Elapsed + " -> " + capacity + " elements.");
        }
    }
}