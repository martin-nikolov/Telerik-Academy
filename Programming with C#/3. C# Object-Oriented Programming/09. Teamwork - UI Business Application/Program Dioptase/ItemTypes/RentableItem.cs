using System;
using System.Linq;
using ProgramDioptase.Interfaces.ItemTypes;

namespace ProgramDioptase.ItemTypes
{
    public abstract class RentableItem : CatalogItem, IRentable
    {
        public decimal PricePerDay { get; protected set; }

        public decimal TotalPrice { get; set; }

        public DateTime RentalDate { get; set; }

        public DateTime ReturnDate { get; set; }

        public bool IsInStock { get; protected set; }
    }
}