namespace BookStore.ConsoleClient
{
    using System;
    using System.Linq;
    using BookStore.Common;
    using BookStore.Data;
    using BookStore.MongoDb;
    using BookStore.XML;

    public class BookStoreEntryPoint
    {
        private static BookStoreDbContext bookStoreDbContext = new BookStoreDbContext();
        private static MongoDbContext mongoDbContext = new MongoDbContext();
        
        private static BooksDataXmlImporter bookDataXmlImported = new BooksDataXmlImporter(bookStoreDbContext);
        private static ReviewQueriesXmlParser reviewsQueriesXmlParser = new ReviewQueriesXmlParser(bookStoreDbContext, mongoDbContext);
        private static ReviewsSearchResultsXmlExporter reviewsSearchResultsXmlExporter = new ReviewsSearchResultsXmlExporter();

        internal static void Main()
        {
            using (bookStoreDbContext)
            {
                Console.WriteLine("Loading...");

                if (bookStoreDbContext.Books.Any())
                {
                    return;
                }

                bookDataXmlImported.Import(Constants.ComplexBooksXmlImportFilePath);
                var searchResult = reviewsQueriesXmlParser.GetReviews(Constants.ReviewQueriesXmlImportFilePath);
                reviewsSearchResultsXmlExporter.Export(searchResult, Constants.SearchResultXmlExportFilePath);
                PrintQueryHistoryReports();
            }
        }
 
        private static void PrintQueryHistoryReports()
        {
            Console.WriteLine("\n----- Search query history (data from MongoDb): -----\n");

            foreach (var queryReport in mongoDbContext.SearchQueriesHistory.FindAll())
            {
                Console.WriteLine(queryReport.QueryXml + Environment.NewLine);
            }
        }
    }
}