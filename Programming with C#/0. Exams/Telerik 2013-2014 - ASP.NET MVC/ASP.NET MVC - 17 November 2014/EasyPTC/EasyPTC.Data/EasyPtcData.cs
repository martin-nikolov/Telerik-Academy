using System;
using System.Collections.Generic;
using EasyPTC.Data.Contracts;
using EasyPTC.Data.Repositories.Base;
using EasyPTC.Models;

namespace EasyPTC.Data
{
    public class EasyPtcData : IEasyPtcData
    {
        private readonly IEasyPtcDbContext context;

        private readonly Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        public EasyPtcData(IEasyPtcDbContext context)
        {
            this.context = context;
        }

        public IEasyPtcDbContext Context
        {
            get
            {
                return this.context;
            }
        }

        //public IRepository<T> GetGenericRepository<T>() where T : class
        //{
        //    if (typeof(T).IsAssignableFrom(typeof(DeletableEntity)))
        //    {
        //        return this.GetDeletableEntityRepository<T>();
        //    }

        //    return this.GetRepository<T>();
        //}
        public IDeletableEntityRepository<TextAdvertisement> TextAdvertisements
        {
            get
            {
                return this.GetDeletableEntityRepository<TextAdvertisement>();
            }
        }

        public IDeletableEntityRepository<Banner> Banners
        {
            get
            {
                return this.GetDeletableEntityRepository<Banner>();
            }
        }

        public IRepository<User> Users
        {
            get
            {
                return this.GetRepository<User>();
            }
        }

        public IDeletableEntityRepository<Advertisement> Advertisements
        {
            get
            {
                return this.GetDeletableEntityRepository<Advertisement>();
            }
        }

        public IDeletableEntityRepository<Category> Categories
        {
            get
            {
                return this.GetDeletableEntityRepository<Category>();
            }
        }

        /// <summary>
        /// Saves all changes made in this context to the underlying database.
        /// </summary>
        /// <returns>
        /// The number of objects written to the underlying database.
        /// </returns>
        /// <exception cref="T:System.InvalidOperationException">Thrown if the context has been disposed.</exception>
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

        private IRepository<T> GetRepository<T>() where T : class, IEntity
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(GenericRepository<T>);
                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.context));
            }

            return (IRepository<T>)this.repositories[typeof(T)];
        }

        private IDeletableEntityRepository<T> GetDeletableEntityRepository<T>() where T : class, IDeletableEntity, IEntity
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(DeletableEntityRepository<T>);
                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.context));
            }

            return (IDeletableEntityRepository<T>)this.repositories[typeof(T)];
        }
    }
}