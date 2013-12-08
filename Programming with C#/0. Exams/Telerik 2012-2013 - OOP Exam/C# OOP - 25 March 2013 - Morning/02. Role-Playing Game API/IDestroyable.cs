namespace AcademyRPG
{
    using System;
    using System.Linq;

    public interface IWorldObject
    {
        bool IsDestroyed { get; }

        int HitPoints { get; set; }

        Point Position { get; }
    }
}