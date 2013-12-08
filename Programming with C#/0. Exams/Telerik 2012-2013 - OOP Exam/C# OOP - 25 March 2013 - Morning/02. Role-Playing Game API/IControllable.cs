namespace AcademyRPG
{
    using System;
    using System.Linq;

    public interface IControllable : IWorldObject
    {
        string Name { get; }
    }
}