using System;
using System.Text;

namespace MobilePhone
{
    public class GSM
    {
        // Private Constants
        private static readonly GSM iphone4S = new GSM("IPhone 4S", "Apple", "M-tel", 999.99m,
            new Display(4, 1000000), new Battery(Battery.Type.NiCd, 250, 1000));

        private const uint MaxPriceValue = 1000000;

        // Private Fields
        private string model = null;
        private string manufacturer = null;
        private string owner = null;
        private decimal? price = 0;

        private Display display = null;
        private Battery battery = null;

        // Constructors
        public GSM(string model, string manufacturer, string owner = null,
            decimal? price = null, Display display = null, Battery battery = null)
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
            this.Owner = owner;
            this.Price = price;

            this.Display = display;
            this.Battery = battery;

            this.CallHistory = new CallHistory();
        }

        // Properties
        public static GSM Iphone4S
        {
            get { return iphone4S; }
        }

        public string Model
        {
            get { return this.model; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException("Model cannot be null!");

                this.model = value;
            }
        }

        public string Manufacturer
        {
            get { return this.manufacturer; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException("Manufacturer cannot be null!");

                this.manufacturer = value;
            }
        }

        public string Owner
        {
            get { return this.owner; }
            set { this.owner = value; }
        }

        public decimal? Price
        {
            get { return this.price; }
            set
            {
                if (value.HasValue && (value < 0 || value > MaxPriceValue))
                    throw new ArgumentOutOfRangeException("Price value is too big or less than zero!");

                this.price = value;
            }
        }

        public Display Display
        {
            get { return this.display; }
            set { this.display = value; }
        }

        public Battery Battery
        {
            get { return this.battery; }
            set { this.battery = value; }
        }

        public CallHistory CallHistory { get; set; }

        // Methods
        public void ShowInformation()
        {
            Console.Write(this.ToString());
        }

        public override string ToString()
        {
            StringBuilder mobileInfo = new StringBuilder();

            mobileInfo.AppendLine("-------- MOBILE --------");
            mobileInfo.AppendLine("Model: " + this.model);
            mobileInfo.AppendLine("Manufacturer: " + this.manufacturer);

            if (this.owner != null)
                mobileInfo.AppendLine("Owner: " + this.owner);

            if (this.price.HasValue)
                mobileInfo.AppendLine(string.Format("Price: {0}$", this.price));

            if (this.display != null)
                mobileInfo.AppendLine(Environment.NewLine + display.ToString());

            if (this.battery != null)
                mobileInfo.AppendLine((display != null ? "" : Environment.NewLine) + battery.ToString());

            return mobileInfo.ToString();
        }
    }
}