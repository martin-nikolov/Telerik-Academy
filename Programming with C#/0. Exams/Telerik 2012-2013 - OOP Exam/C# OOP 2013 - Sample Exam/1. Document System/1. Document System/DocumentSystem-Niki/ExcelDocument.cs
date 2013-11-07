using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentSystem
{
    public class ExcelDocument : OfficeDocument
    {
        public int NumberOfRows
        {
            get
            {
                return this.GetProperty("rows").ToInteger();
            }
            set
            {
                this.LoadProperty("rows", value.ToString());
            }
        }

        public int NumberOfColumns
        {
            get
            {
                return this.GetProperty("cols").ToInteger();
            }
            set
            {
                this.LoadProperty("cols", value.ToString());
            }
        }
    }
}
