namespace AcademyRPG
{
    using System;
    using System.Linq;

    public abstract class StaticObject : WorldObject
    {
        public StaticObject(Point position, int owner = 0)
            : base(position, owner)
        {
        }
    }
}