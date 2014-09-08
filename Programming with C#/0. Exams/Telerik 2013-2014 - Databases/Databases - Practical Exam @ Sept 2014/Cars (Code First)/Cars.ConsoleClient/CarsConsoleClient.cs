namespace Cars.ConsoleClient
{
    using System;
    using System.Linq;
    using Cars.Common;
    using Cars.Data;
    using Cars.DatabaseSeeder;
    using Cars.Json;
    using Cars.XML;

    public class CarsConsoleClient
    {
        private static readonly CarsDbContext carsDbContext = new CarsDbContext();
        private static readonly JsonParser jsonParser = new JsonParser();
        private static readonly XmlParser xmlParser = new XmlParser();
        private static readonly XmlQueryWriter xmlQueryWriter = new XmlQueryWriter();
        private static readonly XmlQueryBuilder xmlQueryExecutor = new XmlQueryBuilder(carsDbContext, xmlQueryWriter);
        private static readonly DatabaseSeeder databaseSeeder = new DatabaseSeeder(carsDbContext);

        internal static void Main()
        {
            using (carsDbContext)
            {
                if (!carsDbContext.Cars.Any())
                {
                    var jsonObjects = jsonParser.DeserializeJsonObjects(Constants.JsonReportsDirectoryPath);
                    databaseSeeder.SeedDataFromJsonObjects(jsonObjects);

                    var xmlQueries = xmlParser.ParseXml(Constants.XmlSampleQueryFullPath);
                    xmlQueryExecutor.Execute(xmlQueries);
                }
            }
        }
    }
}