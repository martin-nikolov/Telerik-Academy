/*
* 1. Write an expression that checks if given integer is odd or even.
*/

using System;

class OddOrEven
{
    static void Main(string[] args)
    {
       
        Console.Write("Enter a number: ");
        int number = int.Parse(Console.ReadLine());
        Console.WriteLine("Number {0} is {1}", number, number % 2 == 0 ? "Even" : "Odd");
    }
}