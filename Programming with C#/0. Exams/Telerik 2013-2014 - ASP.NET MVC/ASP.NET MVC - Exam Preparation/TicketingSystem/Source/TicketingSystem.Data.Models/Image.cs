namespace TicketingSystem.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class Image
    {
        [Key]
        public int ImageId { get; set; }

        [Required]
        public byte[] Content { get; set; }

        [Required]
        public string FileExtension { get; set; }
    }
}