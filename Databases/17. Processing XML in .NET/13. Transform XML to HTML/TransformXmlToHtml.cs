/*
 * 13. Create an XSL stylesheet, which transforms the file catalog.xml
 * into HTML document, formatted for viewing in a standard Web-browser.
 */

namespace ProcessingXml
{
    using System;
    using System.Linq;
    using System.Xml.Xsl;

    public class TransformXmlToHtml
    {
        internal static void Main()
        {
            var xslt = new XslCompiledTransform();
            xslt.Load("../../catalog.xsl");
            xslt.Transform("../../catalog.xml", "../../catalog.html");
        }
    }
}