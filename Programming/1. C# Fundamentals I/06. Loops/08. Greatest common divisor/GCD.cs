/*
* 8. Write a program that calculates the greatest common divisor
* (GCD) of given two numbers. Use the Euclidean algorithm
* (find it in Internet).
*/

using System;
using System.Linq;

class GreatestCommonDivisor
{
    static void Main()
    {
        Console.WriteLine("Enter two numbers:");
        Console.Write("   1: "); uint a = uint.Parse(Console.ReadLine());
        Console.Write("   2: "); uint b = uint.Parse(Console.ReadLine());

        while (a != b)
        {
            if (a > b)
                a = a - b;
            else
                b = b - a;
        }

        Console.WriteLine("\nGreatest common divisor: {0}\n", a);
    }
}