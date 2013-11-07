using System;
using System.Collections.Generic;
using System.Linq;

namespace DocumentSystem
{
    class PDFDocument : EncryptableDocument
    {
        public long? NumberOfPages { get; set; }

        public override void LoadProperty(string key, string value)
        {
            if (key.Equals("pages"))
            {
                this.NumberOfPages = long.Parse(value);
            }
            else
            {
                base.LoadProperty(key, value);
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            output.Add(new KeyValuePair<string, object>("pages", this.NumberOfPages));

            base.SaveAllProperties(output);
        }
    }
}