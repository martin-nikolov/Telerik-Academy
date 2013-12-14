using System;
using System.Linq;
using TradeAndTravel.Items;

namespace TradeAndTravel.Interfaces
{
    public interface IShopkeeper
    {
        int CalculateSellingPrice(Item item);

        int CalculateBuyingPrice(Item item);
    }
}