namespace CrowdChat.Models
{
    using System;
    using System.Linq;
    using MongoDB.Bson;

    public class Post
    {
        public ObjectId Id { get; set; }

        public string Content { get; set; }

        public DateTime PostOn { get; set; }

        public string PostedBy { get; set; }
    }
}