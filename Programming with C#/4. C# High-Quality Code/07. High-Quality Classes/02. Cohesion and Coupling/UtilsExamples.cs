namespace CohesionAndCoupling
{
    using System;

    internal class UtilsExamples
    {
        static void Main()
        {
            Console.WriteLine(FileUtils.GetFileExtension("example"));
            Console.WriteLine(FileUtils.GetFileExtension("example.pdf"));
            Console.WriteLine(FileUtils.GetFileExtension("example.new.pdf") + "\n");

            Console.WriteLine(FileUtils.GetFileNameWithoutExtension("example"));
            Console.WriteLine(FileUtils.GetFileNameWithoutExtension("example.pdf"));
            Console.WriteLine(FileUtils.GetFileNameWithoutExtension("example.new.pdf"));

            var pointA = new Point(1, -2);
            var pointB = new Point(3, 4);
            var pointC = new Point(-6, 4);
            Console.WriteLine("\nDistance in the 2D space = {0:f2}", GeometryUtils.CalcDistance2D(pointA, pointB));
            Console.WriteLine("Distance in the 3D space = {0:f2}", GeometryUtils.CalcDistance3D(pointA, pointB, pointC));

            var prism = new RectangularParallelepiped(3, 4, 5);
            Console.WriteLine("\nVolume = {0:f2}", prism.CalcVolume());
            Console.WriteLine("Diagonal XYZ = {0:f2}", prism.CalcDiagonalXYZ());
            Console.WriteLine("Diagonal XY = {0:f2}", prism.CalcDiagonalXY());
            Console.WriteLine("Diagonal XZ = {0:f2}", prism.CalcDiagonalXZ());
            Console.WriteLine("Diagonal YZ = {0:f2}", prism.CalcDiagonalYZ());
        }
    }
}