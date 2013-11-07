namespace FactoryMethod.GsmConglomerate
{
    public class PearComputers : Manufacturer
    {
        public override Gsm ManufactureGsm()
        {
            var phone = new EyePhone
                                    {
                                        BatteryLife = 1000,
                                        Height = 200,
                                        Weight = 100,
                                        Width = 50
                                    }; 

            return phone;
        }
    }
}
