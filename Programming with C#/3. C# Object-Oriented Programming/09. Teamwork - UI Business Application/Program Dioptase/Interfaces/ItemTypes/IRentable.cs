using System;
using System.Linq;

namespace ProgramDioptase.Interfaces.ItemTypes
{
    public interface IRentable : IStockable
    {
        decimal PricePerDay { get; }

        decimal TotalPrice { get; }

        DateTime RentalDate { get; }

        DateTime ReturnDate { get; }
    }
}