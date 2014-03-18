/*
 * 2. Write a program that extracts from a given sequence of
 * strings all elements that present in it odd number of times.
 * 
 * Example: { C#, SQL, PHP, PHP, SQL, SQL } -> { C#, SQL }
 */

using System;
using System.Collections.Generic;
using System.Linq;

class ExtractElementsOddTimes
{
    static void Main()
    {
        var elements = new List<string>() { "C#", "SQL", "PHP", "PHP", "SQL", "SQL" };

        var extractedElements = FindElements(elements, isOddNumberOfTimes: true);

        PrintResult(extractedElements);
    }

    static ISet<T> FindElements<T>(IList<T> collection, bool isOddNumberOfTimes)
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

        return isOddNumberOfTimes ? oddOccurrences : evenOccurrences;
    }

    static void PrintResult<T>(ISet<T> elements)
    {
        Console.WriteLine(String.Join(" ", elements));
    }
}