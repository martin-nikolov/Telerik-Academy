namespace ToyStore.Data.Models
{
    using System;
    using System.Collections.Generic;

    public partial class Category
    {
        public Category()
        {
            this.Toys = new List<Toy>();
        }

        public int CategoryId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Toy> Toys { get; set; }
    }
}