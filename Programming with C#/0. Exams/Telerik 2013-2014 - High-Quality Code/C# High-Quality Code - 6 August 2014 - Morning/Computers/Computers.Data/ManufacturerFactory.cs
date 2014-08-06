namespace Computers.Data
{
    using System;
    using Computers.Models.Abstracts;
    using Computers.Models.DellComputers;
    using Computers.Models.HpComputers;
    using Computers.Models.LenovoComputers;

    public class ManufacturerFactory
    {
        private const string HP = "HP";
        private const string Dell = "Dell";
        private const string Lenovo = "Lenovo";
        private const string InvalidManufacturerMessage = "Invalid manufacturer!";

        public Manufacturer Create(string manufacturer)
        {
            Manufacturer computerFactory;

            if (manufacturer == HP)
            {
                computerFactory = new HpManufacturer();
            }
            else if (manufacturer == Dell)
            {
                computerFactory = new DellManufacturer();
            }
            else if (manufacturer == Lenovo)
            {
                computerFactory = new LenovoManufacturer();
            }
            else
            {
                throw new ArgumentException(InvalidManufacturerMessage);
            }

            return computerFactory;
        }
    }
}