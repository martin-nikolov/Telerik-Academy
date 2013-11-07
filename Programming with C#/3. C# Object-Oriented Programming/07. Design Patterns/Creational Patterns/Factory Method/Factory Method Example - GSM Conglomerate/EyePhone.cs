namespace FactoryMethod.GsmConglomerate
{
    using System;

    public class EyePhone : Gsm
    {
        public EyePhone()
        {
            this.Name = "EyePhone";
        }

        public override void Start()
        {
            Console.WriteLine("Booting up...eyePhone");
            Console.WriteLine("Welcome to your eyePhone");
        }
    }
}
