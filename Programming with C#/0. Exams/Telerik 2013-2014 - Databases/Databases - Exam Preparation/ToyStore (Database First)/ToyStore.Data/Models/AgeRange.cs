namespace ToyStore.Data.Models
{
    using System;
    using System.Collections.Generic;

    public partial class AgeRange
    {
        public AgeRange()
        {
            this.Toys = new List<Toy>();
        }

        public int AgeRangeId { get; set; }

        public int MinAge { get; set; }

        public Nullable<int> MaxAge { get; set; }

        public virtual ICollection<Toy> Toys { get; set; }
    }
}