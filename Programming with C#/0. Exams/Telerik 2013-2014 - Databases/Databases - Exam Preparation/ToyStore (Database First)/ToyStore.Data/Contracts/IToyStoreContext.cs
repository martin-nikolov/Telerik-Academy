namespace ToyStore.Data.Contracts
{
    using System.Data.Entity;
    using ToyStore.Data.Models;

    public interface IToyStoreContext
    {
        DbSet<AgeRange> AgeRanges { get; set; }

        DbSet<Category> Categories { get; set; }

        DbSet<Manufacturer> Manufacturers { get; set; }

        DbSet<Toy> Toys { get; set; }

        int SaveChanges();
    }
}