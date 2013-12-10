using System;
using System.Collections.Generic;
using System.Linq;
using ProgramDioptase.Interfaces;
using ProgramDioptase.Interfaces.ItemTypes;

namespace ProgramDioptase.ClientDescription
{
    public class Client : Person, IRenter
    {
        public Client()
            : base()
        {
        }

        public decimal? BallanceOfAcount { get; private set; }

        public IList<IRentable> RentedItems { get; private set; }

        public IList<ISaleable> PurchasedItems { get; private set; }

        public void Rent(IRentable item)
        {
            this.RentedItems.Add(item);
        }

        public void Buy(ISaleable item)
        {
            this.PurchasedItems.Add(item);
        }
    }
}