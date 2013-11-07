using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentSystem
{
    public class Document : IDocument
    {
        public string Name { get; protected set; }

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
            StringBuilder result = new StringBuilder();
            result.Append(this.GetType().Name);
            result.Append("[");

            var attributes = new List<KeyValuePair<string, object>>();
            this.SaveAllProperties(attributes);
            var sortedAttributes = attributes.OrderBy(attrib => attrib.Key);

            foreach (var attrib in sortedAttributes)
            { 
                if (attrib.Value != null)
                {
                    result.Append(attrib.Key + "=" + attrib.Value + ";");
                }
            }

            result.Length--;
            result.Append("]");

            return result.ToString();
        }
    }
}