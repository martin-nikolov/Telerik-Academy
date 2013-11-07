using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentSystem
{
    public abstract class OfficeDocument : EncryptableDocument
    {
        public string Version
        {
            get
            {
                return this.GetProperty("Version").ToString();
            }
            set
            {
                this.LoadProperty("Version", value.ToString());
            }
        }
    }
}
