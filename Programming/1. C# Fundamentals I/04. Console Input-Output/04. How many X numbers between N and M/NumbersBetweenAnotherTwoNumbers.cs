/*
* 4. Write a program that reads two positive integer numbers and prints
* how many numbers p exist between them such that the reminder
* of the division by 5 is 0 (inclusive). Example: p(17,25) = 2.
*/

using System;
using System.Linq;

class NumbersBetweenAnotherTwoNumbers
{
    static void Main()
    {
        Console.WriteLine("Enter two number: ");
        Console.Write("   First: "); int first = int.Parse(Console.ReadLine());
        Console.Write("   Second: "); int second = int.Parse(Console.ReadLine());

        if (first == second || (first < 5 && second < 5))
        {
            Console.WriteLine("\nNo numbers divisible by 5 between {0} and {1}...\n", first, second);
            return;
        }
        else if (first > second)
        {
            int swap = first;
            first = second;
            second = swap;
        }
        
        Console.Write("\nNumbers divisible by 5 in interval [{0};{1}]: ", first, second);
        
        for (int i = first; i <= second; i++)
        {
            if (i % 5 == 0)
                Console.Write(i + (i < second ? ", " : ""));
        }

        Console.WriteLine("\n");
    }
}