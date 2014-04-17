/*
 * 5. Write a recursive program for generating and printing all
 * ordered k-element subsets from n-element set (variations Vkn).
 * 
 * Example: n=3, k=2, set = {hi, a, b} =>
 * (hi hi), (hi a), (hi b), (a hi), (a a), (a b), (b hi), (b a), (b b)
 */

using System;
using System.Linq;

class VariationsWithReps
{
    static readonly string[] elements = { "hi", "a", "b" };
    static int[] variations;

    static int N;

    const int K = 2;

    static void Main()
    {
        N = elements.Length;
        variations = new int[N];

        Variations(0);
    }

    static void Variations(int index)
    {
        if (index >= K)
        {
            Print();
            return;
        }

        for (int i = 0; i < N; i++)
        {
            variations[index] = i;
            Variations(index + 1);
        }
    }

    static void Print()
    {
        for (int i = 0; i < K; i++)
            Console.Write(elements[variations[i]] + " ");

        Console.WriteLine();
    }
}