namespace FactoryMethod.GsmConglomerate
{
    using System;

    public class SamunGalaxy : Gsm
    {
        public SamunGalaxy()
        {
            this.Name = "Samun Galaxy";
        }

        public override void Start()
        {
            Console.WriteLine("Starting up the Galaxy...");
            Console.WriteLine("Thrusters on full!");
        }
    }
}
