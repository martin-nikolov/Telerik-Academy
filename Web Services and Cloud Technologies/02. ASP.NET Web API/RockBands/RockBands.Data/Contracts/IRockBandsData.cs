namespace RockBands.Data.Contracts
{
    using System;
    using System.Linq;
    using RockBands.Models;

    public interface IRockBandsData : IDisposable
    {
        IGenericRepository<Artist> Artists { get; }

        IAlbumRepository Albums { get; }

        IBandRepository Bands { get; }

        ISongRepository Songs { get; }

        int SaveChanges();
    }
}