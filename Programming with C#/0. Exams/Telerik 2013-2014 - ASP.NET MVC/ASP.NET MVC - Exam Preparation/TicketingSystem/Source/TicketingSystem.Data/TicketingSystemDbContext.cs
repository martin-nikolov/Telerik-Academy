namespace TicketingSystem.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Linq;
    using Microsoft.AspNet.Identity.EntityFramework;
    using TicketingSystem.Data.Contracts;
    using TicketingSystem.Data.Models;
    using iMOT.Data.Migrations;

    public class TicketingSystemDbContext : IdentityDbContext<User>, ITicketingSystemDbContext
    {
        public TicketingSystemDbContext()
            : base("name=TicketingSystemDatabase", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TicketingSystemDbContext, DefaultMigrationConfiguration>());
        }

        public IDbSet<IdentityUserRole> UserRoles { get; set; }

        public IDbSet<Ticket> Tickets { get; set; }

        public IDbSet<Category> Categories { get; set; }

        public IDbSet<Comment> Comments { get; set; }

        public IDbSet<Image> Images { get; set; }

        public static TicketingSystemDbContext Create()
        {
            return new TicketingSystemDbContext();
        }
 
        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}