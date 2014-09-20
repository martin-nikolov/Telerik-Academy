namespace RockBands.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using RockBands.Models.Contracts;

    public class Song : ICover
    {
        [Key]
        public int SongId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public string Link { get; set; }

        [Range(0, int.MaxValue)]
        public int Rating { get; set; }

        [Required]
        public string Src { get; set; }

        [ForeignKey("Album")]
        public int AlbumId { get; set; }

        public virtual Album Album { get; set; }
    }
}