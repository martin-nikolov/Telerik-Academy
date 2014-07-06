namespace App.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IRepository<T> where T : class
    {
        IQueryable<T> All();

        T GetById(int id);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        void Delete(int id);

        void Detach(T entity);

        void UpdateValues(Expression<Func<T, object>> entity);
    }
}
