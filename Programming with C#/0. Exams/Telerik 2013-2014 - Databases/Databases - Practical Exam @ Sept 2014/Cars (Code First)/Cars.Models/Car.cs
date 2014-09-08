namespace Cars.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public class Car
    {
        [Key]
        public int CarId { get; set; }

        [Required]
        [MaxLength(20)]
        public string Model { get; set; }

        [Required]
        public TransmissionType TransmissionType { get; set; }

        public int Year { get; set; }

        public decimal Price { get; set; }

        [ForeignKey("Manufacturer")]
        public int ManufacturerId { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }

        [ForeignKey("Dealer")]
        public int DealerId { get; set; }

        public virtual Dealer Dealer { get; set; }
    }
}