namespace Builder
{
    /// <summary>
    /// The 'ConcreteBuilder' class
    /// </summary>
    internal class MotorCycleBuilder : VehicleBuilder
    {
        public MotorCycleBuilder()
        {
            this.Vehicle = new Vehicle("MotorCycle");
        }

        public override void BuildFrame()
        {
            this.Vehicle["frame"] = "MotorCycle Frame";
        }

        public override void BuildEngine()
        {
            this.Vehicle["engine"] = "500 cc";
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
