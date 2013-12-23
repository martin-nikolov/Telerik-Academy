using System;
using System.Linq;
using TradeAndTravel.Enumerations;

namespace TradeAndTravel.Locations
{
    public class Mine : Location
    {
        public Mine(string name)
            : base(name, LocationType.Mine)
        {
        }
    }
}