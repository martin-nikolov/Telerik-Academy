namespace SimpleFactory.CoffeeShop
{
    using System;

    public static class CoffeeFactory
    {
        public static Coffee GetCoffee(CoffeeType coffeeType)
        {
            switch (coffeeType)
            {
                case CoffeeType.Regular:
                    return new Coffee(0, 150);
                case CoffeeType.Double:
                    return new Coffee(0, 200);
                case CoffeeType.Cappuccino:
                    return new Coffee(100, 100);
                case CoffeeType.Macchiato:
                    return new Coffee(200, 100);
                default:
                    throw new ArgumentException();
            }
        }
    }
}
