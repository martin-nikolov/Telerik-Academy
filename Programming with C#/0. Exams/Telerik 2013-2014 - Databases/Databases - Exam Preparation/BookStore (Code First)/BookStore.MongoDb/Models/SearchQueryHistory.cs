namespace BookStore.MongoDb.Models
{
    using System;
    using System.Linq;
    using MongoDB.Bson;

    public class SearchQueryHistory
    {
        public ObjectId Id { get; set; }

        public DateTime Date { get; set; }

        public string QueryXml { get; set; }
    }
}