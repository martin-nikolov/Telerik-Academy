namespace EasyPTC.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using EasyPTC.Data.Contracts;
    using EasyPTC.Data.Contracts.CodeFirstConventions;
    using EasyPTC.Data.Migrations;
    using EasyPTC.Models;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class EasyPtcDbContext : IdentityDbContext<User>, IEasyPtcDbContext
    {
        public EasyPtcDbContext()
            : this("DefaultConnection")
        {
        }

        public EasyPtcDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<EasyPtcDbContext, Configuration>());
        }

        public virtual IDbSet<Advertisement> Advertisements { get; set; }

        public virtual IDbSet<TextAdvertisement> TextAdvertisements { get; set; }

        public virtual IDbSet<Banner> Banners { get; set; }

        public virtual IDbSet<Image> Images { get; set; }

        public virtual IDbSet<Category> Categories { get; set; }

        public DbContext DbContext
        {
            get
            {
                return this;
            }
        }

        public static EasyPtcDbContext Create()
        {
            return new EasyPtcDbContext();
        }

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            this.ApplyDeletableEntityRules();
            return base.SaveChanges();
        }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Add(new IsUnicodeAttributeConvention());

            base.OnModelCreating(modelBuilder); // Without this call EntityFramework won't be able to configure the identity model
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        private void ApplyAuditInfoRules()
        {
            // Approach via @julielerman: http://bit.ly/123661P
            foreach (var entry in
                this.ChangeTracker.Entries()
                    .Where(
                         e =>
                             e.Entity is IAuditInfo && ((e.State == EntityState.Added) || (e.State == EntityState.Modified))))
            {
                var entity = (IAuditInfo)entry.Entity;

                if (entry.State == EntityState.Added)
                {
                    if (!entity.PreserveCreatedOn)
                    {
                        entity.CreatedOn = DateTime.Now;
                    }
                }
                else
                {
                    entity.ModifiedOn = DateTime.Now;
                }
            }
        }

        private void ApplyDeletableEntityRules()
        {
            // Approach via @julielerman: http://bit.ly/123661P
            foreach (
                var entry in
                this.ChangeTracker.Entries()
                    .Where(e => e.Entity is IDeletableEntity && (e.State == EntityState.Deleted)))
            {
                var entity = (IDeletableEntity)entry.Entity;

                entity.DeletedOn = DateTime.Now;
                entity.IsDeleted = true;
                entry.State = EntityState.Modified;
            }
        }
    }
}