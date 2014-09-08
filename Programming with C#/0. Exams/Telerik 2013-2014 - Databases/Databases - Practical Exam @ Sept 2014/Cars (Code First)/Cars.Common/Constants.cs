namespace Cars.Common
{
    using System;
    using System.Linq;
    
    public static class Constants
    {
        public const string JsonReportsDirectoryPath = "../../../Data.Json.Files";
        public const string XmlReportsInputDirectoryPath = "../../../Data.XML.Queries/Input";
        public const string XmlReportsOutputDirectoryPath = "../../../Data.XML.Queries/Output";
        public const string XmlQueryFileName = "Queries.xml";

        public static string XmlSampleQueryFullPath
        {
            get
            {
                return XmlReportsInputDirectoryPath + "/" + XmlQueryFileName;
            }
        }
    }
}