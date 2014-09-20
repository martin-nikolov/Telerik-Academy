namespace RockBands.Services.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;
    using RockBands.Models.Projections;

    public class BandsController : BaseController
    {
        [HttpGet]
        public IQueryable<Cover> All()
        {
            return this.RockBandsData.Bands
                       .GetCovers(this.RockBandsData.Bands.All().Count());
        }

        [HttpGet]
        public IQueryable<Cover> GetCovers(int count)
        {
            return this.RockBandsData.Bands
                       .GetCovers(count)
                       .OrderByDescending(b => b.Rating);
        }

        [HttpGet]
        public BandDetails GetBySrc(string src)
        {
            return this.RockBandsData.Bands
                       .All()
                       .Where(b => b.Src == src)
                       .Select(BandDetails.FromBand)
                       .FirstOrDefault();
        }

        [HttpGet]
        public int Count()
        {
            return this.RockBandsData.Bands.All().Count();
        }

        [HttpPost]
        public IHttpActionResult Vote(int bandId, bool isUpVote)
        {
            var band = this.RockBandsData.Bands.Find(bandId);
            if (band == null)
            {
                return this.BadRequest();
            }

            int newRating = band.Rating;
            if (isUpVote)
            {
                newRating++;
            }
            else if (newRating > 0)
            {
                newRating--;     
            }

            band.Rating = newRating;
            this.RockBandsData.SaveChanges();

            return this.Ok();
        }
    }
}