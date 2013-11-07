namespace AbstractFactory.PizzaPlaces
{
    using System.Collections.Generic;

    public abstract class Pizza
    {
        private IReadOnlyCollection<string> ingridients;

        public Pizza(IEnumerable<string> ingridients)
        {
            this.ingridients = new List<string>(ingridients);
        }

        public IEnumerable<string> Ingridients
        {
            get
            {
                return this.ingridients;
            }
        }

        public abstract string Name { get; }
    }
}
