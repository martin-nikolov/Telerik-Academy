namespace Cars.XML.XmlModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class XmlQuery
    {
        public XmlQuery(string outputFileName, string orderByProperty)
        {
            this.OutputFileName = outputFileName;
            this.OrderByProperty = orderByProperty;
            this.WhereClauses = new List<WhereClause>();
        }

        public string OutputFileName { get; set; }

        public string OrderByProperty { get; set; }

        public IList<WhereClause> WhereClauses { get; set; }
    }
}