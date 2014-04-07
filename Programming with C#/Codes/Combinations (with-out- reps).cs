using System;
using System.Linq;

class CombinationsWithDuplicates
{
    static readonly int[] combinations = new int[N];

    const int N = 3;
    const int K = 2;

    static void Main()
    {
        Combinations(0, 0, true);
    }

    static void Combinations(int index, int start, bool withReps)
    {
        if (index >= K)
        {
            Print();
            return;
        }

        for (int i = start; i < N; i++)
        {
            combinations[index] = i;
            Combinations(index + 1, withReps ? i : i + 1, withReps);
        }
    }

    static void Print()
    {
        for (int i = 0; i < K; i++)
            Console.Write(combinations[i] + 1 + " ");

        Console.WriteLine();
    }
}