namespace DocumentSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    abstract class Document : IDocument
    {
        public string Name { get; private set; }

        public string Content { get; protected set; }

        public virtual void LoadProperty(string key, string value)
        {
            if (key.Equals("name"))
            {
                this.Name = value;
            }
            else if (key.Equals("content"))
            {
                this.Content = value;
            }
        }

        public virtual void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            output.Add(new KeyValuePair<string, object>("name", this.Name));
            output.Add(new KeyValuePair<string, object>("content", this.Content));
        }

        public override string ToString()
        {
            var output = new StringBuilder();
            output.Append(this.GetType().Name + "[");

            var docInfo = new List<KeyValuePair<string, object>>();
            this.SaveAllProperties(docInfo);

            var sortedAttributes = docInfo.OrderBy(attrib => attrib.Key);

            foreach (var item in sortedAttributes)
            {
                if (item.Value != null)
                {
                    output.AppendFormat("{0}={1};", item.Key, item.Value);
                }
            }

            output.Length--;

            output.Append("]");

            return output.ToString();
        }
    }
}