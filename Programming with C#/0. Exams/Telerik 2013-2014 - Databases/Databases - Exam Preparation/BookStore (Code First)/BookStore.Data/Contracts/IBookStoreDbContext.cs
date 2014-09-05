namespace BookStore.Data.Contracts
{
    using System.Data.Entity;
    using BookStore.Models;

    public interface IBookStoreDbContext
    {
        IDbSet<Book> Books { get; set; }

        IDbSet<Author> Authors { get; set; }

        IDbSet<Review> Reviews { get; set; }

        int SaveChanges();
    }
}