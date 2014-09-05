namespace BookStore.XML
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    using BookStore.Data.Contracts;
    using BookStore.Models;

    public class BooksDataXmlImporter
    {
        private readonly IBookStoreDbContext bookStoreDbContext;

        public BooksDataXmlImporter(IBookStoreDbContext bookStoreDbContext)
        {
            this.bookStoreDbContext = bookStoreDbContext;
        }

        public void Import(string xmlFilePath)
        {
            var booksXml = XElement.Load(xmlFilePath).Elements("book");

            foreach (var bookXml in booksXml)
            {
                var book = new Book();

                var bookTitle = bookXml.Element("title").Value;
                book.Title = bookTitle;

                var bookAuthors = this.GetAuthors(bookXml);
                foreach (var author in bookAuthors)
                {
                    book.Authors.Add(author);
                }

                var bookOfficialWebSite = bookXml.Element("web-site");
                if (bookOfficialWebSite != null)
                {
                    book.OfficialWebSite = bookOfficialWebSite.Value;
                }

                var bookReviews = this.GetReviews(bookXml);
                foreach (var bookReview in bookReviews)
                {
                    book.Reviews.Add(bookReview);
                }

                var bookIsbn = bookXml.Element("isbn");
                if (bookIsbn != null)
                {
                    book.ISBN = bookIsbn.Value;
                }

                var bookPrice = bookXml.Element("price");
                if (bookPrice != null)
                {
                    book.Price = decimal.Parse(bookPrice.Value);
                }

                this.bookStoreDbContext.Books.Add(book);
                this.bookStoreDbContext.SaveChanges();
            }
        }

        private IList<Author> GetAuthors(XElement bookXml)
        {
            var authorsCollection = new List<Author>();

            var authorsXml = bookXml.Elements("authors");
            if (authorsXml != null)
            {
                foreach (var authorXElement in authorsXml.Elements("author"))
                {
                    var author = this.GetOrCreateAuthor(authorXElement.Value);
                    authorsCollection.Add(author);
                }
            }

            return authorsCollection;
        }

        private IList<Review> GetReviews(XElement bookXml)
        {
            var reviewsCollection = new List<Review>();

            var reviewsXml = bookXml.Element("reviews");
            if (reviewsXml != null)
            {
                foreach (var reviewXElement in reviewsXml.Elements("review"))
                {
                    var review = new Review();
                    this.SetAuthor(reviewXElement, review);
                    this.SetDateOfCreation(reviewXElement, review);
                    this.SetContent(reviewXElement, review);
                    reviewsCollection.Add(review);
                }
            }

            return reviewsCollection;
        }
   
        private void SetAuthor(XElement reviewXElement, Review review)
        {
            var authorAttribute = reviewXElement.Attribute("author");
            if (authorAttribute != null)
            {
                var author = this.GetOrCreateAuthor(authorAttribute.Value);
                review.Author = author;
            }
        }

        private void SetDateOfCreation(XElement reviewXElement, Review review)
        {
            var dateOfCreationAttribute = reviewXElement.Attribute("date");
            var dateOfCreation = dateOfCreationAttribute != null ? DateTime.Parse(dateOfCreationAttribute.Value) : DateTime.Now;
            review.DateOfCreation = dateOfCreation;
        }

        private void SetContent(XElement reviewXElement, Review review)
        {
            var reviewContent = reviewXElement.Value.Trim();
            review.Content = reviewContent;
        }
 
        private Author GetOrCreateAuthor(string authorName)
        {
            var author = this.bookStoreDbContext.Authors
                             .FirstOrDefault(a => a.Name == authorName);

            if (author == null)
            {
                author = new Author()
                {
                    Name = authorName
                };
            }

            return author;
        }
    }
}