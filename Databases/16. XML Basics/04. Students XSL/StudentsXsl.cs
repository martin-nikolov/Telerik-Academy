namespace _04.Students_XSL
{
    using System;
    using System.Linq;
    using System.Xml.Xsl;

    public class StudentsXsl
    {
        internal static void Main()
        {
            var xslt = new XslCompiledTransform();
            xslt.Load("../../students.xls");
            xslt.Transform("../../students.xml", "../../students.html");
        }
    }
}