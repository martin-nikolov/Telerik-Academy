namespace Cars.XML
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    using Cars.Common;
    using Cars.Models;

    public class XmlQueryWriter
    {
        public void Save(IList<Car> cars, string outputFileName)
        {
            XNamespace carsXmlNamespaceInstance = "http://www.w3.org/2001/XMLSchema-instance";
            XNamespace carsXmlNamespaceSchema = "http://www.w3.org/2001/XMLSchema";

            var carsXml = new XElement("Cars",
                new XAttribute(XNamespace.Xmlns + "xsi", carsXmlNamespaceInstance),
                new XAttribute(XNamespace.Xmlns + "xsd", carsXmlNamespaceSchema));

            foreach (var car in cars)
            {
                var carXml = this.GenerateCarXElement(car);
                var carDealerCitiesXml = this.GenerateCityXElement(car);
                var dealerXml = this.GenerateDealerXElement(car, carDealerCitiesXml);
                carXml.Add(dealerXml);
                carsXml.Add(carXml);
            }

            Console.WriteLine("- XML file: '{0}' saved.", outputFileName);
            carsXml.Save(Constants.XmlReportsOutputDirectoryPath + "/" + outputFileName);
        }
 
        private XElement GenerateCarXElement(Car car)
        {
            var carXml = new XElement("Car",
                new XAttribute("Manufacturer", car.Manufacturer.Name),
                new XAttribute("Model", car.Model),
                new XAttribute("Year", car.Year),
                new XAttribute("Price", Math.Round(car.Price, 2)),
                new XElement("TransmissionType", car.TransmissionType.ToString().ToLower()));

            return carXml;
        }
 
        private XElement GenerateDealerXElement(Car car, XElement carDealerCitiesXml)
        {
            var dealerXml = new XElement("Dealer",
                new XAttribute("Name", car.Dealer.Name),
                carDealerCitiesXml);

            return dealerXml;
        }
 
        private XElement GenerateCityXElement(Car car)
        {
            var carDealerCitiesXml = new XElement("Cities");

            foreach (var carDealerCity in car.Dealer.Cities)
            {
                var cityXml = new XElement("City", carDealerCity.Name);
                carDealerCitiesXml.Add(cityXml);
            }

            return carDealerCitiesXml;
        }
    }
}