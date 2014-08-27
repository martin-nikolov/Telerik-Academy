namespace DatabaseConnectionsAdoNet
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BookLibrary
    {
        private readonly Book[] books =
        {
            new Book()
            {
                Title = "Allegiant (Divergent Series)",
                Author = "Veronica Roth",
                PublishDate = new DateTime(2013, 10, 22),
                ISBN = "978-0062024060"
            },
            new Book()
            {
                Title = "Anna Karenina (Modern Library Classics)",
                Author = "Leo Tolstoy",
                PublishDate = new DateTime(2000, 10, 10),
                ISBN = "978-0679783305"
            },
            new Book()
            {
                Title = "A Christmas Carol (Enriched Classics)",
                Author = "Charles Dickens",
                PublishDate = new DateTime(2013, 12, 17),
                ISBN = "1449910416"
            },
            new Book()
            {
                Title = "A Christmas Carol (Puffin Classics)",
                Author = "Charles Dickens",
                PublishDate = new DateTime(2012, 5, 17),
                ISBN = "1448682681"
            }
        };

        public ICollection<Book> Books
        {
            get
            {
                return this.books.ToList();
            }
        }
    }
}