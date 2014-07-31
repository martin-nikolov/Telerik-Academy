using System;

namespace FacadePattern
{
    public class InteriorController
    {
        public void DimLights(int amount)
        {
            int desiredAmmount = amount;
            if (desiredAmmount < 0)
            {
                desiredAmmount = 0;
            }

            if (desiredAmmount > 100)
            {
                desiredAmmount = 100;
            }

            Console.WriteLine("Dimming lights to {0}...", desiredAmmount);
        }

        public void MoveCurtains(int amount)
        {
            int desiredAmmount = amount;
            if (desiredAmmount < 0)
            {
                desiredAmmount = 0;
            }

            if (desiredAmmount > 100)
            {
                desiredAmmount = 100;
            }

            Console.WriteLine("Moving curtains to {0} percent...", desiredAmmount);
        }

        public void HideTable()
        {
            Console.WriteLine("Hiding the table...");
        }
    }
}