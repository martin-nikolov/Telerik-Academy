namespace BookStore.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using BookStore.Data.Contracts;
    using BookStore.Data.Migrations;
    using BookStore.Models;
    
    public class BookStoreDbContext : DbContext, IBookStoreDbContext
    {
        public BookStoreDbContext()
            : base(ConnectionStrings.Default.MSSqlConnectionString)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BookStoreDbContext, Configuration>());
        }

        public IDbSet<Book> Books { get; set; }

        public IDbSet<Author> Authors { get; set; }

        public IDbSet<Review> Reviews { get; set; }
    }
}