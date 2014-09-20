namespace RockBands.Models.Projections
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    public class BandDetails
    {
        public static Expression<Func<Band, BandDetails>> FromBand
        {
            get
            {
                return band => new BandDetails
                {
                    BandId = band.BandId,
                    Name = band.Name,
                    ImageUrl = band.ImageUrl,
                    Nationality = band.Nationality,
                    OfficialSite = band.OfficialSite,
                    Src = band.Src,
                    Rating = band.Rating,
                    ReleasedAt = band.ReleasedAt.Year,
                    BandMembers = band.Artists.Select(a => a.Name).ToList()
                };
            }
        }

        public int BandId { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public string Nationality { get; set; }

        public string OfficialSite { get; set; }

        public int Rating { get; set; }

        public int ReleasedAt { get; set; }

        public string Src { get; set; }

        public ICollection<string> BandMembers { get; set; }
    }
}