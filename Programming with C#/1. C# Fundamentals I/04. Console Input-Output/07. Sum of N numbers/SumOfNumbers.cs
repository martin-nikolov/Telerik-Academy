/*
* 7. Write a program that gets a number n and after that
* gets more n numbers and calculates and prints their sum. 
*/

using System;
using System.Linq;

class SumOfNumbers
{
    static void Main()
    {
        Console.Write("Enter number of numbers: ");
        int numberCount = int.Parse(Console.ReadLine());

        long sumOfNumbers = 0;

        for (int i = 0; i < numberCount; i++)
        {
            Console.Write("{0}: ", i + 1);
            int number = int.Parse(Console.ReadLine());
            sumOfNumbers = sumOfNumbers + number;
        }

        Console.WriteLine("\nSum of all numbers: {0}\n", sumOfNumbers);
    }
}