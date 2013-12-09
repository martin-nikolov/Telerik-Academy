namespace AcademyGeometry
{
    using System;

    public abstract class Vector
    {
        double[] components;
        double magnitude;

        protected Vector(params double[] components)
        {
            this.Dimensions = components.Length;

            this.components = new double[components.Length];

            for (int i = 0; i < components.Length; i++)
            {
                this.components[i] = components[i];
            }

            this.magnitude = this.CalculateMagnitude();
        }

        public double Magnitude
        {
            get { return this.magnitude; }
        }

        public int Dimensions { get; private set; }

        public double this[int index]
        {
            get { return this.GetComponent(index); }
            set { this.SetComponent(index, value); }
        }

        public bool IsZero()
        {
            foreach (var component in this.components)
            {
                if (component != 0)
                {
                    return false;
                }
            }

            return true;
        }

        public void Normalize()
        {
            for (int i = 0; i < this.components.Length; i++)
            {
                this.components[i] = this.components[i] / this.Magnitude;
            }
        }

        private double GetComponent(int index)
        {
            return this.components[index];
        }

        private void SetComponent(int index, double value)
        {
            this.components[index] = value;
            this.magnitude = this.CalculateMagnitude();
        }

        private double CalculateMagnitude()
        {
            double sumOfSquarredComponents = 0;
            foreach (var component in this.components)
            {
                sumOfSquarredComponents += component * component;
            }

            return Math.Sqrt(sumOfSquarredComponents);
        }
    }
}