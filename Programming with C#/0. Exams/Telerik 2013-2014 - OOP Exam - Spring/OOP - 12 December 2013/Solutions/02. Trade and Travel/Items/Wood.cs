namespace TradeAndTravel.Items
{
    using System;
    using System.Linq;
    using TradeAndTravel.Enumerations;
    using TradeAndTravel.Locations;

    class Wood : Item
    {
        const int MoneyValue = 2;

        public Wood(string name, Location location = null)
            : base(name, Wood.MoneyValue, ItemType.Wood, location)
        {
        }

        public override void UpdateWithInteraction(string interaction)
        {
            if (interaction == "drop" && this.Value > 0)
            {
                this.Value--; 
            }
        }
    }
}