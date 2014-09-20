namespace RockBands.Services.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;
    using RockBands.Models.Projections;

    public class SongsController : BaseController
    {
        [HttpGet]
        public IQueryable<Cover> All()
        {
            return this.RockBandsData.Songs
                       .GetCovers(this.RockBandsData.Songs.All().Count());
        }

        [HttpGet]
        public IQueryable<Cover> GetCovers(int count)
        {
            return this.RockBandsData.Songs
                       .GetCovers(count)
                       .OrderByDescending(b => b.Rating);
        }

        [HttpGet]
        public IQueryable<Cover> GetByBandSrc([FromUri]
                                              FilterModel songFilter)
        {
            var songs = this.RockBandsData.Songs
                            .All();

            if (songFilter != null)
            {
                if (!string.IsNullOrEmpty(songFilter.BandSrc))
                {
                    songs = songs.Where(a => a.Album.Band.Src == songFilter.BandSrc);
                }

                if (songFilter.Count.HasValue)
                {
                    songs = songs.Take(songFilter.Count.Value);
                }
            }

            return songs.Select(Cover.FromModel);
        }

        [HttpGet]
        public IQueryable<Cover> GetByAlbumId(int albumId)
        {
            return this.RockBandsData.Songs
                       .All()
                       .Where(a => a.Album.AlbumId == albumId)
                       .Select(Cover.FromModel);
        }

        [HttpGet]
        public SongDetails GetBySrc(string songSrc)
        {
            return this.RockBandsData.Songs
                       .All()
                       .Where(a => a.Src == songSrc)
                       .Select(SongDetails.FromSong)
                       .FirstOrDefault();
        }

        [HttpGet]
        public int Count()
        {
            return this.RockBandsData.Songs.All().Count();
        }

        [HttpPost]
        public IHttpActionResult Vote(int songId, bool isUpVote)
        {
            var song = this.RockBandsData.Songs.Find(songId);
            if (song == null)
            {
                return this.BadRequest();
            }

            int newRating = song.Rating;
            if (isUpVote)
            {
                newRating++;
            }
            else if (newRating > 0)
            {
                newRating--;
            }

            song.Rating = newRating;
            this.RockBandsData.SaveChanges();

            return this.Ok();
        }
    }
}