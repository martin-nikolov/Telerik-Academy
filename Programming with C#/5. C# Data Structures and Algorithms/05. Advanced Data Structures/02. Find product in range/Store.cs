namespace AdvancedDataStructures
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class Store
    {
        private OrderedBag<Product> products = new OrderedBag<Product>();

        public OrderedBag<Product> Products
        {
            get
            {
                return this.products;
            }
            set
            {
                this.products = value;
            }
        }

        public void AddProduct(Product product)
        {
            this.products.Add(product);
        }

        public void AddProducts(params Product[] products)
        {
            this.products.AddMany(products);
        }
    
        public ICollection<Product> SearchInPriceRange(decimal min, decimal max)
        {
            return this.products
                       .Range(new Product(string.Empty, min), true, new Product(string.Empty, max), true)
                       .Take(20)
                       .ToList();
        }
    }
}