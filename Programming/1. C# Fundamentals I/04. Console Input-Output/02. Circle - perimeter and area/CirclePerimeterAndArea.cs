/*
* 2. Write a program that reads the radius r of a circle and
* prints its perimeter and area.
*/

using System;
using System.Linq;

class CirclePerimeterAndArea
{
    static void Main()
    {
        Console.Write("Enter circle's radius: ");
        double r = double.Parse(Console.ReadLine());

        Console.WriteLine(" -> Perimeter: {0:F6}\n -> Area: {0:F6}\n",
            2 * r * Math.PI, r * r * Math.PI);
    }
}