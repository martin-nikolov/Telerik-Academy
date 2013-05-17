/*
* 6. Write a program that reads the coefficients a, b and c of
* a quadratic equation ax2+bx+c=0 and solves it (prints its real roots).
*/

using System;
using System.Linq;

class QuadraticEquation
{
    static void Main()
    {
        Console.WriteLine("Enter coefficients of quadratic equation -> a*x^2 + b*x + c = 0");

        Console.Write("   a: "); double a = double.Parse(Console.ReadLine());
        Console.Write("   b: "); double b = double.Parse(Console.ReadLine());
        Console.Write("   c: "); double c = double.Parse(Console.ReadLine());

        if (a == 0)
        {
            Console.WriteLine("\nx = {0}\n", -c / b);
        }
        else
        {
            double discriminant = b * b - 4 * a * c;

            if (discriminant == 0)
            {
                Console.WriteLine("\nx[1] = x[2] = {0}\n", -b / (2 * a));
            }
            else if (discriminant < 0)
            {
                Console.WriteLine("\nNo real roots!\n");
            }
            else if (discriminant > 0)
            {
                Console.WriteLine("\nx[1] = {0}", (-b + Math.Sqrt(discriminant)) / (2 * a));
                Console.WriteLine("x[2] = {0}\n", (-b - Math.Sqrt(discriminant)) / (2 * a));
            }
        }
    }
}