namespace ProgramDioptase
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ProgramDioptase.CatalogItems;
    using ProgramDioptase.Interfaces.ItemDescription;
    using ProgramDioptase.Interfaces.ItemTypes;

    public static class Basket
    {
        static Basket()
        {
            RentedItems = new List<IRentable>();
            PurchasedItems = new List<ISaleable>();
        }

        public static IList<IRentable> RentedItems { get; private set; }

        public static IList<ISaleable> PurchasedItems { get; private set; }

        public static IList<IDescription> GetAllOrders()
        {
            var orders = new List<IDescription>();

            foreach (var item in RentedItems)
            {
                orders.Add(item as IDescription);
            }

            foreach (var item in PurchasedItems)
            {
                orders.Add(item as IDescription);
            }

            return orders;
        }

        public static void AddRentableItem(Movie item)
        {
            RentedItems.Add(item);
        }

        public static void AddSaleableItem(ISaleable item)
        {
            PurchasedItems.Add(item);
        }

        public static void EmptyBasket()
        {
            RentedItems.Clear();
            PurchasedItems.Clear();
        }
    }
}