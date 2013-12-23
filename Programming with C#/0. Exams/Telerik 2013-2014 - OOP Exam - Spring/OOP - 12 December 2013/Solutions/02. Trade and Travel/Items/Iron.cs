namespace TradeAndTravel.Items
{
    using System;
    using System.Linq;
    using TradeAndTravel.Enumerations;
    using TradeAndTravel.Locations;

    class Iron : Item
    {
        const int MoneyValue = 3;

        public Iron(string name, Location location = null)
            : base(name, Iron.MoneyValue, ItemType.Iron, location)
        {
        }
    }
}