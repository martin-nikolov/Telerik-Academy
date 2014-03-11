/*
 * 1. Write a program that reads from the console a sequence 
 * of positive integer numbers. The sequence ends when empty 
 * line is entered. Calculate and print the sum and average 
 * of the elements of the sequence. Keep the sequence in List<int>.
 */

using System;
using System.Collections.Generic;
using System.Linq;

class SumAndAverage
{
    static void Main()
    {
        var positiveNumbers = ReadSequenceOfNumbers<int>();

        var sum = positiveNumbers.Where(a => a > 0).Sum();
        var average = positiveNumbers.Where(a => a > 0).Average();

        Console.WriteLine("Sum: " + sum);
        Console.WriteLine("Average: " + average);
    }

    static IEnumerable<T> ReadSequenceOfNumbers<T>() where T : IComparable
    {
        ICollection<T> numbers = new List<T>();

        string input = Console.ReadLine();

        while (!string.IsNullOrEmpty(input))
        {
            T number = (T)Convert.ChangeType(input, typeof(T));
            numbers.Add(number);

            input = Console.ReadLine();
        }

        return numbers;
    }
}