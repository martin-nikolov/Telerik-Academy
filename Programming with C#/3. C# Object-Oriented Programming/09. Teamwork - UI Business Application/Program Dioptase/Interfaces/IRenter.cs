using System;
using System.Collections.Generic;
using System.Linq;
using ProgramDioptase.Interfaces.ItemTypes;

namespace ProgramDioptase.Interfaces
{
    public interface IRenter
    {
        IList<IRentable> RentedItems { get; }

        IList<ISaleable> PurchasedItems { get; }

        void Rent(IRentable item);

        void Buy(ISaleable item);
    }
}