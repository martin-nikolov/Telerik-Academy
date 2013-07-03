/*
* 7. Write a program that finds the greatest of given 5 variables.
*/

using System;
using System.Linq;

class GreatestOfGivenFiveVariables
{
    static void Main()
    {
        decimal[] numbers = { -1, 5, -4, 3, 2 };
        decimal max = numbers[0];

        Console.Write("Numbers: ");
        for (int i = 1; i < numbers.Length; i++)
        {
            Console.Write(numbers[i] + "  ");

            if (numbers[i] > max)
            {
                max = numbers[i];
            }
        }

        Console.WriteLine("\n\nGreatest number: {0}\n", max);
    }
}