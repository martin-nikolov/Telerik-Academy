using System;
using System.Text;

namespace MobilePhone
{
    public class Battery
    {
        // Private Constants
        private const uint MaxIdleHours = 500;
        private const uint MaxTalkHours = 3000;

        // Private Fields
        private uint? hoursIdle = null;
        private uint? hoursTalk = null;

        // Constructors
        public Battery(Type model, uint? hoursIdle = null, uint? hoursTalk = null)
        {
            this.Model = model;
            this.HoursIdle = hoursIdle;
            this.HoursTalk = hoursTalk;
        }

        // Enumeration
        public enum Type
        {
            LiIon,
            NiMH,
            NiCd
        }

        // Properties
        public Type Model { get; set; }

        public uint? HoursIdle
        {
            get { return this.hoursIdle; }
            set
            {
                if (value.GetValueOrDefault() > MaxIdleHours)
                    throw new ArgumentOutOfRangeException("Max idle hours's value is too big!");
                    
                this.hoursIdle = value; 
            }
        }

        public uint? HoursTalk
        {
            get { return this.hoursTalk; }
            set
            {
                if (value.GetValueOrDefault() > MaxTalkHours)
                    throw new ArgumentOutOfRangeException("Max talk hours's value is too big!");
            
                this.hoursTalk = value;
            }
        }

        // Override method
        public override string ToString()
        {
            StringBuilder batteryInfo = new StringBuilder();

            batteryInfo.AppendLine("--> BATTERY <--");
            batteryInfo.AppendLine("Model: " + this.Model);

            if (hoursIdle.HasValue) 
                batteryInfo.AppendLine("Hours idle: " + this.hoursIdle);

            if (hoursTalk.HasValue)
                batteryInfo.AppendLine("Hours talk: " + this.hoursTalk);

            return batteryInfo.ToString();
        }
    }
}