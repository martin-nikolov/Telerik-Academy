/*
* 4. Write a method that finds the longest subsequence of equal
* numbers in a given List<int> and returns the result as new
* List<int>. Write a program to test whether the method works correctly.
*/

using System;
using System.Collections.Generic;

class Program
{
    static List<int> FindBestSubsequence(List<int> sequence)
    {
        List<int> result = new List<int>();

        int currentCount = 1;
        int bestNumber = 0;
        int bestCount = 1;

        for (int index = 0; index < sequence.Count - 1; index++)
        {
            if (sequence[index] == sequence[index + 1])
            {
                currentCount++;

                if (index == sequence.Count - 2)
                {
                    if (currentCount > bestCount)
                    {
                        bestCount = currentCount;
                        bestNumber = sequence[index];
                    }
                }
            }
            else
            {
                if (currentCount > bestCount)
                {
                    bestCount = currentCount;
                    bestNumber = sequence[index];
                }

                currentCount = 1;
            }
        }

        for (int index = 0; index < bestCount; index++)
            result.Add(bestNumber);

        return result;
    }

    static void Main(string[] args)
    {
        List<int> sequence = new List<int>() { 0, 1, 2, 2, 3, 3, 3, 4, 4, 4, 4 };
        List<int> bestSubsequence = FindBestSubsequence(sequence);

        Console.Write("Best subsequence between numbers: ");
        foreach (var number in sequence)
            Console.Write(number + " ");

        Console.Write("\nis: ");
        foreach (int number in bestSubsequence)
            Console.Write(number + " ");

        Console.WriteLine();
    }
}