namespace AcademyRPG
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Giant : Character, IFighter, IGatherer
    {
        public Giant(string name, Point position)
            : base(name, position, 0)
        {
            this.HitPoints = 200;
            this.AttackPoints = 150;
            this.DefensePoints = 80;
        }

        public int AttackPoints { get; private set; }

        public int DefensePoints { get; private set; }

        public bool TryGather(IResource resource)
        {
            if (resource.Type.Equals(ResourceType.Stone))
            {
                this.AttackPoints += 100;
                return true;
            }

            return false;
        }

        public int GetTargetIndex(List<WorldObject> availableTargets)
        {
            for (int index = 0; index < availableTargets.Count; index++)
            {
                if (availableTargets[index].Owner != 0)
                {
                    return index;
                }
            }

            return -1;
        }
    }
}