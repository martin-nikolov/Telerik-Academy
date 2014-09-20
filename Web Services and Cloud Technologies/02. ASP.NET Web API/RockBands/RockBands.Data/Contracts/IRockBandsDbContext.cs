namespace RockBands.Data.Contracts
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using RockBands.Models;

    public interface IRockBandsDbContext : IDbContext
    {
        IDbSet<Album> Albums { get; }

        IDbSet<Artist> Artists { get; }

        IDbSet<Band> Bands { get; }

        IDbSet<Song> Songs { get; }
    }
}