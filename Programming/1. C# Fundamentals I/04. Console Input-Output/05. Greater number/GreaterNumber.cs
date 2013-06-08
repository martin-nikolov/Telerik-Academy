/*
* 5. Write a program that gets two numbers from the console 
* and prints the greater of them. Don’t use if statements.
*/

using System;
using System.Linq;

class GreaterNumber
{
    static void Main()
    {
        Console.WriteLine("Enter two number: ");
        
        Console.Write("   First: ");
        int first = int.Parse(Console.ReadLine());

        Console.Write("   Second: ");
        int second = int.Parse(Console.ReadLine());

        Console.WriteLine("\nGreater number: {0}\n", Math.Max(first, second));
    }
}