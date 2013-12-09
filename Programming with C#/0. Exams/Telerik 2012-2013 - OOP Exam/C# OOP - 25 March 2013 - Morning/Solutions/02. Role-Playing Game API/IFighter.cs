namespace AcademyRPG
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public interface IFighter : IControllable
    {
        int AttackPoints { get; }

        int DefensePoints { get; }

        int GetTargetIndex(List<WorldObject> availableTargets);
    }
}