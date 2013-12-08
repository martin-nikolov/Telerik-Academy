namespace AcademyRPG
{
    using System;
    using System.Linq;

    public class Tree : StaticObject, IResource
    {
        public Tree(int size, Point position)
            : base(position)
        {
            this.Size = size;
            this.HitPoints = size;
        }

        public ResourceType Type 
        { 
            get { return ResourceType.Lumber; }
        }

        public int Quantity
        {
            get { return this.Size; }
        }

        protected int Size { get; private set; }
    }
}