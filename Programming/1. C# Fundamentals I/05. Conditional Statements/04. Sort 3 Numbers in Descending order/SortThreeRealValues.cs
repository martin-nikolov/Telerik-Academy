/*
* 4. Sort 3 real values in descending order using nested if statements.
*/

using System;
using System.Linq;

class SortThreeRealValues
{
    static void Main()
    {
        Console.WriteLine("Enter 3 real numbers: ");
        Console.Write("   1: "); double first = double.Parse(Console.ReadLine());
        Console.Write("   2: "); double second = double.Parse(Console.ReadLine());
        Console.Write("   3: "); double third = double.Parse(Console.ReadLine());
        double swap = 0;

        if (first > second)
        {
            if (first > third)
            {
                swap = first;
                first = third;
                third = swap;
            }

            if (first > second)
            {
                swap = first;
                first = second;
                second = swap;
            }
        }
        else if (second > third)
        {
            if (first > third)
            {
                swap = first;
                first = third;
                third = swap;
            }

            if (second > third)
            {
                swap = second;
                second = third;
                third = swap;
            }
        }

        Console.WriteLine("\nNumbers in descending order: {0} < {1} < {2}\n", first, second, third);
    }
}