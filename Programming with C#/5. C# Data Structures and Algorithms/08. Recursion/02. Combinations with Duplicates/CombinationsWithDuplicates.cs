/*
 * 2. Write a recursive program for generating and printing all
 * the combinations with duplicates of k elements from n-element set.
 * 
 * Example: n=3, k=2 -> (1 1), (1 2), (1 3), (2 2), (2 3), (3 3)
 */

namespace Algorithms
{
    using System;

    public class CombinationsWithDuplicates
    {
        private static readonly int[] combinations = new int[N];
        private const int N = 3;
        private const int K = 2;

        public static void Main()
        {
            Combinations(0, 0, true);
        }

        private static void Combinations(int startValue, int depth, bool withReps)
        {
            if (depth >= K)
            {
                Print();
                return;
            }

            for (int i = startValue; i < N; i++)
            {
                combinations[depth] = i;
                Combinations(withReps ? i : i + 1, depth + 1, withReps);
            }
        }

        private static void Print()
        {
            for (int i = 0; i < K; i++)
            {
                Console.Write(combinations[i] + 1 + " ");
            }

            Console.WriteLine();
        }
    }
}