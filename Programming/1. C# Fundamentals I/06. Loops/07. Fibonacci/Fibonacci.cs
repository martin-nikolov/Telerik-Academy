/*
* 7. Write a program that reads a number N and calculates
* the sum of the first N members of the sequence of Fibonacci:
* 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, …
* Each member of the Fibonacci sequence (except the first two)
* is a sum of the previous two members.
*/

using System;
using System.Linq;
using System.Numerics;

class Fibonacci
{
    static void Main()
    {
        // The number at position 1 is 0
        Console.Write("Enter a number: ");
        uint n = uint.Parse(Console.ReadLine());

        BigInteger first = 0;
        BigInteger second = 1;
        BigInteger third = 0;
        BigInteger sum = 0;

        for (int i = 0; i < n - 1; i++)
        {
            first = second;
            second = third;
            third = first + second;
            sum = sum + third;
        }

        Console.Write("\nSum of first {0} number of the Fibonacci's sequence = {1}\n\n", n, sum);
    }
}