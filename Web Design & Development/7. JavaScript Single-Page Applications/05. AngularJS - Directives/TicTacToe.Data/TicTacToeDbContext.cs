namespace TicTacToe.Data
{
    using System.Data.Entity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using TicTacToe.Common;
    using TicTacToe.Data.Contracts;
    using TicTacToe.Data.Migrations;
    using TicTacToe.Models;

    public class TicTacToeDbContext : IdentityDbContext<User>, ITicTacToeDbContext
    {
        public TicTacToeDbContext()
            : base(ConnectionStrings.DefaultConnection, throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TicTacToeDbContext, Configuration>());
        }

        public IDbSet<Game> Games { get; set; }

        public IDbSet<Score> Scores { get; set; }

        public static TicTacToeDbContext Create()
        {
            return new TicTacToeDbContext();
        }

        public IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public void SaveChanges()
        {
            base.SaveChanges();
        }
    }
}