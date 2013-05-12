/*
* 3. Write an expression that calculates rectangle’s area by given width and height.
*/

using System;
using System.Linq;

class RectangleArea
{
    static void Main(string[] args)
    {
        Console.Write("Enter rectangle's width: ");
        double width = double.Parse(Console.ReadLine());
        Console.Write("Enter rectangle's height: ");
        double height = double.Parse(Console.ReadLine());

        Console.WriteLine("Rectangle area: {0} units", width * height);
    }
}