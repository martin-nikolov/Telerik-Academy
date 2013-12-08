namespace AcademyRPG
{
    using System;
    using System.Linq;

    public interface IGatherer : IControllable
    {
        bool TryGather(IResource resource);
    }
}