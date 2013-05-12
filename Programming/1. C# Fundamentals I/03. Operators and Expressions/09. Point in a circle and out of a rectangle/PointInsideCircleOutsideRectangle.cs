/*
* 9. Write an expression that checks for given point (x, y)
* if it is within the circle K( (1,1), 3) and out of the
* rectangle R(top=1, left=-1, width=6, height=2).
*/

using System;
using System.Linq;

namespace PointInsideCircleOutOfRectangle
{
    public class PointInsideCircleOutsideRectangle
    {
        public static bool InsideCircle(Point point)
        {
            sbyte circleX = 1, circleY = 1, circleRadius = 3;

            point.x = point.x - circleX;
            point.y = point.y - circleY;

            if (point.x * point.x + point.y * point.y <= circleRadius * circleRadius)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool InsideRectangle(Point point)
        {
            sbyte rxLeft = -1, ryTop = 1, rxRight = 5, ryBottom = -1;

            if ((point.x >= rxLeft && point.x <= rxRight) && (point.y >= ryBottom && point.y <= ryTop))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static void Main(string[] args)
        {
            Point point = new Point();
            Console.WriteLine("Point(x, y) coords: ");
            Console.Write("   x= ");
            point.x = double.Parse(Console.ReadLine());
            Console.Write("   y= ");
            point.y = double.Parse(Console.ReadLine());
         
            if (InsideCircle(point) && InsideRectangle(point))
            {
                Console.WriteLine("\nPoint({0},{1}) is inside a circle and inside a rectangle\n", point.x, point.y);
            }
            else if (!InsideCircle(point) && !InsideRectangle(point))
            {
                Console.WriteLine("\nPoint({0},{1}) is out of circle and out of rectangle\n", point.x, point.y);
            }
            else if (InsideCircle(point) && !InsideRectangle(point))
            {
                Console.WriteLine("\nPoint({0},{1}) is inside a circle and out of rectangle\n", point.x, point.y);
            }
            else if (!InsideCircle(point) && InsideRectangle(point))
            {
                Console.WriteLine("\nPoint({0},{1}) is out of circle and inside a rectangle\n", point.x, point.y);
            }
        }

        public struct Point
        {
            public double x;
            public double y;
        }
    }
}