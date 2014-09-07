namespace XmlBasics
{
    using System;
    using System.Linq;
    using System.Xml.Linq;

    public class StudentsXmlWithNamespace
    {
        internal static void Main()
        {
            var studentsXml = XElement.Load("../../students.xml");
            Console.WriteLine(studentsXml);
        }
    }
}