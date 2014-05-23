namespace Shapes
{
    using System;
    using System.Linq;

    public interface IShape
    {
        double CalcPerimeter();

        double CalcSurface();
    }
}