namespace UploadSystem.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using UploadSystem.Common;
    using UploadSystem.Data.Migrations;
    using UploadSystem.Models;
    
    public class UploadSystemDbContext : DbContext
    {
        public UploadSystemDbContext()
            : base(ConnectionStrings.DefaultConnection)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<UploadSystemDbContext, Configuration>());
        }

        public IDbSet<ZipFileContent> ZipFileContent { get; set; }
    }
}