namespace RockBands.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using RockBands.Models.Contracts;

    public class Band : ICover
    {
        private ICollection<Artist> artists;
        private ICollection<Album> albums;

        public Band()
        {
            this.artists = new HashSet<Artist>();
            this.albums = new HashSet<Album>();
        }

        [Key]
        public int BandId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public string Nationality { get; set; }

        [Required]
        public string OfficialSite { get; set; }

        [Range(0, int.MaxValue)]
        public int Rating { get; set; }

        public DateTime ReleasedAt { get; set; }

        [Required]
        public string Src { get; set; }

        public virtual ICollection<Artist> Artists
        {
            get
            {
                return this.artists;
            }
            set
            {
                this.artists = value;
            }
        }

        public virtual ICollection<Album> Albums
        {
            get
            {
                return this.albums;
            }
            set
            {
                this.albums = value;
            }
        }
    }
}