using System;
using System.Text;
using System.Collections.Generic;

public abstract class Document : IDocument
{
    public string Name { get; protected set; }
    public string Content { get; protected set; }
    
    public virtual void LoadProperty(string key, string value)
    {
        if (key == "name")
        {
            this.Name = value;
        }
        else if (key == "content")
        {
            this.Content = value;
        }
        else
        {
            throw new ArgumentException("Key '" + key + "' not found");
        }
    }

    public virtual void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        output.Add(new KeyValuePair<string, object>("name", this.Name));
        output.Add(new KeyValuePair<string, object>("content", this.Content));
    }

    public override string ToString()
    {
        List<KeyValuePair<string, object>> properties =
            new List<KeyValuePair<string, object>>();
        this.SaveAllProperties(properties);
        properties.Sort((a, b) => a.Key.CompareTo(b.Key));
        StringBuilder result = new StringBuilder();
        result.Append(this.GetType().Name);
        result.Append("[");
        bool first = true;
        foreach (var prop in properties)
        {
            if (prop.Value != null)
            {
                if (!first)
                {
                    result.Append(";");
                }
                result.AppendFormat("{0}={1}", prop.Key, prop.Value);
                first = false;
            }
        }
        result.Append("]");
        return result.ToString();
    }
}
