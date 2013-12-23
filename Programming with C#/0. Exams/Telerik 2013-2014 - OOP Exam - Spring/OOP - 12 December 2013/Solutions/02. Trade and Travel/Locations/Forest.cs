using System;
using System.Linq;
using TradeAndTravel.Enumerations;

namespace TradeAndTravel.Locations
{
    public class Forest : Location
    {
        public Forest(string name)
            : base(name, LocationType.Forest)
        {
        }
    }
}