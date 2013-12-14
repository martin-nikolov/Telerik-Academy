using System;
using System.Linq;
using TradeAndTravel.Locations;

namespace TradeAndTravel.Interfaces
{
    public interface ITraveller
    {
        Location Location { get; }

        void TravelTo(Location location);
    }
}