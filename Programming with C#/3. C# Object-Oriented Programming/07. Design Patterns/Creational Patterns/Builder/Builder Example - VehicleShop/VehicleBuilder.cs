namespace Builder
{
    /// <summary>
    /// The 'Builder' abstract class
    /// </summary>
    internal abstract class VehicleBuilder
    {
        public Vehicle Vehicle { get; set; }

        public abstract void BuildFrame();

        public abstract void BuildEngine();

        public abstract void BuildWheels();

        public abstract void BuildDoors();
    }
}
