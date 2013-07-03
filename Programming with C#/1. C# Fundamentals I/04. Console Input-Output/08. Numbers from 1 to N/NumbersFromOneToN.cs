/*
* 8. Write a program that reads an integer number n from
* the console and prints all the numbers in the interval
* [1..n], each on a single line.
*/

using System;
using System.Linq;

class NumbersFromOneToN
{
    static void Main()
    {
        Console.Write("Enter number (greater than 1): ");
        uint number = uint.Parse(Console.ReadLine());

        Console.Write("\nAll numbers in interval [1;{0}]: ", number);
        for (int i = 1; i <= number; i++)
        {
            Console.Write(i + (i < number ? ", " : "\n\n"));
        }
    }
}