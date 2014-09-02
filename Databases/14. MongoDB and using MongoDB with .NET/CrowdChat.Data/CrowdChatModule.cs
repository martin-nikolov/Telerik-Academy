namespace CrowdChat.Data
{
    using System;
    using System.Linq;
    using System.Text;
    using CrowdChat.Models;

    public class CrowdChatModule
    {
        private readonly MongoDbContext mongoDbContext;

        public CrowdChatModule(MongoDbContext mongoDbContext)
        {
            this.mongoDbContext = mongoDbContext;
        }

        public void AddPost(Post post)
        {
            this.mongoDbContext.Posts.Insert(post);
        }

        public StringBuilder GenerateAllPostsAsString()
        {
            var postsAsString = new StringBuilder();

            foreach (var post in this.mongoDbContext.Posts.FindAll())
            {
                postsAsString.AppendLine(this.GenerateOnePostAsString(post));
            }

            if (postsAsString.Length >= 2)
            {
                postsAsString.Length -= 2;
            }

            return postsAsString;
        }
 
        public string GenerateOnePostAsString(Post post)
        {
            var formattedDate = post.PostOn.ToString("dd.MM.yyyy hh:mm:ss");
            return string.Format("[{0}] {1}: {2}", formattedDate, post.PostedBy, post.Content);
        }
    }
}