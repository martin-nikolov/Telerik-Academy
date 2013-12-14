using System;
using System.Linq;
using TradeAndTravel.Enumerations;
using TradeAndTravel.Locations;

namespace TradeAndTravel.Items
{
    public class Weapon : Item
    {
        const int MoneyValue = 10;

        public Weapon(string name, Location location = null)
            : base(name, Weapon.MoneyValue, ItemType.Weapon, location)
        {
        }
    }
}