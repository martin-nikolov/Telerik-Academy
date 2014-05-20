namespace Shapes
{
    using System;

    internal class FigureRotationTest
    {
        static void Main()
        {
            var width = 25.23;
            var height = 2.12;
            var figure = new Figure(width, height);

            Console.WriteLine(figure);

            var angleOfRotation = -180;
            var rotatedFigure = Figure.Rotate(figure, angleOfRotation);
            Console.WriteLine(rotatedFigure);
        }
    }
}