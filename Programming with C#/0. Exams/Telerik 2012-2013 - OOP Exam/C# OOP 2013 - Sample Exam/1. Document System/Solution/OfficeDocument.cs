using System;
using System.Collections.Generic;
using System.Linq;

namespace DocumentSystem
{
    abstract class OfficeDocument : EncryptableDocument
    {
        public string Version { get; set; }

        public override void LoadProperty(string key, string value)
        {
            if (key.Equals("version"))
            {
                this.Version = value;
            }
            else
            {
                base.LoadProperty(key, value);
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            output.Add(new KeyValuePair<string, object>("version", this.Version));

            base.SaveAllProperties(output);
        }
    }
}