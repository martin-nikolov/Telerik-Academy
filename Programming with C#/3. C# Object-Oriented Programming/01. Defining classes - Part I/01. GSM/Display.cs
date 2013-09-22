using System;
using System.Text;

namespace MobilePhone
{
    public class Display
    {
        // Private Constans
        private const decimal MinSizeInches = 0.5m;
        private const decimal MaxSizeInches = 100;
        private const decimal MaxNumberOfColors = 1E10M;

        // Private Fields
        private decimal? sizeInches = null;
        private ulong? numberOfColors = null;

        // Constructors
        public Display(decimal? sizeInches = null, ulong? numberOfColors = null)
        {
            this.SizeInches = sizeInches;
            this.NumberOfColors = numberOfColors;
        }

        // Properties
        public decimal? SizeInches
        {
            get { return this.sizeInches; }
            set
            {
                if (value.HasValue && (value < MinSizeInches || value > MaxSizeInches))
                    throw new ArgumentOutOfRangeException("Display size's value is not in range!");

                this.sizeInches = value;
            }
        }

        public ulong? NumberOfColors
        {
            get { return this.numberOfColors; }
            set
            {
                if (value.HasValue && value > MaxNumberOfColors)
                    throw new ArgumentOutOfRangeException("Number of colors has too big value!");
                
                this.numberOfColors = value;
            }
        }

        // Override method
        public override string ToString()
        {
            StringBuilder displayInfo = new StringBuilder();

            displayInfo.AppendLine("--> DISPLAY <--");

            if (this.sizeInches.HasValue)
                displayInfo.AppendLine(string.Format("Size: {0}-inch", sizeInches));

            if (this.numberOfColors.HasValue)
                displayInfo.AppendLine("Number of colors: " + numberOfColors);

            return displayInfo.ToString();
        }
    }
}