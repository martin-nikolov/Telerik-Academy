using System;
using System.Linq;
using TradeAndTravel.Enumerations;
using TradeAndTravel.Items;

namespace TradeAndTravel.Interfaces
{
    public interface IGatheringLocation
    {
        ItemType GatheredType { get; }

        ItemType RequiredItem { get; }

        Item ProduceItem(string name);
    }
}