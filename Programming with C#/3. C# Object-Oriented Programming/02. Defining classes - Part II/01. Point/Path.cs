using System;
using System.Collections.Generic;
using System.Linq;

namespace CoordinateSystem
{
    public class Path
    {
        // Constant Fields
        private const string Separator = "\n";

        private readonly List<Point3D> points = new List<Point3D>();

        // Constructor
        public Path(params Point3D[] points)
        {
            this.Add(points);
        }

        // Properties
        public int Count
        {
            get
            {
                return this.points.Count;
            }
        }
        
        public Point3D this[int index]
        {
            get
            {
                return this.points[index];
            }
            set
            {
                this.points[index] = value;
            }
        }

        // Methods
        public Path Add(params Point3D[] points)
        {
            foreach (var point in points)
                this.points.Add(point);

            return this;
        }

        public Path Remove(Point3D point)
        {
            this.points.Remove(point);

            return this;
        }

        public Path Clear()
        {
            this.points.Clear();

            return this;
        }

        // Override method
        public override string ToString()
        {
            return string.Join(Separator, this.points);
        }
    }
}