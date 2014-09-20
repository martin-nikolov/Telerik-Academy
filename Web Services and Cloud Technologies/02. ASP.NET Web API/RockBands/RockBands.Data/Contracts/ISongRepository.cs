namespace RockBands.Data.Contracts
{
    using System.Linq;
    using RockBands.Models;
    using RockBands.Models.Projections;

    public interface ISongRepository : IGenericRepository<Song>
    {
        IQueryable<Cover> GetCovers(int count);
    }
}