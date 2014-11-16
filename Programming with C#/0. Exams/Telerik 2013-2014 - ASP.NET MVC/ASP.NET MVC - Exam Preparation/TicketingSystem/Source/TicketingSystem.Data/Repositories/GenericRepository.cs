namespace iMOT.Data.Repositories
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using TicketingSystem.Data;
    using TicketingSystem.Data.Contracts;

    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public GenericRepository()
            : this(new TicketingSystemDbContext())
        {
        }

        public GenericRepository(ITicketingSystemDbContext context)
        {
            if (context == null)
            {
                throw new ArgumentException("An instance of DbContext is required to use this repository.", "context");
            }

            this.Context = context;
            this.DbSet = this.Context.Set<T>();
        }

        protected IDbSet<T> DbSet { get; set; }

        protected ITicketingSystemDbContext Context { get; set; }

        public virtual IQueryable<T> All()
        {
            return this.DbSet.AsQueryable();
        }
    
        public virtual T Find(object id)
        {
            return this.DbSet.Find(id);
        }

        public virtual void Add(T entity)
        {
            this.ChangeEntityState(entity, EntityState.Added);
        }

        public virtual void Update(T entity)
        {
            this.ChangeEntityState(entity, EntityState.Modified);
        }

        public virtual void Remove(T entity)
        {
            this.ChangeEntityState(entity, EntityState.Deleted);
        }

        public virtual void Remove(object id)
        {
            var entity = this.Find(id);
            if (entity != null)
            {
                this.Remove(entity);
            }
        }

        public int Count()
        {
            return this.DbSet.Count();
        }

        public virtual void Detach(T entity)
        {
            this.ChangeEntityState(entity, EntityState.Detached);
        }

        public int SaveChanges()
        {
            return this.Context.SaveChanges();
        }

        public void Dispose()
        {
            this.Context.Dispose();
        }

        protected void ChangeEntityState(T entity, EntityState newEntityState)
        {
            var entry = this.Context.Entry(entity);
            entry.State = newEntityState;
        }
    }
}