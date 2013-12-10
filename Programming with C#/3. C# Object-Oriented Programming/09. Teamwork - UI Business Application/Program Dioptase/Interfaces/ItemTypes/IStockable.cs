using System;
using System.Linq;

namespace ProgramDioptase.Interfaces.ItemTypes
{
    public interface IStockable
    {
        bool IsInStock { get; }
    }
}