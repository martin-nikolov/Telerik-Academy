using System;
using System.Collections.Generic;
using System.Linq;
using ProgramDioptase.CatalogItems;

namespace ProgramDioptase.Interfaces.DatabaseManager
{
    public interface ICatalogItemManager
    {
        IList<Movie> Movies { get; }

        IList<Music> Music { get; }

        IList<Game> Games { get; }
    }
}