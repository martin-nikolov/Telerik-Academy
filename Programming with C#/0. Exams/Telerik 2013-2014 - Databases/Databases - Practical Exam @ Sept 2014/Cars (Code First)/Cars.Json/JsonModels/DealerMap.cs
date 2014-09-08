namespace Cars.Json.JsonModels
{
    using System;
    using System.Linq;
    using Newtonsoft.Json;

    [JsonObject(Title = "Dealer")]
    public class DealerMap
    {
        public string Name { get; set; }

        public string City { get; set; }
    }
}