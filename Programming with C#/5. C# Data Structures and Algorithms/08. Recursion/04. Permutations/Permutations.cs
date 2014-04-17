/*
 * 4. Write a recursive program for generating and printing all
 * permutations of the numbers 1, 2, ..., n for given integer number n.
 * 
 * Example: n=3 -> {1, 2, 3}, {1, 3, 2}, {2, 1, 3}, {2, 3, 1}, {3, 1, 2},{3, 2, 1}
 */

using System;
using System.Linq;

class Permutations
{
    static readonly int[] permutations = new int[N];
    static readonly bool[] used = new bool[N];

    const int N = 3;

    static void Main()
    {
        Console.WriteLine("Permutations without repetition: ");
        PermutationsWithoutReps(0);

        Console.WriteLine("\nPermutations with repetition: ");
        PermutationsWithReps(0);
    }

    static void PermutationsWithoutReps(int index)
    {
        if (index >= N)
        {
            Print();
            return;
        }

        for (int i = 0; i < N; i++)
        {
            if (used[i])
                continue;
            
            used[i] = true;

            permutations[index] = i;
            PermutationsWithoutReps(index + 1);

            used[i] = false;
        }
    }

    static void PermutationsWithReps(int index)
    {
        if (index >= N)
        {
            Print();
            return;
        }

        for (int i = 0; i < N; i++)
        {
            permutations[index] = i;
            PermutationsWithReps(index + 1);
        }
    }

    static void Print()
    {
        for (int i = 0; i < N; i++)
            Console.Write(permutations[i] + 1 + " ");

        Console.WriteLine();
    }
}