using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentSystem
{
    public class PdfDocument : EncryptableDocument
    {
        public int NumberOfPages 
        {
            get
            {
                return this.GetProperty("pages").ToInteger();
            }
            set
            {
                this.LoadProperty("pages", value.ToString());
            }
        }
    }
}
