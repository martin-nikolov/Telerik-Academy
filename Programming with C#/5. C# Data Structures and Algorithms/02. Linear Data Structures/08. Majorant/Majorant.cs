/*
 * 8. *The majorant of an array of size N is a value that
 * occurs in it at least N/2 + 1 times. Write a program to
 * find the majorant of given array (if exists). 
 * 
 * Example: {2, 2, 3, 3, 2, 3, 4, 3, 3} -> 3
 */

namespace LinearDataStructures
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Utility;

    public class Majorant
    {
        public static void Main()
        {
            #if DEBUG
            Console.SetIn(new System.IO.StreamReader("../../input.txt"));
            #endif

            var elements = ConsoleUtility.ReadSequenceOfElements<int>().ToList();
            var majorant = FindMajorant(elements);

            PrintResult(majorant);
        }
 
        public static Nullable<T> FindMajorant<T>(IList<T> collection) where T : struct
        {
            if (collection == null || collection.Count == 0)
            {
                throw new ArgumentException("Sequence collection cannot be null or empty.");
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

        public static void PrintResult(int? majorant)
        {
            Console.WriteLine(majorant.HasValue ? "Majorant: " + majorant.ToString() : "There is no majorant.");
        }
    }
}