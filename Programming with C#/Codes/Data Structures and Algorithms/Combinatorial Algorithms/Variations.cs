using System;
using System.Linq;

class Variations
{
    static int[] variations = new int[N];

    const int N = 3;
    const int K = 2;

    static void Main()
    {
        Console.WriteLine("Variations without repetition: ");
        VariationsWithoutReps(0, 0);

        Console.WriteLine("\nVariations with repetition: ");
        VariationsWithReps(0);
    }

    static void VariationsWithReps(int index)
    {
        if (index >= K)
        {
            Print();
            return;
        }

        for (int i = 0; i < N; i++)
        {
            variations[index] = i;
            VariationsWithReps(index + 1);
        }
    }

    static void VariationsWithoutReps(int index, int start)
    {
        if (index >= K)
        {
            Print();
            return;
        }

        for (int i = start; i < N; i++, start++)
        {
            variations[index] = i;
            VariationsWithoutReps(index + 1, start + 1);
        }
    }

    static void Print()
    {
        for (int i = 0; i < K; i++)
            Console.Write(variations[i] + 1 + " ");

        Console.WriteLine();
    }
}