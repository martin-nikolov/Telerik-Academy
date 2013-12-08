namespace AcademyRPG
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Knight : Character, IFighter
    {
        public Knight(string name, Point position, int owner)
            : base(name, position, owner)
        {
            this.HitPoints = 100;
            this.AttackPoints = 100;
            this.DefensePoints = 100;
        }

        public int AttackPoints { get; private set; }

        public int DefensePoints { get; private set; }

        public int GetTargetIndex(List<WorldObject> availableTargets)
        {
            for (int index = 0; index < availableTargets.Count; index++)
            {
                if (availableTargets[index].Owner != 0 && availableTargets[index].Owner != this.Owner)
                {
                    return index;
                }
            }

            return -1;
        }
    }
}