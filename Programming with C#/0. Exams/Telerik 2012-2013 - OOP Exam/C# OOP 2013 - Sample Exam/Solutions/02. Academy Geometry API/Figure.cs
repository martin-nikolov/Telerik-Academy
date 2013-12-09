using System;

namespace AcademyGeometry
{
    using System;
    using System.Collections.Generic;

    public abstract class Figure : ITransformable
    {
        protected List<Vector3D> vertices;

        public Figure(params Vector3D[] vertices)
        {
            this.vertices = new List<Vector3D>();
            foreach (var vertex in vertices)
            {
                this.vertices.Add(vertex);
            }
        }

        public virtual Vector3D GetCenter()
        {
            Vector3D verticesSum = new Vector3D(0, 0, 0);

            for (int i = 0; i < this.vertices.Count; i++)
            {
                verticesSum += this.vertices[i];
            }

            return verticesSum / this.vertices.Count;
        }

        public abstract double GetPrimaryMeasure();

        public void Translate(Vector3D translationVector)
        {
            for (int i = 0; i < this.vertices.Count; i++)
            {
                this.vertices[i] += translationVector;
            }
        }

        public void Scale(Vector3D scaleCenter, double scaleFactor)
        {
            for (int i = 0; i < this.vertices.Count; i++)
            {
                Vector3D centeredCurrent = this.vertices[i] - scaleCenter;

                Vector3D scaledCenteredCurrent = centeredCurrent * scaleFactor;

                this.vertices[i] = scaledCenteredCurrent + scaleCenter;
            }
        }

        public void RotateInXY(Vector3D rotCenter, double angleDegrees)
        {
            for (int i = 0; i < this.vertices.Count; i++)
            {
                Vector3D centeredCurrent = this.vertices[i] - rotCenter;

                double angleRads = angleDegrees * Math.PI / 180.0;

                Vector3D rotatedCenteredCurrent = new Vector3D(
                    centeredCurrent.X * Math.Cos(angleRads) - centeredCurrent.Y * Math.Sin(angleRads),
                    centeredCurrent.X * Math.Sin(angleRads) + centeredCurrent.Y * Math.Cos(angleRads),
                    centeredCurrent.Z);

                this.vertices[i] = rotatedCenteredCurrent + rotCenter;
            }
        }
    }
}