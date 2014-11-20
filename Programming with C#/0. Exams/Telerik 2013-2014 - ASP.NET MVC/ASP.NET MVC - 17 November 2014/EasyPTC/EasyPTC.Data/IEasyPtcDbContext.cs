namespace EasyPTC.Data
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using EasyPTC.Models;

    public interface IEasyPtcDbContext
    {
        IDbSet<User> Users { get; set; }

        IDbSet<Advertisement> Advertisements { get; set; }

        IDbSet<TextAdvertisement> TextAdvertisements { get; set; }

        IDbSet<Banner> Banners { get; set; }

        IDbSet<Image> Images { get; set; }

        IDbSet<Category> Categories { get; set; }

        DbContext DbContext { get; }

        int SaveChanges();

        void Dispose();

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        IDbSet<T> Set<T>() where T : class;
    }
}