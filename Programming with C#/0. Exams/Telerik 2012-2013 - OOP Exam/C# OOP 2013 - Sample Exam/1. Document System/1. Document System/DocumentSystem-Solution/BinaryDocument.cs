using System;
using System.Collections.Generic;

public abstract class BinaryDocument : Document
{
    public long? Size { get; set; }

    public override void LoadProperty(string key, string value)
    {
        if (key == "size")
        {
            this.Size = long.Parse(value);
        }
        else
        {
            base.LoadProperty(key, value);
        }
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        base.SaveAllProperties(output);
        output.Add(new KeyValuePair<string, object>("size", this.Size));
    }
}
