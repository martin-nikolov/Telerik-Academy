namespace TradeAndTravel
{
    using System;
    using System.Linq;
    using TradeAndTravel.Interfaces;
    using TradeAndTravel.Locations;

    class Merchant : Shopkeeper, ITraveller
    {
        public Merchant(string name, Location location)
            : base(name, location)
        {
        }

        public void TravelTo(Location location)
        {
            if (location != null)
            {
                this.Location = location;
            }
        }
    }
}