using System;
using System.Linq;

class Circle : Shape
{
    public Circle(double width) : base(width, width)
    {
    }

    public override double CalculateSurface()
    {
        return this.Width * this.Width * Math.PI;
    }

    public override string ToString()
    {
        return base.ToString("Circle");
    }
}