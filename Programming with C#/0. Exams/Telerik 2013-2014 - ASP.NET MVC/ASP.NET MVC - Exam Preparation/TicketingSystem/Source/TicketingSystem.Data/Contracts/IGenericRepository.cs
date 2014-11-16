namespace TicketingSystem.Data.Contracts
{
    using System;
    using System.Linq;

    public interface IGenericRepository<T> : IDisposable where T : class
    {
        IQueryable<T> All();

        T Find(object id);

        void Add(T entity);

        void Update(T entity);

        void Remove(T entity);

        void Remove(object id);

        int Count();

        void Detach(T entity);

        int SaveChanges();
    }
}