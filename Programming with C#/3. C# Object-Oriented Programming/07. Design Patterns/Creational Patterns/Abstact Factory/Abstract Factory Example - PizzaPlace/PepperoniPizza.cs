namespace AbstractFactory.PizzaPlaces
{
    using System.Collections.Generic;

    public class PepperoniPizza : Pizza
    {
        private string madeBy;

        public PepperoniPizza(IEnumerable<string> ingridients, string madeBy)
            : base(ingridients)
        {
            this.madeBy = madeBy;
        }

        public override string Name
        {
            get
            {
                return string.Format("Pepporni Pizza made by {0}", this.madeBy);
            }
        }
    }
}
