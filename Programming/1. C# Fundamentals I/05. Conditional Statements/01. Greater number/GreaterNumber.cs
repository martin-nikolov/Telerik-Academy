/*
* 1. Write an if statement that examines two integer variables
* and exchanges their values if the first one is greater than
* the second one.
*/

using System;
using System.Linq;

class GreaterNumber
{
    static void Main()
    {
        Console.WriteLine("Enter 2 numbers: ");
        Console.Write("   1: "); int first = int.Parse(Console.ReadLine());
        Console.Write("   2: "); int second = int.Parse(Console.ReadLine());

        if (first > second)
        {
            int swap = first;
            first = second;
            second = swap;
        }

        Console.WriteLine("\nGreater number -> {0}", second);
        Console.WriteLine("Smaller number -> {0}\n", first);
    }
}