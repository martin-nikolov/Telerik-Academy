namespace RockBands.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public class Artist
    {
        [Key]
        public int ArtistId { get; set; }

        [Required]
        public string Name { get; set; }

        [ForeignKey("Band")]
        public int BandId { get; set; }

        public virtual Band Band { get; set; }
    }
}