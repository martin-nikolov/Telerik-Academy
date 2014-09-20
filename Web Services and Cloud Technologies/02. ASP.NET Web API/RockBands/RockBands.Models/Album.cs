namespace RockBands.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using RockBands.Models.Contracts;

    public class Album : ICover
    {
        [Key]
        public int AlbumId { get; set; }

        [Required]
        public string Name { get; set; }

        [Range(0, int.MaxValue)]
        public int Rating { get; set; }

        public DateTime ReleasedAt { get; set; }

        [Required]
        public string Src { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [ForeignKey("Band")]
        public int BandId { get; set; }

        public virtual Band Band { get; set; }
    }
}