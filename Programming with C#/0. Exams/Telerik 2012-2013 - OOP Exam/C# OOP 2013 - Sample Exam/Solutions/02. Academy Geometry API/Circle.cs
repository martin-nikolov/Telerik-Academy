namespace AcademyGeometry
{
    using System;
    using System.Linq;

    public class Circle : Figure, IAreaMeasurable, IFlat
    {
        public Circle(Vector3D location, double radius)
            : base(location)
        {
            this.Radius = radius;
        }

        public double Radius { get; private set; }

        public Vector3D GetNormal()
        {
            Vector3D center = this.GetCenter();

            Vector3D a = new Vector3D(center.X + this.Radius, center.Y, center.Z);
            Vector3D b = new Vector3D(center.X, center.Y + this.Radius, center.Z);

            Vector3D normal = Vector3D.CrossProduct(center - a, center - b);
            normal.Normalize();

            return normal;
        }

        public double GetArea()
        {
            return Math.PI * this.Radius * this.Radius;
        }

        public override double GetPrimaryMeasure()
        {
            return this.GetArea();
        }
    }
}