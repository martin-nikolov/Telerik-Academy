namespace Cars.Json.JsonModels
{
    public class CarMap
    {
        public int Year { get; set; }

        public int TransmissionType { get; set; }

        public string ManufacturerName { get; set; }

        public string Model { get; set; }

        public double Price { get; set; }

        public DealerMap Dealer { get; set; }
    }
}