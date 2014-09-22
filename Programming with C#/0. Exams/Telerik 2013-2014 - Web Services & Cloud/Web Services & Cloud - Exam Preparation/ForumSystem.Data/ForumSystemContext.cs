namespace ForumSystem.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using ForumSystem.Common;
    using ForumSystem.Data.Contracts;
    using ForumSystem.Data.Migrations;
    using ForumSystem.Models;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class ForumSystemContext : IdentityDbContext<ApplicationUser>, IForumSystemContext
    {
        public ForumSystemContext()
            : base(ConnectionStrings.DefaultConnection, throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ForumSystemContext, Configuration>());
        }

        public IDbSet<Article> Articles { get; set; }

        public IDbSet<Category> Categories { get; set; }

        public IDbSet<Comment> Comments { get; set; }

        public IDbSet<Like> Likes { get; set; }

        public IDbSet<Tag> Tags { get; set; }

        public IDbSet<Alert> Alerts { get; set; }

        public static ForumSystemContext Create()
        {
            return new ForumSystemContext();
        }
    }
}