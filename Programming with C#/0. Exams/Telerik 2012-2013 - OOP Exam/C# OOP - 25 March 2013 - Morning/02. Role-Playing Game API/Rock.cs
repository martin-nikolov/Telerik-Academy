namespace AcademyRPG
{
    using System;
    using System.Linq;

    class Rock : StaticObject, IResource
    {
        public Rock(int hitpoints, Point position)
            : base(position, 0)
        {
            this.HitPoints = hitpoints;
        }

        public int Quantity
        {
            get { return this.HitPoints / 2; }
        }

        public ResourceType Type
        {
            get { return ResourceType.Stone; }
        }
    }
}