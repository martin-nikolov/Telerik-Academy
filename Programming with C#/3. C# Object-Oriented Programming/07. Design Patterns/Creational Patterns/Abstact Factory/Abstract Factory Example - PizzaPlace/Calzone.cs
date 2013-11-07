namespace AbstractFactory.PizzaPlaces
{
    using System.Collections.Generic;

    public class Calzone : Pizza
    {
        private string madeBy;

        public Calzone(IEnumerable<string> ingridients, string madeBy)
            : base(ingridients)
        {
            this.madeBy = madeBy;
        }

        public override string Name
        {
            get
            {
                return string.Format("Calzone made by {0}", madeBy);
            }
        }
    }
}
