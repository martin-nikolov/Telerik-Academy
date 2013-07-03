/*
* 8. Write an expression that calculates trapezoid's
* area by given sides a and b and height h.
*/

using System;
using System.Linq;

class TrapezoidArea
{
    static void Main(string[] args)
    {
        Console.WriteLine("Trapezoid's sides: ");
        Console.Write("   a = ");
        double a = double.Parse(Console.ReadLine());
        Console.Write("   b = ");
        double b = double.Parse(Console.ReadLine());
        Console.Write("   height = ");
        double height = double.Parse(Console.ReadLine());

        Console.WriteLine("\nTrapezoid area is: {0} units\n", (a + b) / 2 * height);
    }
}