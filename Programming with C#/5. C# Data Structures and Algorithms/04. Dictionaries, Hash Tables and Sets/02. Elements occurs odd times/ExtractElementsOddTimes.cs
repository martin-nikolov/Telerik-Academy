/*
 * 2. Write a program that extracts from a given sequence of
 * strings all elements that present in it odd number of times.
 * 
 * Example: { C#, SQL, PHP, PHP, SQL, SQL } -> { C#, SQL }
 */

namespace AbstractDataStructures
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Utility;

    public class ExtractElementsOddTimes
    {
        public static void Main()
        {
            #if DEBUG
            Console.SetIn(new System.IO.StreamReader("../../input.txt"));
            #endif

            var elements = ConsoleUtility.ReadSequenceOfElements<string>().ToList();

            var elementsOddNumberOfTimes = FindElements(elements, isOddNumberOfTimes: true);
            PrintResult(elementsOddNumberOfTimes, "Elements odd number of times: ");

            var elementsEventNumberOfTimes = FindElements(elements, isOddNumberOfTimes: false);
            PrintResult(elementsEventNumberOfTimes, "Elements even number of times: ");
        }

        public static ISet<T> FindElements<T>(IList<T> collection, bool isOddNumberOfTimes)
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

        public static void PrintResult<T>(ISet<T> elements, string prefix)
        {
            Console.WriteLine(prefix + string.Join(", ", elements));
        }
    }
}