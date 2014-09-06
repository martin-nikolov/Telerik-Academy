namespace ToyStore.Data
{
    using System.Data.Entity;
    using ToyStore.Data.Contracts;
    using ToyStore.Data.Models;
    using ToyStore.Data.Models.Mapping;

    public partial class ToyStoreContext : DbContext, IToyStoreContext
    {
        public ToyStoreContext()
            : base(ConnectionStrings.Default.ToyStoreConnectionString)
        {
        }

        static ToyStoreContext()
        {
            Database.SetInitializer<ToyStoreContext>(null);
        }

        public DbSet<AgeRange> AgeRanges { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Manufacturer> Manufacturers { get; set; }

        public DbSet<Toy> Toys { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AgeRangeMap());
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new ManufacturerMap());
            modelBuilder.Configurations.Add(new ToyMap());
        }
    }
}