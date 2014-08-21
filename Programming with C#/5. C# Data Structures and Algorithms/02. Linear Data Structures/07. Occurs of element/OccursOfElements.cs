/*
 * 7. Write a program that finds in given array of integers
 * (all belonging to the range [0..1000]) how many times each of them occurs.
 * 
 * Example: array = {3, 4, 4, 2, 3, 3, 4, 3, 2}
 * 2 -> 2 times
 * 3 -> 4 times
 * 4 -> 3 times
 */

namespace LinearDataStructures
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Utility;

    public class OccursOfElements
    {
        public static void Main()
        {
            #if DEBUG
            Console.SetIn(new System.IO.StreamReader("../../input.txt"));
            #endif

            var elements = ConsoleUtility.ReadSequenceOfElements<int>().ToList();
            var occurrences = FindElementsOccurrences(elements);

            PrintResult(occurrences);
        }

        public static IDictionary<T, int> FindElementsOccurrences<T>(IList<T> collection)
        {
            var dictionary = new Dictionary<T, int>();

            for (int i = 0; i < collection.Count; i++)
            {
                if (!dictionary.ContainsKey(collection[i]))
                {
                    dictionary[collection[i]] = 0;
                }

                dictionary[collection[i]]++;
            }

            return dictionary;
        }

        public static void PrintResult<T>(IDictionary<T, int> dictionary)
        {
            foreach (KeyValuePair<T, int> item in dictionary)
            {
                Console.WriteLine("{0} -> {1} time(s).", item.Key, item.Value);
            }
        }
    }
}