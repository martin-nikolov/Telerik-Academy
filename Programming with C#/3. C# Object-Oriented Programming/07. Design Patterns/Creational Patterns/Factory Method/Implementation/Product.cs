namespace FactoryMethod
{
    public abstract class Product
    {
        public Product(string description)
        {
            this.Description = description;
        }

        public string Description { get; set; }
    }
}
