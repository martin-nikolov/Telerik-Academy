using System;
using System.Linq;

class CoffeeMachine
{
    static void Main()
    {
        decimal[] coins = new decimal[5];
        for (int i = 0; i < coins.Length; i++)
            coins[i] = decimal.Parse(Console.ReadLine());

        decimal moneyInMachine = coins[0] * 0.05m + coins[1] * 0.10m +
                                 coins[2] * 0.20m + coins[3] * 0.50m + coins[4];

        decimal givenMoney = decimal.Parse(Console.ReadLine());
        decimal drinkMoney = decimal.Parse(Console.ReadLine());

        if (moneyInMachine >= givenMoney - drinkMoney && givenMoney >= drinkMoney)
        {
            Console.WriteLine("Yes {0}", moneyInMachine - givenMoney + drinkMoney);
        }
        else if (givenMoney < drinkMoney)
        {
            Console.WriteLine("More {0}", drinkMoney - givenMoney);
        }
        else if (moneyInMachine < givenMoney - drinkMoney)
        {
            Console.WriteLine("No {0}", givenMoney - moneyInMachine - drinkMoney);
        }
    }
}