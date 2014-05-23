namespace Shapes
{
    using System;

    public class Circle : Shape
    {
        private double radius;

        public Circle(double radius)
        {
            this.Radius = radius;
        }

        public double Radius
        {
            get { return this.radius; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Circle radius cannot be less or equal to zero!");
                }

                this.radius = value;
            }
        }

        public override double CalcPerimeter()
        {
            double perimeter = 2 * Math.PI * this.Radius;
            return perimeter;
        }

        public override double CalcSurface()
        {
            double surface = this.Radius * this.Radius * Math.PI;
            return surface;
        }

        public override string ToString()
        {
            string output = string.Format("{0}, Radius: {1}", base.ToString(), this.Radius);
            return output;
        }
    }
}