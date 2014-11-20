namespace EasyPTC.Data.Repositories.Base
{
    using EasyPTC.Data.Contracts;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class DeletableEntityRepository<T> :
    GenericRepository<T>, IDeletableEntityRepository<T> where T : class, IDeletableEntity, IEntity
    {
        public DeletableEntityRepository(IEasyPtcDbContext context)
            : base(context)
        {
        }

        public override IQueryable<T> All()
        {
            return base.All().Where(x => !x.IsDeleted);
        }

        public IQueryable<T> AllWithDeleted()
        {
            return base.All();
        }

        public override void Delete(T entity)
        {
            entity.DeletedOn = DateTime.Now;
            entity.IsDeleted = true;

            var entry = this.Context.Entry(entity);
            entry.State = EntityState.Modified;
        }
    }
}