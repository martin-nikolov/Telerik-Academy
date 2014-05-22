namespace Geometria
{
    using System;
    using Geometria.Shapes;
    using Geometria.Utility;

    internal class UtilitiesTest
    {
        static void Main()
        {
            int[] elements = { 1, 2, 3 };
            Console.WriteLine("Max element: {0}\n", ArrayUtilities.FindMax(elements));

            /* --------------------------------------- */

            object number = 12.3456;
            NumberUtilities.PrintAsPercent(number);
            NumberUtilities.PrintWithFixedPoint(number);
            NumberUtilities.PrintWithRightAlignment(number);

            /* --------------------------------------- */

            var digit = 9;
            Console.WriteLine("\nDigit name of {0} is '{1}'", digit, NumberUtilities.GetDigitName(digit));

            /* --------------------------------------- */

            var a = 3.1;
            var b = 4.2;
            var c = 5.3;
            var triangleArea = ShapeUtilities.CalculateTriangleArea(a, b, c);

            Console.WriteLine("\nTriangle area: {0}\n", triangleArea);

            /* --------------------------------------- */

            var p1 = new Point(-7, 13);
            var p2 = new Point(-9, 13);

            Console.WriteLine(p1);
            Console.WriteLine(p2);

            var distanceBetweenTwoPoints = ShapeUtilities.CalculateDistanceBetweenTwoPoints(p1, p2);
            Console.WriteLine("\nDistance between two points: {0}", distanceBetweenTwoPoints);

            var areTwoPointsHorizontal = ShapeUtilities.AreTwoPointsHorizontal(p1, p2);
            Console.WriteLine("Are two points horizontal: {0}", areTwoPointsHorizontal);

            var areTwoPointsVertical = ShapeUtilities.AreTwoPointsVertical(p1, p2);
            Console.WriteLine("Are two points vertical: {0}\n", areTwoPointsVertical);           
        }
    }
}