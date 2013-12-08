namespace AcademyRPG
{
    using System;
    using System.Linq;

    public abstract class WorldObject : IWorldObject
    {
        public WorldObject(Point position, int owner)
        {
            this.Position = position;
            this.Owner = owner;
            this.HitPoints = 0;
        }

        public int HitPoints { get; set; }

        public int Owner { get; private set; }

        public Point Position { get; protected set; }

        public bool IsDestroyed
        {
            get { return this.HitPoints <= 0; }
        }

        public override string ToString()
        {
            return this.GetType().Name;
        }
    }
}