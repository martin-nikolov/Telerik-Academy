namespace Builder
{
    /// <summary>
    /// The 'ConcreteBuilder' class
    /// </summary>
    internal class CarBuilder : VehicleBuilder
    {
        public CarBuilder()
        {
            this.Vehicle = new Vehicle("Car");
        }

        public override void BuildFrame()
        {
            this.Vehicle["frame"] = "Car Frame";
        }

        public override void BuildEngine()
        {
            this.Vehicle["engine"] = "2500 cc";
        }

        public override void BuildWheels()
        {
            this.Vehicle["wheels"] = "4";
        }

        public override void BuildDoors()
        {
            this.Vehicle["doors"] = "4";
        }
    }
}
