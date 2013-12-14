using System;
using System.Linq;
using TradeAndTravel.Interfaces;
using TradeAndTravel.Locations;

namespace TradeAndTravel
{
    public class Traveller : Person, ITraveller
    {
        public Traveller(string name, Location location)
            : base(name, location)
        {
        }

        public virtual void TravelTo(Location location)
        {
            this.Location = location;
        }
    }
}