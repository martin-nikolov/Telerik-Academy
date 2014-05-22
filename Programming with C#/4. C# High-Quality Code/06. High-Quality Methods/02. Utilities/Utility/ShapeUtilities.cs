namespace Geometria.Utility
{
    using System;
    using Geometria.Shapes;

    public static class ShapeUtilities
    {
        public static double CalculateDistanceBetweenTwoPoints(Point p1, Point p2)
        {
            double distance = Math.Sqrt((p2.X - p1.X) * (p2.X - p1.X) + (p2.Y - p1.Y) * (p2.Y - p1.Y));
            return distance;
        }

        public static bool AreTwoPointsHorizontal(Point p1, Point p2)
        {
            bool areTwoPointsHorizontal = p1.Y == p2.Y;
            return areTwoPointsHorizontal;
        }

        public static bool AreTwoPointsVertical(Point p1, Point p2)
        {
            bool areTwoPointsVertical = p1.X == p2.X;
            return areTwoPointsVertical;
        }
  
        public static double CalculateTriangleArea(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentException("Sides should be positive.");
            }

            if (a >= b + c || b >= a + c || c >= a + b)
            {
                throw new ArgumentException("Invalid side sizes. Cannot be form triangle with the given sizes.");
            }

            double p = (a + b + c) / 2;
            double area = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            return area;
        }
    }
}