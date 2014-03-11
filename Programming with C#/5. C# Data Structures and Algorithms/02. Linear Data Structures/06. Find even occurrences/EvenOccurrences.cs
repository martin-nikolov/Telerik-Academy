/*
 * 6. Write a program that removes from given sequence
 * all numbers that occur odd number of times. 
 * 
 * Example:
 * {4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2} -> {5, 3, 3, 5}
 */

using System;
using System.Collections.Generic;
using System.Linq;

class EvenOccurrences
{
    static void Main()
    {
        var elements = new List<int>() { 4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2 };

        var evenNumberOfTimes = FindEvenOccurrences(elements);

        PrintResult(elements, evenNumberOfTimes);
    }

    static HashSet<T> FindEvenOccurrences<T>(IList<T> collection)
    {
        var oddOccurrences = new HashSet<T>();
        var evenOccurrences = new HashSet<T>();

        foreach (var item in collection)
        {
            if (oddOccurrences.Add(item))
            {
                // We have seen item an odd number of times
                evenOccurrences.Remove(item);
            }
            else
            {
                // We have seen item an even number of times
                oddOccurrences.Remove(item);
                evenOccurrences.Add(item);
            }
        }

        return evenOccurrences;
    }

    static void PrintResult<T>(List<T> elements, HashSet<T> evenNumberOfTimes)
    {
        for (int i = 0; i < elements.Count; i++)
        {
            if (evenNumberOfTimes.Contains(elements[i]))
            {
                Console.Write(elements[i] + " ");
            }
        }

        Console.WriteLine();
    }
}