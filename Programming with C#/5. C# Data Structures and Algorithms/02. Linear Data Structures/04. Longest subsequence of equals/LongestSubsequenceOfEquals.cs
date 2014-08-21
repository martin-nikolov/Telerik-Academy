/*
 * 4. Write a method that finds the longest subsequence of equal 
 * numbers in given List<int> and returns the result as new List<int>. 
 * Write a program to test whether the method works correctly.
 */

namespace LinearDataStructures
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Utility;

    public class LongestSubsequenceOfEquals
    {
        public static void Main()
        {
            #if DEBUG
            Console.SetIn(new System.IO.StreamReader("../../input.txt"));
            #endif

            var numbers = ConsoleUtility.ReadSequenceOfElements<int>().ToList();
            var longestSubsequence = FindLongestSubsequence(numbers);

            PrintResult(numbers, longestSubsequence);

            // There are Unit-Tests -> See LinearDataStructures.Tests -> LongestSubsequenceOfEqualsTests
        }

        public static IList<T> FindLongestSubsequence<T>(IList<T> sequence) where T : IComparable
        {
            if (sequence == null || sequence.Count == 0)
            {
                throw new ArgumentException("Sequence collection cannot be null or empty.");
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
            
            if (currentBestElement.CompareTo(bestElement) != 0 && currentOccurs >= bestOccurs)
            {
                bestElement = currentBestElement;
                bestOccurs = currentOccurs;
            }

            var longestSubsequence = Enumerable.Repeat(bestElement, bestOccurs).ToList();
            return longestSubsequence;
        }

        public static void PrintResult<T>(IList<T> sequence, IList<T> longestSubsequence) where T : IComparable
        {
            Console.WriteLine(string.Join(" ", sequence) + " -> " + string.Join(" ", longestSubsequence));
        }
    }
}