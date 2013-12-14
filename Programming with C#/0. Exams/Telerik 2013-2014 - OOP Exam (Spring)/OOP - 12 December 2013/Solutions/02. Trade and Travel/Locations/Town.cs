using System;
using System.Linq;
using TradeAndTravel.Enumerations;

namespace TradeAndTravel.Locations
{
    public class Town : Location
    {
        public Town(string name)
            : base(name, LocationType.Town)
        {
        }
    }
}