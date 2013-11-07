using System;
using System.Collections.Generic;
using System.Linq;

namespace DocumentSystem
{
    class ExcelDocument : OfficeDocument
    {
        public int? NumberOfRows { get; set; }

        public int? NumberOfCols { get; set; }

        public override void LoadProperty(string key, string value)
        {
            if (key.Equals("rows"))
            {
                this.NumberOfRows = int.Parse(value);
            }
            else if (key.Equals("cols"))
            {
                this.NumberOfCols = int.Parse(value);
            }
            else
            {
                base.LoadProperty(key, value);
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            output.Add(new KeyValuePair<string, object>("rows", this.NumberOfRows));
            output.Add(new KeyValuePair<string, object>("cols", this.NumberOfCols));

            base.SaveAllProperties(output);
        }
    }
}