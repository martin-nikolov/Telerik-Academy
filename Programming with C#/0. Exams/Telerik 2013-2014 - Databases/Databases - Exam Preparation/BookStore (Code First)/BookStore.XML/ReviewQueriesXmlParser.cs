namespace BookStore.XML
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    using BookStore.Data.Contracts;
    using BookStore.Models;
    using BookStore.MongoDb;
    using BookStore.MongoDb.Contracts;
    using BookStore.MongoDb.Models;

    public class ReviewQueriesXmlParser
    {
        private readonly IBookStoreDbContext bookStoreDbContext;
        private readonly IMongoDbContext mongoDbContext;

        public ReviewQueriesXmlParser(IBookStoreDbContext bookStoreDbContext)
            : this(bookStoreDbContext, new MongoDbContext())
        {
        }

        public ReviewQueriesXmlParser(IBookStoreDbContext bookStoreDbContext, IMongoDbContext mongoDbContext)
        {
            this.bookStoreDbContext = bookStoreDbContext;
            this.mongoDbContext = mongoDbContext;
        }

        public ICollection<ICollection<Review>> GetReviews(string xmlFilePath)
        {
            var queriesXml = XElement.Load(xmlFilePath).Elements("query");

            var searchResults = new List<ICollection<Review>>();
            var resultSet = this.bookStoreDbContext.Reviews.AsQueryable();

            foreach (var query in queriesXml)
            {
                this.AddSearchQueryReportToMongoDb(query);

                var queryType = query.Attribute("type").Value;

                if (queryType == "by-period")
                {
                    resultSet = this.MakeQueryByPeriod(query, resultSet);
                }
                else if (queryType == "by-author")
                {
                    resultSet = this.MakeQueryByAuthor(query, resultSet);
                }

                searchResults.Add(this.GetSortReviewsByDateOfCreationAndContent(resultSet));
            }

            return searchResults;
        }

        private void AddSearchQueryReportToMongoDb(XElement query)
        {
            this.mongoDbContext.SearchQueriesHistory.Insert(new SearchQueryHistory()
            {
                QueryXml = query.ToString(),
                Date = DateTime.Now
            });
        }
 
        private IQueryable<Review> MakeQueryByPeriod(XElement query, IQueryable<Review> resultSet)
        {
            var startDate = DateTime.Parse(query.Element("start-date").Value);
            var endDate = DateTime.Parse(query.Element("end-date").Value);

            resultSet = resultSet.Where(r => r.DateOfCreation >= startDate && r.DateOfCreation <= endDate);
            return resultSet;
        }

        private IQueryable<Review> MakeQueryByAuthor(XElement query, IQueryable<Review> resultSet)
        {
            var authorName = query.Element("author-name").Value;

            resultSet = resultSet.Where(r => r.Author.Name == authorName);
            return resultSet;
        }

        private IList<Review> GetSortReviewsByDateOfCreationAndContent(IQueryable<Review> resultSet)
        {
            return resultSet.OrderBy(r => r.DateOfCreation)
                            .ThenBy(r => r.Content)
                            .ToList();
        }
    }
}