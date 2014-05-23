namespace Shapes
{
    using System;

    internal class FiguresExample
    {
        static void Main()
        {
            Circle circle = new Circle(5);
            Console.WriteLine("I am a circle. My perimeter is {0:f2}. My surface is {1:f2}.",
                circle.CalcPerimeter(), circle.CalcSurface());

            Rectangle rect = new Rectangle(2, 3);
            Console.WriteLine("I am a rectangle. My perimeter is {0:f2}. My surface is {1:f2}.\n",
                rect.CalcPerimeter(), rect.CalcSurface());

            Console.WriteLine(circle);
            Console.WriteLine(rect + "\n");

            try
            {
                //var circleNegativeRadius = new Circle(-5);
                //var rectangleNegativeWidth = new Rectangle(-5, 5);
                var rectangleNegativeHeight = new Rectangle(5, -5);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}