namespace EasyPTC.Data
{
    using EasyPTC.Data.Contracts;
    using EasyPTC.Models;

    public interface IEasyPtcData
    {
        IEasyPtcDbContext Context { get; }

        IDeletableEntityRepository<Advertisement> Advertisements { get; }

        IDeletableEntityRepository<TextAdvertisement> TextAdvertisements { get; }

        IDeletableEntityRepository<Banner> Banners { get; }

        IDeletableEntityRepository<Category> Categories { get; }

        IRepository<User> Users { get; }
        
        int SaveChanges();
    }
}