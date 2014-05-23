namespace CohesionAndCoupling
{
    using System;
    using System.Linq;

    public struct Point
    {
        public double X, Y;

        public Point(double x, double y)
            : this()
        {
            this.X = x;
            this.Y = y;
        }

        public override string ToString()
        {
            string output = string.Format("{0}(x={1};y={2})",
                this.GetType().Name, this.X, this.Y);

            return output;
        }
    }
}