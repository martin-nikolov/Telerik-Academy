namespace BookStore.XML
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Linq;
    using BookStore.Models;

    public class ReviewsSearchResultsXmlExporter
    {
        private const string DateTimeFormat = "d-MMM-yyyy";
        private readonly DateTimeFormatInfo usDtfi = new CultureInfo("en-US", false).DateTimeFormat;

        public void Export(ICollection<ICollection<Review>> resultSets, string pathToSaveXml)
        {
            var searchResultsXml = new XElement("search-results");

            foreach (var resultSet in resultSets)
            {
                var resultSetXml = new XElement("result-set");

                foreach (var review in resultSet)
                {
                    var reviewXml = new XElement("review",
                        new XElement("date", review.DateOfCreation.ToString(DateTimeFormat, this.usDtfi)),
                        new XElement("content", review.Content));

                    var reviewBook = review.Book;
                    var bookXml = new XElement("book",
                        new XElement("title", reviewBook.Title));

                    this.AddAuthorsXElement(reviewBook, bookXml);
                    this.AddIsbnXElement(reviewBook, bookXml);
                    this.AddOfficialWebSiteXElement(reviewBook, bookXml);

                    reviewXml.Add(bookXml);
                    resultSetXml.Add(reviewXml);
                }

                searchResultsXml.Add(resultSetXml);
            }

            searchResultsXml.Save(new StreamWriter(pathToSaveXml, false, Encoding.UTF8));
        }
   
        private void AddAuthorsXElement(Book reviewBook, XElement bookXml)
        {
            if (reviewBook.Authors.Any())
            {
                var authorNames = reviewBook.Authors.Select(a => a.Name).OrderBy(a => a);
                var authorsAsString = string.Join(", ", authorNames);
                var authorsXml = new XElement("authors", authorsAsString);
                bookXml.Add(authorsXml);
            }
        }

        private void AddIsbnXElement(Book reviewBook, XElement bookXml)
        {
            if (!string.IsNullOrEmpty(reviewBook.ISBN))
            {
                var isbnXml = new XElement("isbn", reviewBook.ISBN);
                bookXml.Add(isbnXml);
            }
        }

        private void AddOfficialWebSiteXElement(Book reviewBook, XElement bookXml)
        {
            if (!string.IsNullOrEmpty(reviewBook.OfficialWebSite))
            {
                var urlXml = new XElement("url", reviewBook.OfficialWebSite);
                bookXml.Add(urlXml);
            }
        }
    }
}