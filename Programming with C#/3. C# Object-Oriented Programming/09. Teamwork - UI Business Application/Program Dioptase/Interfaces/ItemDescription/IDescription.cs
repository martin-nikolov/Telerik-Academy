using System;
using System.Collections.Generic;
using System.Linq;

namespace ProgramDioptase.Interfaces.ItemDescription
{
    public interface IDescription
    {
        string Name { get; }

        IList<string> Genres { get; }

        string ReleaseYear { get; }
    }
}