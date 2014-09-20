namespace RockBands.Data.Repositories
{
    using System;
    using System.Linq;
    using RockBands.Data.Contracts;
    using RockBands.Models;
    using RockBands.Models.Projections;

    public class BandRepository : GenericRepository<Band>, IBandRepository
    {
        public BandRepository()
            : this(new RockBandsDbContext())
        {
        }

        public BandRepository(IRockBandsDbContext context)
            : base(context)
        {
        }

        public IQueryable<Cover> GetCovers(int count)
        {
            return this.All().OrderBy(a => a.Rating).Take(count).Select(Cover.FromModel);
        }
    }
}