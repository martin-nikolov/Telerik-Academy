namespace DocumentSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class ExcelDocument : OfficeDocument
    {
        public long? NumberOfRows { get; set; }

        public long? NumberOfColumns { get; set; }

        public override void LoadProperty(string key, string value)
        {
            if (key.Equals("rows"))
            {
                this.NumberOfRows = long.Parse(value);
            }
            else if (key.Equals("cols"))
            {
                this.NumberOfColumns = long.Parse(value);
            }
            else
            {
                base.LoadProperty(key, value);
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            output.Add(new KeyValuePair<string, object>("rows", this.NumberOfRows));
            output.Add(new KeyValuePair<string, object>("cols", this.NumberOfColumns));

            base.SaveAllProperties(output);
        }
    }
}