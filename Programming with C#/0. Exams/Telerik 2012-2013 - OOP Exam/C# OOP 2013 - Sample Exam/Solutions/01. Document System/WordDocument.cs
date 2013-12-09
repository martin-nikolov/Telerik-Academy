namespace DocumentSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class WordDocument : OfficeDocument, IEditable
    {
        public long? NumberOfCharacters { get; private set; }

        public void ChangeContent(string newContent)
        {
            this.Content = newContent;
        }

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
    }
}