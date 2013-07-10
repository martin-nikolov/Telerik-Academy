/*
* 4. Write methods that calculate the surface of a triangle by given:
* Side and an altitude to it; Three sides; Two sides and an angle between them. 
* Use System.Math.
*/

using System;
using System.Linq;

class SurfaceOfTriangle
{
    static void Main()
    {
        Console.WriteLine("Choose triangle's details to calculate its surface: ");
        Console.WriteLine("   1) Side and an altitude to it");
        Console.WriteLine("   2) Three sides");
        Console.WriteLine("   3) Two sides and an angle between them");
        Console.Write("\nEnter your choice: ");
        int userChoice = int.Parse(Console.ReadLine());

        switch (userChoice)
        {
            case 1: CalculateTriangleSideAndAltitude(); break;
            case 2: CalculateTriangleThreeSides(); break;
            case 3: CalculateTriangleTwoSidesAndAngle(); break;
            default: Console.WriteLine("\nError! Invalid input data!\n"); break;
        }
    }

    static void CalculateTriangleSideAndAltitude()
    {
        Console.Write("\nEnter side's length: ");
        double a = double.Parse(Console.ReadLine());

        Console.Write("Enter altitude's length: ");
        double h = double.Parse(Console.ReadLine());

        if (a <= 0 || h <= 0)
            throw new ArgumentOutOfRangeException();

        Console.WriteLine("\nArea: {0} units \n", (a * h) / 2);
    }

    static void CalculateTriangleThreeSides()
    {
        Console.Write("\nEnter side A: ");
        double a = double.Parse(Console.ReadLine());

        Console.Write("Enter side B: ");
        double b = double.Parse(Console.ReadLine());

        Console.Write("Enter side C: ");
        double c = double.Parse(Console.ReadLine());

        if (a <= 0 || b <= 0 || c <= 0 || a + b < c || a + b < b || b + c < a)
            throw new ArgumentOutOfRangeException();

        double p = (a + b + c) / 2;
        double area = Math.Sqrt(p * (p - a) * (p - b) * (p - c));

        Console.WriteLine("\nArea: {0} units \n", area);
    }

    static void CalculateTriangleTwoSidesAndAngle()
    {
        Console.Write("\nEnter side A: ");
        double a = double.Parse(Console.ReadLine());

        Console.Write("Enter side B: ");
        double b = double.Parse(Console.ReadLine());

        Console.Write("Enter angle's degrees: ");
        double angle = double.Parse(Console.ReadLine());

        if (a <= 0 || b <= 0 || angle <= 0 || angle >= 180)
            throw new ArgumentOutOfRangeException();

        Console.WriteLine("\nArea: {0} units \n", (a * b * Math.Sin(angle)) / 2);
    }
}