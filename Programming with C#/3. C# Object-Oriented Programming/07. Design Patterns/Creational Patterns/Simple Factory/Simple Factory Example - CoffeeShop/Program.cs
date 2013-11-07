namespace SimpleFactory.CoffeeShop
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Program
    {
        public static void Main()
        {
            var macchiato = CoffeeFactory.GetCoffee(CoffeeType.Macchiato);
            var regularCoffee = CoffeeFactory.GetCoffee(CoffeeType.Regular);
            Console.WriteLine("Macchiato - Milk content: {0} ml, Coffee content: {1} ml", macchiato.MilkContent, macchiato.CoffeeContent);
            Console.WriteLine("Regular coffee - Milk content: {0} ml, Coffee content: {1} ml", regularCoffee.MilkContent, regularCoffee.CoffeeContent);
        }
    }
}
