using System;
using System.Linq;
using TradeAndTravel.Enumerations;
using TradeAndTravel.Locations;

namespace TradeAndTravel.Items
{
    public class Armor : Item
    {
        const int GeneralArmorValue = 5;

        public Armor(string name, Location location = null)
            : base(name, Armor.GeneralArmorValue, ItemType.Armor, location)
        {
        }
    }
}