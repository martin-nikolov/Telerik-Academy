namespace BookStore.MongoDb
{
    using System;
    using System.Linq;
    using BookStore.MongoDb.Contracts;
    using BookStore.MongoDb.Models;
    using MongoDB.Driver;
    
    public class MongoDbContext : IMongoDbContext
    {
        private readonly string connectionString;
        private readonly string databaseName;

        private MongoServer mongoServer;

        public MongoDbContext()
            : this(ConnectionStrings.Default.MongoDbConnectionString, ConnectionStrings.Default.MongoDbDefaultDatabase)
        {
        }

        public MongoDbContext(string connectionString, string databaseName)
        {
            this.connectionString = connectionString;
            this.databaseName = databaseName;
        }

        public MongoCollection<SearchQueryHistory> SearchQueriesHistory
        {
            get
            {
                return this.GetCollection<SearchQueryHistory>("Posts");
            }
        }

        private MongoCollection<T> GetCollection<T>(string collectionName)
        {
            var database = this.GetDatabase();
            return database.GetCollection<T>(collectionName);
        }

        private MongoDatabase GetDatabase()
        {
            var server = this.GetServer();
            return server.GetDatabase(this.databaseName);
        }

        private MongoServer GetServer()
        {
            if (this.mongoServer == null)
            {
                var mongoClient = new MongoClient(this.connectionString);
                this.mongoServer = mongoClient.GetServer();
            }

            return this.mongoServer;
        }
    }
}