/*
 * 6. Write a program for generating and printing all
 * subsets of k strings from given set of strings.
 * 
 * Example: s = {test, rock, fun}, k=2 -> (test rock), (test fun), (rock fun)
 */

using System;
using System.Linq;

class VariationsWithReps
{
    static readonly string[] elements = { "test", "rock", "fun" };
    static int[] variations;

    static int N;

    const int K = 2;

    static void Main()
    {
        N = elements.Length;
        variations = new int[N];

        Variations(0, 0);
    }

    static void Variations(int index, int start)
    {
        if (index >= K)
        {
            Print();
            return;
        }

        for (int i = start; i < N; i++, start++)
        {
            variations[index] = i;
            Variations(index + 1, start + 1);
        }
    }

    static void Print()
    {
        for (int i = 0; i < K; i++)
            Console.Write(elements[variations[i]] + " ");

        Console.WriteLine();
    }
}