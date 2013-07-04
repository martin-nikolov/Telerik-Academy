/*
* 2. Write a method GetMax() with two parameters that returns
* the bigger of two integers. Write a program that reads 3 
* integers from the console and prints the biggest of them
* using the method GetMax().
*/

using System;
using System.Linq;

class PrintBiggerNumber
{
    static void Main()
    {
        Console.Write("Enter first number: ");
        int a = int.Parse(Console.ReadLine());

        Console.Write("Enter second number: ");
        int b = int.Parse(Console.ReadLine());

        Console.Write("Enter third number: ");
        int c = int.Parse(Console.ReadLine());

        Console.WriteLine("\nBiggest number: {0}\n", GetMax(GetMax(a, b), c));
    }

    static int GetMax(int a, int b)
    {
        return Math.Max(a, b);
    }
}