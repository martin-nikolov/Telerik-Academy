namespace RockBands.Models.Projections
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using RockBands.Models.Contracts;

    public class Cover
    {
        public static Expression<Func<ICover, Cover>> FromModel
        {
            get
            {
                return cover => new Cover
                {
                    Name = cover.Name,
                    ImageUrl = cover.ImageUrl,
                    Src = cover.Src,
                    Rating = cover.Rating
                };
            }
        }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public string Src { get; set; }

        public int Rating { get; set; }
    }
}