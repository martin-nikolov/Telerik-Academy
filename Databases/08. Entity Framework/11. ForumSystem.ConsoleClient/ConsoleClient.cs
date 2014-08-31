namespace ForumSystem.ConsoleClient
{
    using System;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using ForumSystem.Data;
    using ForumSystem.Models;

    /// <remarks>
    /// In all versions of Entity Framework, whenever you execute SaveChanges() 
    /// to insert, update or delete on the database the framework will wrap that 
    /// operation in a transaction. This transaction lasts only long enough to 
    /// execute the operation and then completes. When you execute another such 
    /// operation a new transaction is started.
    /// 
    /// More information: https://coderwall.com/p/jnniww
    /// </remarks>
    public class ConsoleClient
    {
        public static void Main()
        {
            // IMPORTANT: Change the connection string in App.config file.

            AddUserAndGroup();
        }

        /// <summary>
        /// Started the transaction implicitly. 
        /// </summary>
        private static void AddUserAndGroup()
        {
            using (var forumSystemContext = new ForumSystemContext())
            {
                try
                {
                    var adminGroup = GetOrCreateAdminGroup(forumSystemContext);
                    CreateUser(adminGroup, forumSystemContext);

                    forumSystemContext.SaveChanges();

                    Console.WriteLine("User and Group was created successfully!");
                }
                catch (DbUpdateException se)
                {
                    Console.WriteLine("Error: " + se.InnerException.InnerException.Message);
                }
            }
        }

        private static Group GetOrCreateAdminGroup(ForumSystemContext forumSystemContext)
        {
            var adminGroup = forumSystemContext.Groups.FirstOrDefault(g => g.GroupName == "Admins");

            if (adminGroup == null)
            {
                adminGroup = new Group()
                {
                    GroupName = "Admins"
                };

                forumSystemContext.Groups.Add(adminGroup);
            }

            return adminGroup;
        }

        private static void CreateUser(Group adminGroup, ForumSystemContext forumSystemContext)
        {
            var user = new User()
            {
                FirstName = "John",
                LastName = "Snow",
                Nickname = "Bastard",
                Group = adminGroup
            };

            forumSystemContext.Users.Add(user);
        }
    }
}