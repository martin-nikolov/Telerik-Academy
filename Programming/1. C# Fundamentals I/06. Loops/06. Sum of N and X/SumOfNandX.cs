/*
* 6. Write a program that, for a given two integer numbers
* N and X, calculates the sum:
* S = 1 + 1!/X + 2!/X2 + … + N!/XN
*/

using System;
using System.Linq;

class SumOfNandX
{
    static void Main()
    {
        Console.Write("Enter N: ");
        uint n = uint.Parse(Console.ReadLine());

        Console.Write("Enter X: ");
        uint x = uint.Parse(Console.ReadLine());

        decimal sum = 1m;
        for (int i = 1; i <= n; i++)
        {
            // Calculate factorial i!
            decimal factorial = i;
            factorial = CalculateFactorial(factorial);

            sum = sum + factorial / (decimal)Math.Pow(x, i);
        }

        Console.WriteLine("\nSum = {0}\n", sum);
    }

    static decimal CalculateFactorial(decimal number)
    {
        if (number < 1) return 1;

        return number * CalculateFactorial(number - 1);
    }
}