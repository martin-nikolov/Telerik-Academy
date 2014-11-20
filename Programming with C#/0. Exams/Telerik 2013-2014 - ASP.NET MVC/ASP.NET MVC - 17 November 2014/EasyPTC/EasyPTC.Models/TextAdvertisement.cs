namespace EasyPTC.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    [Table("TextAdvertisements")]
    public class TextAdvertisement : Advertisement
    {
        [Required]
        [MaxLength(256)]
        public string Content { get; set; }
    }
}