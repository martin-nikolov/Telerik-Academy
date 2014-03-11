/*
 * 8. *The majorant of an array of size N is a value that
 * occurs in it at least N/2 + 1 times. Write a program to
 * find the majorant of given array (if exists). 
 * Example: {2, 2, 3, 3, 2, 3, 4, 3, 3} -> 3
 */

using System;
using System.Collections.Generic;
using System.Linq;

class Majorant
{
    static void Main()
    {
        var elements = new List<int>() { 2, 2, 3, 3, 2, 3, 4, 3, 3 };

        var majorant = FindMajorant(elements);

        Console.WriteLine(majorant.HasValue ? "Majorant: " + majorant.ToString() : "There is no majorant.");
    }
  
    static Nullable<T> FindMajorant<T>(IList<T> collection) where T : struct
    {
        if (collection.Count == 0)
        {
            throw new InvalidOperationException("Sequence contains no elements");
        }

        int majorantMedian = collection.Count / 2 + 1;
        T? majorant = null;

        var dict = new Dictionary<T, int>();

        for (int i = 0; i < collection.Count; i++)
        {
            if (!dict.ContainsKey(collection[i]))
            {
                dict[collection[i]] = 0;
            }

            dict[collection[i]]++;

            if (dict[collection[i]] >= majorantMedian)
            {
                majorant = collection[i];
                break;
            }
        }

        return majorant;
    }
}