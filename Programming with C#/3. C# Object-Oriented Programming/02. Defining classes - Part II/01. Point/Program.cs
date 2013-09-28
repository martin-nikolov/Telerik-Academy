/*
* 1. Create a structure Point3D to hold a 3D-coordinate {X, Y, Z}
* in the Euclidian 3D space. Implement the ToString() to enable
* printing a 3D point.
* 
* 2. Add a private static read-only field to hold the start of
* the coordinate system – the point O{0, 0, 0}. Add a static
* property to return the point O.
* 
* 3. Write a static class with a static method to calculate
* the distance between two points in the 3D space.
* 
* 4. Create a class Path to hold a sequence of points in the 3D space.
* Create a static class PathStorage with static methods to save
* and load paths from a text file. Use a file format of your choice. 
*/

using System;
using CoordinateSystem;

class Program
{
    static void Main()
    {
        Point3D a = new Point3D(1, 2, 3);
        Console.WriteLine("Point({0})", a); // point A

        Point3D b = Point3D.Center;
        Console.WriteLine("Point({0}, {1}, {2})", b.X, b.Y, b.Z); // point O
        
        Console.WriteLine("Distance: {0}", Distance.Calculate(a, b)); // Calculate distance

        // Path of points
        Path path = new Path(new Point3D(1, 1, 1), new Point3D(2, 2, 2));
        path.Add(new Point3D(3, 3, 3));
        path.Remove(new Point3D(1, 1, 1));
        Console.WriteLine("\nPoints in path (total: {0})\n{1}", path.Count, path);

        path.Clear();

        // Loads new points from the file
        path = PathStorage.Load("../../input.txt");
        Console.WriteLine("\nPoints in path (total: {0})\n{1}", path.Count, path);

        // Saves the points in output file
        PathStorage.Save(path, "../../output.txt");
    }
}