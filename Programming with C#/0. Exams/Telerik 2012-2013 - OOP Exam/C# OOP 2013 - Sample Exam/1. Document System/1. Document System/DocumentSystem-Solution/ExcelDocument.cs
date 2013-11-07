using System;
using System.Collections.Generic;

public class ExcelDocument : OfficeDocument
{
    public int? Rows { get; set; }
    public int? Columns { get; set; }

    public override void LoadProperty(string key, string value)
    {
        if (key == "rows")
        {
            this.Rows = int.Parse(value);
        }
        else if (key == "cols")
        {
            this.Columns = int.Parse(value);
        }
        else
        {
            base.LoadProperty(key, value);
        }
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        base.SaveAllProperties(output);
        output.Add(new KeyValuePair<string, object>("rows", this.Rows));
        output.Add(new KeyValuePair<string, object>("cols", this.Columns));
    }
}
