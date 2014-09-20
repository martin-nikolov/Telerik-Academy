namespace RockBands.Services.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;
    using RockBands.Models.Projections;

    public class AlbumsController : BaseController
    {
        [HttpGet]
        public IQueryable<Cover> All()
        {
            return this.RockBandsData.Albums
                       .GetCovers(this.RockBandsData.Albums.All().Count());
        }

        [HttpGet]
        public IQueryable<Cover> GetCovers(int count)
        {
            return this.RockBandsData.Albums
                       .GetCovers(count)
                       .OrderByDescending(b => b.Rating);
        }

        [HttpGet]
        public IQueryable<Cover> GetByBandSrc([FromUri]
                                              FilterModel albumFilter)
        {
            var albums = this.RockBandsData.Albums
                             .All();

            if (albumFilter != null)
            {
                if (!string.IsNullOrEmpty(albumFilter.BandSrc))
                {
                    albums = albums.Where(a => a.Band.Src == albumFilter.BandSrc);
                }
                
                if (albumFilter.Count.HasValue)
                {
                    albums = albums.Take(albumFilter.Count.Value);
                }
            }
          
            return albums.Select(Cover.FromModel);
        }

        [HttpGet]
        public AlbumDetails GetBySrc(string src)
        {
            return this.RockBandsData.Albums
                       .All()
                       .Where(a => a.Src == src)
                       .Select(AlbumDetails.FromAlbum)
                       .FirstOrDefault();
        }

        [HttpGet]
        public int Count()
        {
            return this.RockBandsData.Albums.All().Count();
        }

        [HttpPost]
        public IHttpActionResult Vote(int albumId, bool isUpVote)
        {
            var album = this.RockBandsData.Albums.Find(albumId);
            if (album == null)
            {
                return this.BadRequest();
            }

            int newRating = album.Rating;
            if (isUpVote)
            {
                newRating++;
            }
            else if (newRating > 0)
            {
                newRating--;
            }

            album.Rating = newRating;
            this.RockBandsData.SaveChanges();

            return this.Ok();
        }
    }
}