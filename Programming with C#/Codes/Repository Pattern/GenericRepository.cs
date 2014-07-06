namespace App.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class GenericRepository<T> : IRepository<T> where T : class
    {
        public GenericRepository()
            : this(new AppDbContext())
        {
        }

        public GenericRepository(DbContext context)
        {
            if (context == null)
            {
                throw new ArgumentException("An instance of DbContext is required to use this repository.", "context");
            }

            this.Context = context;
            this.DbSet = this.Context.Set<T>();
        }

        protected IDbSet<T> DbSet { get; set; }

        protected DbContext Context { get; set; }

        public virtual IQueryable<T> All()
        {
            return this.DbSet.AsQueryable();
        }

        public virtual T GetById(int id)
        {
            return this.DbSet.Find(id);
        }

        public virtual void Add(T entity)
        {
            DbEntityEntry entry = this.Context.Entry(entity);
            
            if (entry.State != EntityState.Detached)
            {
                entry.State = EntityState.Added;
            }
            else
            {
                this.DbSet.Add(entity);
            }
        }

        public virtual void Update(T entity)
        {
            DbEntityEntry entry = this.Context.Entry(entity);

            if (entry.State == EntityState.Detached)
            {
                this.DbSet.Attach(entity);
            }

            entry.State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            DbEntityEntry entry = this.Context.Entry(entity);
            if (entry.State != EntityState.Deleted)
            {
                entry.State = EntityState.Deleted;
            }
            else
            {
                this.DbSet.Attach(entity);
                this.DbSet.Remove(entity);
            }
        }

        public virtual void Delete(int id)
        {
            var entity = this.GetById(id);

            if (entity != null)
            {
                this.Delete(entity);
            }
        }

        public virtual void Detach(T entity)
        {
            DbEntityEntry entry = this.Context.Entry(entity);
            entry.State = EntityState.Detached;
        }

        /// <summary>
        /// This method updates database values by using expression. It works with both anonymous and class objects.
        /// It is used in one of the following ways:
        /// 1. .UpdateValues(x => new Type { Id = ..., Property = ..., AnotherProperty = ... })
        /// 2. .UpdateValues(x => new { Id = ..., Property = ..., AnotherProperty = ... })
        /// </summary>
        /// <param name="entity">Expression for the updated entity</param>
        public virtual void UpdateValues(Expression<Func<T, object>> entity)
        {
            // compile the expression to delegate and invoke it
            object compiledExpression = entity.Compile()(null);

            // cast the result of invokation to T
            T updatedEntity = compiledExpression is T ? compiledExpression as T : compiledExpression.CastTo<T>();

            // attach the entry if missing in ObjectStateManager
            var entry = this.Context.Entry(updatedEntity);

            if (entry.State == EntityState.Detached)
            {
                try
                {
                    this.DbSet.Attach(updatedEntity);
                }
                catch
                {
                    var key = this.GetPrimaryKey(entry);
                    entry = this.Context.Entry(this.DbSet.Find(key));
                    entry.CurrentValues.SetValues(updatedEntity);
                }
            }
        }

        private int GetPrimaryKey(DbEntityEntry entry)
        {
            var myObject = entry.Entity;

            var property = myObject
                .GetType()
                .GetProperties()
                .FirstOrDefault(prop => Attribute.IsDefined(prop, typeof(KeyAttribute)));

            return (int)property.GetValue(myObject, null);
        }
    }
}
