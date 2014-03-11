/*
 * 3. Write a program that reads a sequence of integers (List<int>)
 * ending with an empty line and sorts them in an increasing order.
 */
using System;
using System.Collections.Generic;
using System.Linq;

class SortInputElements
{
    static void Main()
    {
        var elements = ReadSequenceOfElements<int>();

        var sortedCollection = elements.OrderBy(a => a).ToList();

        Console.WriteLine("Sorted elements: " + string.Join(" ", sortedCollection));
    }

    static IList<T> ReadSequenceOfElements<T>() where T : IComparable
    {
        IList<T> elements = new List<T>();

        string input = Console.ReadLine();

        while (!string.IsNullOrEmpty(input))
        {
            T element = (T)Convert.ChangeType(input, typeof(T));
            elements.Add(element);

            input = Console.ReadLine();
        }

        return elements;
    }
}