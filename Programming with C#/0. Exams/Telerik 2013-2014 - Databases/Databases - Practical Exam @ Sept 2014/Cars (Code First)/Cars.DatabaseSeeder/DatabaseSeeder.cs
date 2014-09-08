namespace Cars.DatabaseSeeder
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Cars.Data;
    using Cars.Json.JsonModels;
    using Cars.Models;

    public class DatabaseSeeder
    {
        private readonly CarsDbContext carsDbContext;

        private readonly IDictionary<string, City> cities = new Dictionary<string, City>();
        private readonly IDictionary<string, Manufacturer> manufacturers = new Dictionary<string, Manufacturer>();
        private readonly IDictionary<string, Dealer> dealers = new Dictionary<string, Dealer>();

        public DatabaseSeeder(CarsDbContext carsDbContext)
        {
            this.carsDbContext = carsDbContext;
            this.InitializeDictionaries();
        }

        public void SeedDataFromJsonObjects(IList<CarMap> jsonObjects)
        {
            Console.WriteLine("Seed JSON objects to MSSQL Database...");

            for (int i = 0; i < jsonObjects.Count; i++)
            {
                var jsonObj = jsonObjects[i];

                var car = new Car()
                {
                    Year = jsonObj.Year,
                    TransmissionType = (TransmissionType)jsonObj.TransmissionType,
                    Manufacturer = this.GetOrCreateManufacturer(jsonObj.ManufacturerName),
                    Model = jsonObj.Model,
                    Price = (decimal)jsonObj.Price,
                    Dealer = this.GetDealer(jsonObj.Dealer)
                };

                this.carsDbContext.Cars.Add(car);

                if (i % 100 == 0)
                {
                    Console.Write(".");
                    this.carsDbContext.SaveChanges();
                }
            }

            this.carsDbContext.SaveChanges();

            Console.WriteLine("\nJSON Objects were deserialized and seeded to database sucessfully!\n");
        }

        private Manufacturer GetOrCreateManufacturer(string name)
        {
            Manufacturer manufacturer;
            this.manufacturers.TryGetValue(name, out manufacturer);

            if (manufacturer == null)
            {
                manufacturer = new Manufacturer()
                {
                    Name = name
                };

                this.manufacturers[name] = manufacturer;
            }

            return manufacturer;
        }

        private Dealer GetDealer(DealerMap dealerMap)
        {
            var city = this.GetOrCreateCity(dealerMap.City);
            var dealer = this.GetOrCreateDealer(dealerMap);

            if (!dealer.Cities.Any(c => c.Name == city.Name))
            {
                dealer.Cities.Add(city);
            }

            return dealer;
        }
 
        private Dealer GetOrCreateDealer(DealerMap dealerMap)
        {
            Dealer dealer;
            this.dealers.TryGetValue(dealerMap.Name, out dealer);

            if (dealer == null)
            {
                dealer = new Dealer()
                {
                    Name = dealerMap.Name
                };

                this.dealers[dealerMap.Name] = dealer;
            }

            return dealer;
        }

        private City GetOrCreateCity(string name)
        {
            City city;
            this.cities.TryGetValue(name, out city);

            if (city == null)
            {
                city = new City()
                {
                    Name = name
                };

                this.cities[name] = city;
            }

            return city;
        }

        private void InitializeDictionaries()
        {
            var citiesFromDb = this.carsDbContext.Cities.ToList();
            foreach (var city in citiesFromDb)
            {
                this.cities.Add(city.Name, city);
            }

            var manufacturersFromDb = this.carsDbContext.Manufacturer.ToList();
            foreach (var manufacturer in manufacturersFromDb)
            {
                this.manufacturers.Add(manufacturer.Name, manufacturer);
            }

            var dealersFromDb = this.carsDbContext.Dealers.ToList();
            foreach (var dealer in dealersFromDb)
            {
                this.dealers.Add(dealer.Name, dealer);
            }
        }
    }
}