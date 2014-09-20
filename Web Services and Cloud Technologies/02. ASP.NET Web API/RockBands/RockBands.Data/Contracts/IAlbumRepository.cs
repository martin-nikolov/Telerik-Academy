namespace RockBands.Data.Contracts
{
    using System.Linq;
    using RockBands.Models;
    using RockBands.Models.Projections;

    public interface IAlbumRepository : IGenericRepository<Album>
    {
        IQueryable<Cover> GetCovers(int count);
    }
}