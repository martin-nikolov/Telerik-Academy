namespace RockBands.Models.Projections
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    public class SongDetails
    {
        public static Expression<Func<Song, SongDetails>> FromSong
        {
            get
            {
                return song => new SongDetails
                {
                    SongId = song.SongId,
                    Name = song.Name,
                    ImageUrl = song.ImageUrl,
                    Src = song.Src,
                    Rating = song.Rating,
                    BandName = song.Album.Band.Name,
                    BandSrc = song.Album.Band.Src,
                    AlbumName = song.Album.Name,
                    AlbumSrc = song.Album.Src,
                    Link = song.Link
                };
            }
        }

        public int SongId { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public string Link { get; set; }

        public int Rating { get; set; }

        public string Src { get; set; }

        public string AlbumName { get; set; }

        public string AlbumSrc { get; set; }

        public string BandName { get; set; }

        public string BandSrc { get; set; }
    }
}