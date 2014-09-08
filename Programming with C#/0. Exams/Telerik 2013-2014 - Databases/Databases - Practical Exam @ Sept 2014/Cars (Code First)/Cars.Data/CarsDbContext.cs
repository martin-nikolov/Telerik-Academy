namespace Cars.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Cars.Data.Migrations;
    using Cars.Models;

    public class CarsDbContext : DbContext
    {
        public CarsDbContext()
            : base(ConnectionStrings.Default.CarsConnectionString)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CarsDbContext, Configuration>());
        }

        public IDbSet<Car> Cars { get; set; }

        public IDbSet<City> Cities { get; set; }

        public IDbSet<Dealer> Dealers { get; set; }

        public IDbSet<Manufacturer> Manufacturer { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>()
                        .Property(i => i.Price)
                        .HasColumnType("money");
        }
    }
}