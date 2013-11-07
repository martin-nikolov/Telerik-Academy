namespace FactoryMethod.GsmConglomerate
{
    public class SamunComputers : Manufacturer
    {
        public override Gsm ManufactureGsm()
        {
            var phone = new SamunGalaxy
                                    {
                                        BatteryLife = 999,
                                        Height = 199,
                                        Weight = 99,
                                        Width = 49
                                    };

            return phone;
        }
    }
}
