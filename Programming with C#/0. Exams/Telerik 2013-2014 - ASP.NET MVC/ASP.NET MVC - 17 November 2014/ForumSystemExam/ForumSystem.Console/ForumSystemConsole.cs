namespace ForumSystem.Console
{
    using System;
    using System.Linq;
    using ForumSystem.Data;

    public class ForumSystemConsole
    {
        private static ApplicationDbContext appDbContext = new ApplicationDbContext();

        internal static void Main()
        {
            Console.WriteLine(appDbContext.Posts.Count());
        }
    }
}