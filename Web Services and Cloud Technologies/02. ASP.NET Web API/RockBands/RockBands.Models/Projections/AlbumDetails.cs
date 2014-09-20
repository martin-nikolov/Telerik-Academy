namespace RockBands.Models.Projections
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    public class AlbumDetails
    {
        public static Expression<Func<Album, AlbumDetails>> FromAlbum
        {
            get
            {
                return album => new AlbumDetails
                {
                    AlbumId = album.AlbumId,
                    Name = album.Name,
                    ImageUrl = album.ImageUrl,
                    Src = album.Src,
                    Rating = album.Rating,
                    BandName = album.Band.Name,
                    BandSrc = album.Band.Src,
                    ReleasedAt = album.ReleasedAt.Year.ToString()
                };
            }
        }

        public int AlbumId { get; set; }

        public string Name { get; set; }

        public int Rating { get; set; }

        public string ReleasedAt { get; set; }

        public string Src { get; set; }

        public string ImageUrl { get; set; }

        public string BandName { get; set; }

        public string BandSrc { get; set; }
    }
}