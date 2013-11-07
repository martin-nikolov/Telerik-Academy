namespace AbstractFactory.PizzaPlaces
{
    public abstract class PizzaFactory
    {
        public abstract CheesePizza MakeCheesePizza();

        public abstract Calzone MakeCalzone();

        public abstract PepperoniPizza MakePepperoniPizza();
    }
}
