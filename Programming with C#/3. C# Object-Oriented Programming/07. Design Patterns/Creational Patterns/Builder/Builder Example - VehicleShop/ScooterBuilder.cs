namespace Builder
{
    /// <summary>
    /// The 'ConcreteBuilder' class
    /// </summary>
    internal class ScooterBuilder : VehicleBuilder
    {
        public ScooterBuilder()
        {
            this.Vehicle = new Vehicle("Scooter");
        }

        public override void BuildFrame()
        {
            this.Vehicle["frame"] = "Scooter Frame";
        }

        public override void BuildEngine()
        {
            this.Vehicle["engine"] = "50 cc";
        }

        public override void BuildWheels()
        {
            this.Vehicle["wheels"] = "2";
        }

        public override void BuildDoors()
        {
            this.Vehicle["doors"] = "0";
        }
    }
}
