namespace CrowdChat.ConsoleClient
{
    using System;
    using System.Linq;
    using CrowdChat.Data;
    using CrowdChat.Models;

    public class CrowdChatConsoleClient
    {
        private static readonly MongoDbContext mongoDbContext = new MongoDbContext();
        private static readonly CrowdChatModule crowdChatModule = new CrowdChatModule(mongoDbContext);

        public static void Main()
        {
            AddPost();
            PrintAllPosts();
        }
 
        private static void PrintAllPosts()
        {
            var postsAsString = crowdChatModule.GenerateAllPostsAsString(DateTime.MinValue, DateTime.MaxValue);
            Console.WriteLine(postsAsString);
            Console.WriteLine("\nNumber of posts: {0}\n", mongoDbContext.Posts.Count());
        }

        private static void AddPost()
        {
            var postWithRandomContent = new Post()
            {
                PostOn = DateTime.Now,
                Content = Guid.NewGuid().ToString(),
                PostedBy = "admin"
            };

            crowdChatModule.AddPost(postWithRandomContent);
        }
    }
}