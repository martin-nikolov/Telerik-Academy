namespace Cars.XML.XmlModels
{
    using System;
    using System.Linq;

    public class WhereClause
    {
        public WhereClause(string propertyName, string type, string value)
        {
            this.PropertyName = propertyName;
            this.Type = type;
            this.Value = value;
        }

        public string PropertyName { get; set; }

        public string Type { get; set; }

        public string Value { get; set; }
    }
}