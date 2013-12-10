using System;
using System.Linq;
using ProgramDioptase.ItemTypes;

namespace ProgramDioptase.CatalogItems
{
    public class Game : SaleableItem
    {
        public Game()
        {
        }

        public override void InitializeData(string[] components)
        {
            base.InitializeData(components);
            this.IsInStock = components[3].ToLower().Equals("yes") ? true : false;
            this.Price = decimal.Parse(components[4]);
        }
    }
}