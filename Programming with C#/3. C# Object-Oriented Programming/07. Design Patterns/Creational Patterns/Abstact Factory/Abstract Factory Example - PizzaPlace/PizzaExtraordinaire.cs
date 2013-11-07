namespace AbstractFactory.PizzaPlaces
{
    using System.Collections.Generic;

    public class PizzaExtraordinaire : PizzaFactory
    {
        private const string name = "Pizza Extraordinaire";

        public string Name
        {
            get
            {
                return name;
            }
        }

        public override CheesePizza MakeCheesePizza()
        {
            var ingridients = new List<string>();
            ingridients.Add("rotten tomatoes");
            ingridients.Add("grey cheese");
            ingridients.Add("green cheese");

            var pizza = new CheesePizza(ingridients, this.Name);
            return pizza;
        }

        public override Calzone MakeCalzone()
        {
            var ingridients = new List<string>();
            ingridients.Add("rotten tomatoes");
            ingridients.Add("greasy ham");

            var pizza = new Calzone(ingridients, this.Name);
            return pizza;
        }

        public override PepperoniPizza MakePepperoniPizza()
        {
            var ingridients = new List<string>();
            ingridients.Add("old salami");
            ingridients.Add("green tomatoes");

            var pizza = new PepperoniPizza(ingridients, this.Name);
            return pizza;
        }
    }
}
