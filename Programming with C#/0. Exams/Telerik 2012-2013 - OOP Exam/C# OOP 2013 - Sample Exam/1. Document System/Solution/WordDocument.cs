using System;
using System.Collections.Generic;
using System.Linq;

namespace DocumentSystem
{
    class WordDocument : OfficeDocument, IEditable
    {
        public long? NumberOfCharacters { get; set; }

        public override void LoadProperty(string key, string value)
        {
            if (key.Equals("chars"))
            {
                this.NumberOfCharacters = long.Parse(value);
            }
            else
            {
                base.LoadProperty(key, value);
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            output.Add(new KeyValuePair<string, object>("chars", this.NumberOfCharacters));

            base.SaveAllProperties(output);
        }

        public void ChangeContent(string newContent)
        {
            this.Content = newContent;
        }
    }
}