using System;
using System.Linq;

abstract class Shape
{
    private double width = 0;
    private double height = 0;

    public Shape(double width, double height)
    {
        this.Width = width;
        this.Height = height;
    }

    public double Width
    {
        get
        {
            return this.width;
        }
        set
        {
            if (value <= 0)
                throw new ArgumentException("Width cannot be less or equal to zero!");

            this.width = value;
        }
    }

    public double Height
    {
        get
        {
            return this.height;
        }
        set
        {
            if (value <= 0)
                throw new ArgumentException("Height cannot be less or equal to zero!");

            this.height = value;
        }
    }

    public abstract double CalculateSurface();

    protected string ToString(string type)
    {
        return string.Format("{0} -> Width: {1}, Height: {2}, Surface: {3}",
            type, this.Width, this.Height, this.CalculateSurface());
    }
}