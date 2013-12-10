using System;
using System.Linq;
using ProgramDioptase.Interfaces.ItemTypes;

namespace ProgramDioptase.ItemTypes
{
    public abstract class SaleableItem : CatalogItem, ISaleable
    {
        public decimal Price { get; protected set; }

        public bool IsInStock { get; protected set; }
    }
}