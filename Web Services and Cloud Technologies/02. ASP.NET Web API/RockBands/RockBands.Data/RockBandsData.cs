namespace RockBands.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using RockBands.Data.Contracts;
    using RockBands.Data.Repositories;
    using RockBands.Models;

    public class RockBandsData : IRockBandsData
    {
        private readonly DbContext context;
        private readonly IDictionary<Type, object> repositories = new Dictionary<Type, object>();

        public RockBandsData()
            : this(new RockBandsDbContext())
        {
        }

        public RockBandsData(DbContext context)
        {
            this.context = context;
        }

        public IGenericRepository<Artist> Artists
        {
            get
            {
                return this.GetRepository<Artist>();
            }
        }

        public IAlbumRepository Albums
        {
            get
            {
                return (AlbumRepository)this.GetRepository<Album>();
            }
        }

        public ISongRepository Songs
        {
            get
            {
                return (SongRepository)this.GetRepository<Song>();
            }
        }

        public IBandRepository Bands
        {
            get
            {
                return (BandRepository)this.GetRepository<Band>();
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
            var typeOfModel = typeof(T);

            if (!this.repositories.ContainsKey(typeOfModel))
            {
                var typeOfRepository = typeof(GenericRepository<T>);

                if (typeOfModel.IsAssignableFrom(typeof(Band)))
                {
                    typeOfRepository = typeof(BandRepository);
                }
                else if (typeOfModel.IsAssignableFrom(typeof(Album)))
                {
                    typeOfRepository = typeof(AlbumRepository);
                }
                else if (typeOfModel.IsAssignableFrom(typeof(Song)))
                {
                    typeOfRepository = typeof(SongRepository);
                }

                this.repositories.Add(typeOfModel, Activator.CreateInstance(typeOfRepository, this.context));
            }

            return (IGenericRepository<T>)this.repositories[typeOfModel];
        }
    }
}