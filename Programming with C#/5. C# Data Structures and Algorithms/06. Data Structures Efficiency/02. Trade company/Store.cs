namespace DataStructuresEfficiency
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class Store
    {
        private OrderedMultiDictionary<decimal, Product> products =
            new OrderedMultiDictionary<decimal, Product>(true);

        public OrderedMultiDictionary<decimal, Product> Products
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
            this.products[product.Price].Add(product);
        }

        public ICollection<Product> SearchInPriceRange(decimal from, decimal to)
        {
            return this.products.Range(from, true, to, true).Values;
        }
    }
}