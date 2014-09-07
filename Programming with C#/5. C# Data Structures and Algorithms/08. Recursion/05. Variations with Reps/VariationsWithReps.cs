/*
 * 5. Write a recursive program for generating and printing all
 * ordered k-element subsets from n-element set (variations Vkn).
 * 
 * Example: n=3, k=2, set = {hi, a, b} =>
 * (hi hi), (hi a), (hi b), (a hi), (a a), (a b), (b hi), (b a), (b b)
 */

namespace Algorithms
{
    using System;

    public class VariationsWithReps
    {
        private static readonly string[] elements = { "hi", "a", "b" };
        private static int[] variations;
        private static int N;
        private const int K = 2;

        public static void Main()
        {
            N = elements.Length;
            variations = new int[N];

            Variations(0);
        }

        private static void Variations(int depth)
        {
            if (depth >= K)
            {
                Print();
                return;
            }

            for (int i = 0; i < N; i++)
            {
                variations[depth] = i;
                Variations(depth + 1);
            }
        }

        private static void Print()
        {
            for (int i = 0; i < K; i++)
            {
                Console.Write(elements[variations[i]] + " ");
            }

            Console.WriteLine();
        }
    }
}