/*
* 1. Write a program that reads 3 integer numbers from the
* console and prints their sum.
*/

using System;
using System.Linq;

class SumOfThreeNumbers
{
    static void Main()
    {
        Console.WriteLine("Enter 3 numbers ->");
        decimal[] numbers = new decimal[3];

        for (int i = 0; i < numbers.Length; i++)
        {
            Console.Write("{0}: ", i + 1);
            numbers[i] = decimal.Parse(Console.ReadLine());
        }

        Console.WriteLine("Sum of numbers: {0}", numbers.Sum());
    }
}