using System;
using System.IO;
using System.Linq;

namespace CoordinateSystem
{
    public static class PathStorage
    {
        public static Path Load(string filePath)
        {
            Path path = new Path();

            string content = File.ReadAllText(filePath);
            string[] points = content.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < points.Length; i++)
            {
                double[] coords = points[i].Split(new char[] { ',' },
                    StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();

                path.Add(new Point3D(coords[0], coords[1], coords[2]));
            }
            
            return path;
        }

        public static void Save(Path points, string filePath)
        {
            File.WriteAllText(filePath, points.ToString());
        }
    }
}