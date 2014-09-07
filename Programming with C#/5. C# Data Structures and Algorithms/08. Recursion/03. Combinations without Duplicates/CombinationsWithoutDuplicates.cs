/*
 * 3. Modify the previous program to skip duplicates:
 * 
 * Example: n=4, k=2 -> (1 2), (1 3), (1 4), (2 3), (2 4), (3 4)
 */

namespace Algorithms
{
    using System;

    public class CombinationsWithoutDuplicates
    {
        private static readonly int[] combinations = new int[N];
        private const int N = 4;
        private const int K = 2;

        public static void Main()
        {
            Combinations(0, 0, false);
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