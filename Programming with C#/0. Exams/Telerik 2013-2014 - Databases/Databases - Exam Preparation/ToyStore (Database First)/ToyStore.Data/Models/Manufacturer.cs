namespace ToyStore.Data.Models
{
    using System;
    using System.Collections.Generic;

    public partial class Manufacturer
    {
        public Manufacturer()
        {
            this.Toys = new List<Toy>();
        }

        public int ManufacturerId { get; set; }

        public string Name { get; set; }

        public string Country { get; set; }

        public virtual ICollection<Toy> Toys { get; set; }
    }
}