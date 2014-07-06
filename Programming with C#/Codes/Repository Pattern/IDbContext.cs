namespace App.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public interface IDbContext : IDisposable
    {
        IDbSet<Model> Models { get; }

        DbContext DbContext { get; }

        int SaveChanges();

        void ClearDatabase();

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        IDbSet<T> Set<T>() where T : class;
    }
}
