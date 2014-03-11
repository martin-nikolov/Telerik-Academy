/*
 * 7. Write a program that finds in given array of integers
 * (all belonging to the range [0..1000]) how many times each of them occurs.
 * 
 * Example: array = {3, 4, 4, 2, 3, 3, 4, 3, 2}
 * 2 -> 2 times
 * 3 -> 4 times
 * 4 -> 3 times
 */

using System;
using System.Collections.Generic;
using System.Linq;

class OccursOfElements
{
    static void Main()
    {
        var elements = new List<int>() { 3, 4, 4, 2, 3, 3, 4, 3, 2 };

        var occurrences = FindElementsOccurrences(elements);

        PrintResult(occurrences);
    }
  
    static IDictionary<T, int> FindElementsOccurrences<T>(IList<T> collection)
    {
        var dict = new Dictionary<T, int>();

        for (int i = 0; i < collection.Count; i++)
        {
            if (!dict.ContainsKey(collection[i]))
            {
                dict[collection[i]] = 0;
            }

            dict[collection[i]]++;
        }

        return dict;
    }

    static void PrintResult<T>(IDictionary<T, int> dict)
    {
        foreach (KeyValuePair<T, int> item in dict)
        {
            Console.WriteLine("{0} -> {1} time(s).", item.Key, item.Value);
        }
    }
}