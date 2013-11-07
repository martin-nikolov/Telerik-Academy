using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentSystem
{
    public abstract class BinaryDocument : Document
    {
        public ulong Size
        {
            get
            {
                return this.GetProperty("Size").ToUnsignedLong();
            }
            set
            {
                this.LoadProperty("Size", value.ToString());
            }
        }
    }
}
