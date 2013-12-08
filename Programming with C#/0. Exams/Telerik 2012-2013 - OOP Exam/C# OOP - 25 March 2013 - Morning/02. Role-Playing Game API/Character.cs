namespace AcademyRPG
{
    using System;
    using System.Linq;

    public abstract class Character : MovingObject, IControllable
    {
        public Character(string name, Point position, int owner)
            : base(position, owner)
        {
            this.Name = name;
        }

        public string Name { get; private set; }

        public override string ToString()
        {
            return base.ToString() + " " + this.Name;
        }
    }
}