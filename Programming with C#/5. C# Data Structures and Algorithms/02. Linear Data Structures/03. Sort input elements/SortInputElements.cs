/*
 * 3. Write a program that reads a sequence of integers (List<int>)
 * ending with an empty line and sorts them in an increasing order.
 */

namespace LinearDataStructures
{
    using System;
    using System.Linq;
    using Utility;

    public class SortInputElements
    {
        static void Main()
        {
            #if DEBUG
            Console.SetIn(new System.IO.StreamReader("../../input.txt"));
            #endif

            var elements = ConsoleUtility.ReadSequenceOfElements<int>();
            var sortedCollection = elements.OrderBy(a => a).ToList();

            Console.WriteLine("Sorted elements: " + string.Join(" ", sortedCollection));
        }
    }
}