namespace AcademyEcosystem
{
    using System;
    using System.Linq;

    public abstract class Plant : Organism
    {
        protected Plant(Point location, int size)
            : base(location, size)
        {
        }

        public int GetEatenQuantity(int biteSize)
        {
            if (biteSize > this.Size)
            {
                this.IsAlive = false;
                this.Size = 0;
                return this.Size;
            }
            else
            {
                this.Size -= biteSize;
                return biteSize;
            }
        }

        public override string ToString()
        {
            return base.ToString() + " " + this.Location;
        }
    }
}