namespace ToyStore.Data.Models
{
    using System;
    using System.Collections.Generic;

    public partial class Toy
    {
        public Toy()
        {
            this.Categories = new List<Category>();
        }

        public int ToyId { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public int ManufacturerId { get; set; }

        public decimal Price { get; set; }

        public string Color { get; set; }

        public Nullable<int> AgeRangeId { get; set; }

        public virtual AgeRange AgeRange { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
    }
}