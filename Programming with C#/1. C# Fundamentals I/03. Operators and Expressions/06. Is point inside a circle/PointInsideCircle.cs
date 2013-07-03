/*
* 6. Write an expression that checks if given point
* (x,  y) is within a circle K(O, 5).
*/

using System;
using System.Linq;

class PointInsideCircle
{
    static void Main(string[] args)
    {
        Console.WriteLine("Point(x, y) coords: ");
        Console.Write("   x= ");
        double xCoords = double.Parse(Console.ReadLine());
        Console.Write("   y= ");
        double yCoords = double.Parse(Console.ReadLine());

        if (xCoords * xCoords + yCoords * yCoords <= 25) // circleRadius = 5
            Console.WriteLine("\nPoint({0}, {1}) is INSIDE a circle K(O, 5).\n", xCoords, yCoords);
        else
            Console.WriteLine("\nPoint({0}, {1}) is OUTSIDE a circle K(O, 5).\n", xCoords, yCoords);
    }
}