using System;
using System.Linq;

namespace ProgramDioptase.Interfaces.ItemTypes
{
    public interface ISaleable : IStockable
    {
        decimal Price { get; }
    }
}