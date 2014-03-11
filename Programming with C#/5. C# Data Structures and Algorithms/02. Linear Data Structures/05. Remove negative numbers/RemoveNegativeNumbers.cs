/*
 * 5. Write a program that removes from given sequence all negative numbers.
 */

using System;
using System.Collections.Generic;
using System.Linq;

class RemoveNegativeNumbers
{
    static void Main()
    {
        var numbers = ReadSequenceOfNumbers<int>();

        Console.WriteLine("All numbers: " + string.Join(" ", numbers));

        var positiveNumbers = ExtractPositiveNumbers(numbers);

        Console.WriteLine("Positive numbers: " + string.Join(" ", positiveNumbers));
    }

    static IList<T> ReadSequenceOfNumbers<T>() where T : IComparable
    {
        var numbers = new List<T>();

        string input = Console.ReadLine();

        while (!string.IsNullOrEmpty(input))
        {
            T number = (T)Convert.ChangeType(input, typeof(T));
            numbers.Add(number);

            input = Console.ReadLine();
        }

        return numbers;
    }

    /// <summary>
    /// Works for sbyte, byte, int, uint, long, ulong, double, decimal, etc.
    /// </summary>
    static IList<T> ExtractPositiveNumbers<T>(IList<T> collection) where T : IComparable
    {
        var positiveNumbers = new List<T>();

        for (int i = 0; i < collection.Count; i++)
        {
            if (collection[i].CompareTo((T)Convert.ChangeType(0, typeof(T))) > 0)
            {
                positiveNumbers.Add(collection[i]);
            }
        }

        return positiveNumbers;
    }
}