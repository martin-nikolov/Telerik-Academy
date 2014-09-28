namespace TicTacToe.Data.UnitOfWork
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using TicTacToe.Data.Contracts;
    using TicTacToe.Data.Repositories;
    using TicTacToe.Models;

    public class TicTacToeData : ITicTacToeData
    {
        private DbContext context;
        private IDictionary<Type, object> repositories;

        public TicTacToeData()
            : this(new TicTacToeDbContext())
        {
        }

        public TicTacToeData(DbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IGenericRepository<User> Users
        {
            get
            {
                return this.GetRepository<User>();
            }
        }

        public IGenericRepository<Game> Games
        {
            get
            {
                return this.GetRepository<Game>();
            }
        }

        public IGenericRepository<Score> Scores
        {
            get
            {
                return this.GetRepository<Score>();
            }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        public void Dispose()
        {
            this.Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.context != null)
                {
                    this.context.Dispose();
                }
            }
        }

        private IGenericRepository<T> GetRepository<T>() where T : class
        {
            var typeOfRepository = typeof(T);
            if (!this.repositories.ContainsKey(typeOfRepository))
            {
                var newRepository = Activator.CreateInstance(typeof(GenericRepository<T>), this.context);
                this.repositories.Add(typeOfRepository, newRepository);
            }

            return (IGenericRepository<T>)this.repositories[typeOfRepository];
        }
    }
}