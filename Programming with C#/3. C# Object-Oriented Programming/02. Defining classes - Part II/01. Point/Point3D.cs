using System;
using System.Linq;

namespace CoordinateSystem
{
    public struct Point3D
    {
        // Constan field
        private static readonly Point3D center = new Point3D(0, 0, 0);

        // Constructor
        public Point3D(double x, double y, double z) : this()
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        // Property for point.O
        public static Point3D Center
        {
            get
            {
                return center;
            }
        }

        // Properties for coordinates
        public double X { get; private set; }

        public double Y { get; private set; }

        public double Z { get; private set; }

        // Override method
        public override string ToString()
        {
            return string.Format("{0}, {1}, {2}", this.X, this.Y, this.Z);
        }
    }
}