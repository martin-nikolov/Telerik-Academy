/*
 * 4. Write a method that finds the longest subsequence of equal 
 * numbers in given List<int> and returns the result as new List<int>. 
 * Write a program to test whether the method works correctly.
 */

using System;
using System.Collections.Generic;
using System.Linq;

class LongestSubsequenceOfEquals
{
    static void Main()
    {
        PrintResult(new List<int>() { 1, 2, 2, 3, 3, 3 });

        /* -------------- */
        
        TestRunner();
    }

    static void PrintResult<T>(IList<T> sequence) where T : IComparable
    {
        var longestSubsequence = FindLongestSubsequence(sequence);

        Console.WriteLine(string.Join(" ", sequence) + " -> " + string.Join(" ", longestSubsequence));
    }

    static IList<T> FindLongestSubsequence<T>(IList<T> sequence) where T : IComparable
    {
        if (sequence.Count == 0)
        {
            throw new InvalidOperationException("Sequence contains no elements");
        }

        T bestElement = sequence[0];
        int bestOccurs = 1;

        T currentBestElement = sequence[0];
        int currentOccurs = 1;

        for (int i = 1; i < sequence.Count; i++)
        {
            if (currentBestElement.CompareTo(sequence[i]) == 0)
            {
                currentOccurs++;

                if (currentOccurs >= bestOccurs)
                {
                    bestOccurs = currentOccurs;
                    bestElement = currentBestElement;
                }
            }
            
            if (currentBestElement.CompareTo(sequence[i]) != 0)
            {
                currentBestElement = sequence[i];
                currentOccurs = 1;
            }
        }

        return Enumerable.Repeat(bestElement, bestOccurs).ToList();
    }

    static void TestRunner()
    {
        Console.WriteLine();

        PrintResult(new List<int>() { 1, 1, 1, 2, 2, 3, 3, 3 });
        PrintResult(new List<int>() { 1, 1, 1, 1, 2, 2, 3, 3, 3 });
        PrintResult(new List<int>() { 1, 1, 1, 1, 2, 2, 3, 3, 3, 3 });
        PrintResult(new List<int>() { 1, 2, 2, 3, 3, 3, 4, 4, 4, 4 });
        PrintResult(new List<int>() { 1, 2, 2, 3, 3, 3, 3, 4, 4, 4, 4 });
        PrintResult(new List<int>() { 1, 2, 2, 3, 3, 3, 3, 4, 4, 4 });
        PrintResult(new List<int>() { 1, 2, 3, 4 });
        PrintResult(new List<string>() { "a", "b", "b", "b", "c", "c" });
    }
}