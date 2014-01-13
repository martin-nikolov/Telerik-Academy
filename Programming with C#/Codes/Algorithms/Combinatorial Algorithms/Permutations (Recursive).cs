using System;
using System.Linq;

/// <summary>
/// Generate permutations of a given sequence of values contains unique or non-unique elements.
/// </summary>
static class Permutations
{
    static readonly int[] lettersDictionary = new int[Length];
    static readonly char[] generatedWord = new char[Length];
    static readonly char permutationSymbols = 'a'; // Small Letters; 'A' - Upper Letters; '0' - Numbers

    static int totalPermutations = 0;

    const int Length = 6;

    static void Main()
    {
        for (int i = 0; i < Length; i++)
            lettersDictionary[i] = 1;

        GeneratePermutations();
    }

    static void GeneratePermutations()
    {
        GeneratePermutations(0);
        Console.WriteLine("Total permutations: " + totalPermutations);
    }

    static void GeneratePermutations(int index)
    {
        if (index == Length)
        {
            PrintPermutation();
            ++totalPermutations;
            return;
        }

        for (int i = 0; i < Length; i++)
        {
            if (lettersDictionary[i] != 0)
            {
                generatedWord[index] = (char)(i + permutationSymbols);

                lettersDictionary[i]--;
                GeneratePermutations(index + 1); 
                lettersDictionary[i]++;
            }
        }
    }
  
    static void PrintPermutation()
    {
        Console.WriteLine(string.Join(" ", generatedWord));
    }
}