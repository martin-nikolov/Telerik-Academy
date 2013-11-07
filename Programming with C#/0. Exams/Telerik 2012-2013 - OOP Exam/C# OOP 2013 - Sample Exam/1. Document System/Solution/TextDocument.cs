using System;
using System.Collections.Generic;
using System.Linq;

namespace DocumentSystem
{
    class TextDocument : Document, IEditable
    {
        public string Charset { get; set; }

        public override void LoadProperty(string key, string value)
        {
            if (key.Equals("charset"))
            {
                this.Charset = value;
            }
            else
            {
                base.LoadProperty(key, value);
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            output.Add(new KeyValuePair<string, object>("charset", this.Charset));

            base.SaveAllProperties(output);
        }

        public void ChangeContent(string newContent)
        {
            this.Content = newContent;
        }
    }
}