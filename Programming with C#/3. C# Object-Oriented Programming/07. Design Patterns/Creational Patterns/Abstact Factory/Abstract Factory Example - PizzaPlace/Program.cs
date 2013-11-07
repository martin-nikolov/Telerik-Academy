namespace AbstractFactory.PizzaPlaces
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var pizzaPlace = new PizzaExtraordinaire();
            var yamYam = new OnlineDeliveryCompany(pizzaPlace);

            var cheesePizza = yamYam.DeliverCheesePizza();

            Console.WriteLine(cheesePizza.Name);
            Console.WriteLine("Ingridients: ");
            foreach (var ingridient in cheesePizza.Ingridients)
            {
                Console.WriteLine(ingridient);
            }
        }
    }
}
