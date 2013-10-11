/*
* 6. Write a program that prints from given array of integers
* all numbers that are divisible by 7 and 3. Use the built-in
* extension methods and lambda expressions. 
* Rewrite the same with LINQ.
*/

using System;
using System.Linq;

class Program
{
    static readonly Random rnd = new Random();

    static void Main()
    {
        int[] numbers = new int[100];

        for (int i = 0; i < numbers.Length; i++)
            numbers[i] = rnd.Next(200);

        Console.WriteLine("All numbers: {0}", string.Join(", ", numbers));
        Console.WriteLine("\nNumbers divisible by 7 and 3: ");
        Console.WriteLine("\n#1: Using built-in extension method:");

        // Built-in extension method
        var divisibleBy21 = numbers.Where(number => number % 21 == 0);

        Console.WriteLine(string.Join(" ", divisibleBy21));

        Console.WriteLine("\n#2: Using LINQ query:");

        // Linq query
        divisibleBy21 =
                       from number in numbers
                       where number % 21 == 0
                       select number;

        Console.WriteLine(string.Join(" ", divisibleBy21));
    }
}