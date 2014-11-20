namespace EasyPTC.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    [Table("Banners")]
    public class Banner : Advertisement
    {
        [Required]
        public string ImageUrl { get; set; }
    }
}