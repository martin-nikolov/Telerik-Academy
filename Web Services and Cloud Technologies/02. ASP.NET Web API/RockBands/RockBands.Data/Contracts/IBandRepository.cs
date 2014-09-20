namespace RockBands.Data.Contracts
{
    using System.Linq;
    using RockBands.Models;
    using RockBands.Models.Projections;

    public interface IBandRepository : IGenericRepository<Band>
    {
        IQueryable<Cover> GetCovers(int count);
    }
}