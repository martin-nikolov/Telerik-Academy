namespace CohesionAndCoupling
{
    using System;

    public static class GeometryUtils
    {
        public static double CalcDistance2D(double x1, double y1, double x2, double y2)
        {
            double distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
            return distance;
        }

        public static double CalcDistance2D(Point p1, Point p2)
        {
            double distance = CalcDistance2D(p1.X, p1.Y, p2.X, p2.Y);
            return distance;
        }

        public static double CalcDistance3D(double x1, double y1, double z1, double x2, double y2, double z2)
        {
            double distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1) + (z2 - z1) * (z2 - z1));
            return distance;
        }

        public static double CalcDistance3D(Point p1, Point p2, Point p3)
        {
            double distance = CalcDistance3D(p1.X, p1.Y, p2.X, p2.Y, p3.X, p3.Y);
            return distance;
        }
    }
}