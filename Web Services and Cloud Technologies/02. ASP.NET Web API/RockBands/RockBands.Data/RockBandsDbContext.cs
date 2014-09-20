namespace RockBands.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using RockBands.Common;
    using RockBands.Data.Contracts;
    using RockBands.Data.Migrations;
    using RockBands.Models;

    public class RockBandsDbContext : DbContext, IRockBandsDbContext
    {
        public RockBandsDbContext()
            : base(ConnectionStrings.DefaultConnection)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<RockBandsDbContext, Configuration>());
        }

        public IDbSet<Album> Albums { get; set; }

        public IDbSet<Artist> Artists { get; set; }

        public IDbSet<Band> Bands { get; set; }

        public IDbSet<Song> Songs { get; set; }

        public IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public void SaveChanges()
        {
            base.SaveChanges();
        }
    }
}