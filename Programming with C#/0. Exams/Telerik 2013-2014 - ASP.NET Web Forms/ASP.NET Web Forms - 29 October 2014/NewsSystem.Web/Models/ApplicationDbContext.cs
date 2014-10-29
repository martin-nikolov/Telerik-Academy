namespace NewsSystem.Web.Models
{
    using System.Data.Entity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using NewsSystem.Web.Migrations;

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
        //    : base("DefaultConnection", throwIfV1Schema: false)
            : base("MSSQL", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());
        }

        public IDbSet<Article> Articles { get; set; }

        public IDbSet<Category> Categories { get; set; }

        public IDbSet<Like> Likes { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}