/*
 * 1. Write a recursive program that simulates the 
 * execution of n nested loops from 1 to n. 
 * 
 * Examples:
 *                            1 1 1
 *                            1 1 2
 *                            1 1 3
 *          1 1               1 2 1
 * n=2  ->  1 2      n=3  ->  ...
 *          2 1               3 2 3
 *          2 2               3 3 1
 *                            3 3 2
 *                            3 3 3 
 */

namespace Algorithms
{
    using System;

    public class NestedLoops
    {
        private static readonly Action printStrategy = () => { Console.WriteLine(string.Join(" ", result)); };
        private static readonly int[] result = new int[N];
        private const int N = 2;

        public static void Main()
        {
            SimulateNestedLoops(0, N);
        }

        private static void SimulateNestedLoops(int startValue, int endValue, int depth = 0)
        {
            if (depth == N)
            {
                printStrategy.Invoke();
                return;
            }

            for (int i = startValue + 1; i <= endValue; i++)
            {
                result[depth] = i;
                SimulateNestedLoops(0, endValue, depth + 1);
            }
        }
    }
}