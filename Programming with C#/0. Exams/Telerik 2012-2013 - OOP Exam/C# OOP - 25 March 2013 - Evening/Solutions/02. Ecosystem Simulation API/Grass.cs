namespace AcademyEcosystem
{
    using System;
    using System.Linq;

    class Grass : Plant
    {
        private const int GrassSize = 2;

        public Grass(Point location)
            : base(location, GrassSize)
        {
        }

        public override void Update(int time)
        {
            if (this.IsAlive)
            {
                this.Size += time;
            }
        }
    }
}