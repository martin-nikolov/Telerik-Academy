/*
 * 6. Write a program that removes from given sequence
 * all numbers that occur odd number of times. 
 * 
 * Example: {4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2} -> {5, 3, 3, 5}
 */

namespace LinearDataStructures
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Utility;

    public class EvenOccurrencesFinder
    {
        public static void Main()
        {
            #if DEBUG
            Console.SetIn(new System.IO.StreamReader("../../input.txt"));
            #endif

            var numbers = ConsoleUtility.ReadSequenceOfElements<int>().ToList();
            var extractedElements = FindElements(numbers, isOddNumberOfTimes: false);

            PrintResult(numbers, extractedElements);
        }

        public static ISet<T> FindElements<T>(IList<T> collection, bool isOddNumberOfTimes)
        {
            var oddOccurrences = new HashSet<T>();
            var evenOccurrences = new HashSet<T>();

            foreach (var element in collection)
            {
                if (oddOccurrences.Add(element))
                {
                    // We have seen item an odd number of times
                    evenOccurrences.Remove(element);
                }
                else
                {
                    // We have seen item an even number of times
                    oddOccurrences.Remove(element);
                    evenOccurrences.Add(element);
                }
            }

            return isOddNumberOfTimes ? oddOccurrences : evenOccurrences;
        }

        public static void PrintResult<T>(IList<T> elements, ISet<T> evenNumberOfTimes)
        {
            var originalOrderOfElements = elements.Where(e => evenNumberOfTimes.Contains(e));
            Console.WriteLine("Result (original order): " + string.Join(" ", originalOrderOfElements));
        }
    }
}