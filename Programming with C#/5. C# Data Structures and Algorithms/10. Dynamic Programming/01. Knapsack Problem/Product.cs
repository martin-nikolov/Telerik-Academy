namespace DynamicProgramming
{
    using System;
    using System.Linq;

    public struct Product
    {
        public Product(string name, int weight, int cost)
            : this()
        {
            this.Name = name;
            this.Weight = weight;
            this.Cost = cost;
        }

        public string Name { get; set; }

        public int Weight { get; set; }

        public int Cost { get; set; }

        public override string ToString()
        {
            return string.Format("{0} - weight={1}, cost={2}", this.Name, this.Weight, this.Cost);
        }
    }
}