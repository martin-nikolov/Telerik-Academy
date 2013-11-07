using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentSystem
{
    // TODO: Implement ToString()
    public abstract class Document : IDocument
    {
        public string Name
        {
            get
            {
                return this.GetProperty("Name") as string;
            }
            set
            {
                this.LoadProperty("Name", value.ToString());
            }
        }

        public string Content
        {
            get
            {
                return this.GetProperty("Content").ToString();
            }
            set
            {
                this.LoadProperty("Content", value.ToString());
            }
        }

        protected readonly Dictionary<string, object> properties = new Dictionary<string, object>();

        public void LoadProperty(string key, string value)
        {
            string loweredKey = key.ToLower();
            if (this.properties.ContainsKey(loweredKey))
            {
                this.properties[loweredKey] = value;
            }
            else
            {
                this.properties.Add(loweredKey, value);
            }
        }

        public void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            output = this.properties.ToList();
            output = output.OrderBy(x => x.Key).ToList();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(this.GetType().Name);
            sb.Append('[');

            var list = this.properties.ToList();
            list = list.OrderBy(x => x.Key).ToList();

            foreach (var item in list)
            {
                if (item.Value != null)
                {
                    sb.AppendFormat("{0}={1};", item.Key.ToLower(), item.Value);
                }
            }

            string result = sb.ToString().Trim(';') + "]";
            return result;
        }

        protected object GetProperty(string key)
        {
            string loweredKey = key.ToLower();
            if (this.properties.ContainsKey(loweredKey))
            {
                return properties[loweredKey];
            }
            else
            {
                return null;
            }
        }
    }
}
