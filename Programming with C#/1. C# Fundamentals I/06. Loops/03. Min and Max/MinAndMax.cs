/*
* 3. Write a program that reads from the console a sequence
* of N integer numbers and returns the minimal and maximal of them.
*/

using System;
using System.Linq;

class MinAndMax
{
    static void Main()
    {
        Console.Write("Enter a number of numbers: ");
        byte totalNumbers = byte.Parse(Console.ReadLine());

        Console.Write("   1: ");
        int min = int.Parse(Console.ReadLine());
        int max = min;

        for (int i = 2; i <= totalNumbers; i++)
        {
            Console.Write("   {0}: ", i);
            int number = int.Parse(Console.ReadLine());
            
            if (number > max)
                max = number;
            else if (number < min)
                min = number;
        }

        Console.WriteLine("\nGreatest number: {0}", max);
        Console.WriteLine("Smaller number: {0}\n", min);
    }
}