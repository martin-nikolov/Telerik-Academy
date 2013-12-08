namespace AcademyRPG
{
    using System;
    using System.Linq;

    public class Lumberjack : Character, IGatherer
    {
        public Lumberjack(string name, Point position, int owner)
            : base(name, position, owner)
        {
            this.HitPoints = 50;
        }

        public bool TryGather(IResource resource)
        {
            if (resource.Type == ResourceType.Lumber)
            {
                return true;
            }

            return false;
        }
    }
}