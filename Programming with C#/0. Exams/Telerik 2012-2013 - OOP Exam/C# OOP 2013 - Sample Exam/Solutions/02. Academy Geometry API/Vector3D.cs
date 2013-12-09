namespace AcademyGeometry
{
    using System;

    public class Vector3D : Vector
    {
        private const int XComponentIndex = 0;

        private const int YComponentIndex = 1;

        private const int ZComponentIndex = 2;

        public Vector3D(double x, double y, double z)
            : base(x, y, z)
        {
        }

        public double X
        {
            get { return this[Vector3D.XComponentIndex]; }
            set { this[Vector3D.XComponentIndex] = value; }
        }

        public double Y
        {
            get { return this[Vector3D.YComponentIndex]; }
            set { this[Vector3D.YComponentIndex] = value; }
        }

        public double Z
        {
            get { return this[Vector3D.ZComponentIndex]; }
            set { this[Vector3D.ZComponentIndex] = value; }
        }

        public static double DotProduct(Vector3D a, Vector3D b)
        {
            double result = 0;
            for (int d = 0; d < 3; d++)
            {
                result += a[d] * b[d];
            }

            return result;
        }

        public static double GetAngleDegrees(Vector3D a, Vector3D b)
        {
            return Math.Acos(Vector3D.DotProduct(a, b) / a.Magnitude * b.Magnitude);
        }

        public static Vector3D CrossProduct(Vector3D a, Vector3D b)
        {
            double crossX = a.Y * b.Z - a.Z * b.Y;
            double crossY = a.Z * b.X - a.X * b.Z;
            double crossZ = a.X * b.Y - a.Y * b.X;

            return new Vector3D(crossX, crossY, crossZ);
        }

        public static Vector3D Parse(string s)
        {
            s = s.Remove(0, 1);
            s = s.Remove(s.Length - 1, 1);

            string[] componentStrings = s.Split(',');

            return new Vector3D(
                double.Parse(componentStrings[0]),
                double.Parse(componentStrings[1]),
                double.Parse(componentStrings[2]));
        }

        public override string ToString()
        {
            return String.Format("({0:0.00},{1:0.00},{2:0.00})", this.X, this.Y, this.Z);
        }

        public static Vector3D operator +(Vector3D a, Vector3D b)
        {
            return new Vector3D(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }

        public static Vector3D operator -(Vector3D a, Vector3D b)
        {
            return new Vector3D(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        }

        public static Vector3D operator *(Vector3D v, double scale)
        {
            return new Vector3D(v.X * scale, v.Y * scale, v.Z * scale);
        }

        public static Vector3D operator /(Vector3D v, double scale)
        {
            return new Vector3D(v.X / scale, v.Y / scale, v.Z / scale);
        }
    }
}