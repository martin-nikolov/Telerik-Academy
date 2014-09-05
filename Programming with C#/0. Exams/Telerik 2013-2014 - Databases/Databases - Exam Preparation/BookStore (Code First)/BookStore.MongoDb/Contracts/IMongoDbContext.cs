namespace BookStore.MongoDb.Contracts
{
    using BookStore.MongoDb.Models;
    using MongoDB.Driver;

    public interface IMongoDbContext
    {
        MongoCollection<SearchQueryHistory> SearchQueriesHistory { get; }
    }
}