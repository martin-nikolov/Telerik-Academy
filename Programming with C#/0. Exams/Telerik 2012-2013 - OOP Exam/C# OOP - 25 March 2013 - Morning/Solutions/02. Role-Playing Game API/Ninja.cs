namespace AcademyRPG
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Ninja : Character, IFighter, IGatherer
    {
        public Ninja(string name, Point position, int owner)
            : base(name, position, owner)
        {
            this.HitPoints = 1;
            this.AttackPoints = 0;
            this.DefensePoints = int.MaxValue;
        }

        public int AttackPoints { get; private set; }

        public int DefensePoints { get; private set; }

        public bool TryGather(IResource resource)
        {
            if (resource.Type.Equals(ResourceType.Lumber))
            {
                this.AttackPoints += resource.Quantity;
                return true;
            }

            if (resource.Type.Equals(ResourceType.Stone))
            {
                this.AttackPoints += resource.Quantity * 2;
                return true;
            }

            return false;
        }

        public int GetTargetIndex(List<WorldObject> availableTargets)
        {
            var sortedByHitPoints = availableTargets.OrderBy(i => i.HitPoints).ToList();

            for (int index = 0; index < sortedByHitPoints.Count; index++)
            {
                if (sortedByHitPoints[index].Owner != 0 && sortedByHitPoints[index].Owner != this.Owner)
                {
                    return index;
                }
            }

            return -1;
        }
    }
}