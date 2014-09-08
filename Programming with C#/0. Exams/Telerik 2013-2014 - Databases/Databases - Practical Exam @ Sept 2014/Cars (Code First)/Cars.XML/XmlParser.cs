namespace Cars.XML
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    using Cars.XML.XmlModels;
    
    public class XmlParser
    {
        public IList<XmlQuery> ParseXml(string xmlFilePath)
        {
            var parsedQueries = new List<XmlQuery>();
            var queryElementsXml = this.GetQueryXmlElement(xmlFilePath);

            foreach (var queryXml in queryElementsXml)
            {
                var parsedQuery = this.CreateXmlQuery(queryXml);
                this.GetWhereClauses(queryXml, parsedQuery);
                parsedQueries.Add(parsedQuery);
            }

            return parsedQueries;
        }
 
        private IEnumerable<XElement> GetQueryXmlElement(string xmlFilePath)
        {
            var queriesXml = XElement.Load(xmlFilePath);
            var queryElementsXml = queriesXml.Elements("Query");
            return queryElementsXml;
        }
 
        private XmlQuery CreateXmlQuery(XElement queryXml)
        {
            var outputFileName = queryXml.Attribute("OutputFileName").Value;
            var orderByParam = queryXml.Element("OrderBy").Value;
            var parsedQuery = new XmlQuery(outputFileName, orderByParam);
            return parsedQuery;
        }
 
        private void GetWhereClauses(XElement queryXml, XmlQuery parsedQuery)
        {
            var whereClausesXml = queryXml.Element("WhereClauses").Elements("WhereClause");
            foreach (var whereClauseXml in whereClausesXml)
            {
                var propertyName = whereClauseXml.Attribute("PropertyName").Value;
                var type = whereClauseXml.Attribute("Type").Value;
                var value = whereClauseXml.Value;

                parsedQuery.WhereClauses.Add(new WhereClause(propertyName, type, value));
            }
        }
    }
}