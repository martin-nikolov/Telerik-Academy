namespace RockBands.Data.Repositories
{
    using System;
    using System.Linq;
    using RockBands.Data.Contracts;
    using RockBands.Models;
    using RockBands.Models.Projections;

    public class SongRepository : GenericRepository<Song>, ISongRepository
    {
        public SongRepository()
            : this(new RockBandsDbContext())
        {
        }

        public SongRepository(IRockBandsDbContext context)
            : base(context)
        {
        }

        public IQueryable<Cover> GetCovers(int count)
        {
            return this.All().OrderBy(a => a.Rating).Take(count).Select(Cover.FromModel);
        }
    }
}