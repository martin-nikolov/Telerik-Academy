using System;
using System.Linq;
using ProgramDioptase.ItemTypes;

namespace ProgramDioptase.CatalogItems
{
    public class Movie : RentableItem
    {
        public Movie()
        {
        }

        public override void InitializeData(string[] components)
        {
            base.InitializeData(components);
            this.IsInStock = components[3].ToLower().Equals("yes") ? true : false;
            this.PricePerDay = decimal.Parse(components[4]);
        }
    }
}