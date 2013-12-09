namespace AcademyRPG
{
    using System;
    using System.Linq;

    public interface IResource : IWorldObject
    {
        int Quantity { get; }

        ResourceType Type { get; }
    }
}