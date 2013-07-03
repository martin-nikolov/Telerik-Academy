/*
* 9. Write a program to print the first 100 members of
* the sequence of Fibonacci: 0, 1, 1, 2, 3, 5, 8, 13,
* 21, 34, 55, 89, 144, 233, 377, …
*/

using System;
using System.Linq;
using System.Numerics;

class Fibonacci
{
    static void Main()
    {
        BigInteger first = 0;
        BigInteger second = 1;
        BigInteger third = 0;

        Console.WriteLine("Fibonacci sequence (first 100 members): \n");
        for (int i = 0; i < 100; i++)
        {
            Console.Write(third + (i < 99 ? ", " : "\n\n"));

            first = second;
            second = third;
            third = first + second;
        }
    }
}