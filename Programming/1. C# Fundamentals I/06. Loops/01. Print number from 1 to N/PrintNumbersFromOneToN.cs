/*
* 1. Write a program that prints all the numbers from 1 to N.
*/

using System;
using System.Linq;

class PrintNumbersFromOneToN
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int number = int.Parse(Console.ReadLine());

        Console.Write("\nAll number from [1] to [{0}]: ", number);

        for (int i = 1; i <= number; i++)
        {
            Console.Write(i);

            if (i < number)
                Console.Write(", ");
        }

        Console.WriteLine("\n");
    }
}