/*
* 2. Write a program that prints all the numbers from 1 to N,
* that are not divisible by 3 and 7 at the same time.
*/

using System;
using System.Linq;

class NumbersNotDivisibleBy3and7
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int number = int.Parse(Console.ReadLine());

        Console.Write("\nAll number from [1] to [{0}], that are not divisible by [21]: ", number);

        for (int i = 1; i <= number; i++)
        {
            if (i % 21 != 0)
                Console.Write(i);

            if (i < number && i % 21 != 0)
                Console.Write(", ");
        }

        Console.WriteLine("\n");
    }
}