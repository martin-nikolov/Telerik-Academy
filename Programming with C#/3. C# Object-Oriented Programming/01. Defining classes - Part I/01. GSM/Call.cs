/*
* 8. Create a class Call to hold a call performed through a GSM.
* It should contain date, time, dialed phone number and duration (in seconds).
* 
* 9. Add a property CallHistory in the GSM class to hold
* a list of the performed calls. Try to use the system class List<Call>.
*
* 10. Add methods in the GSM class for adding and deleting
* calls from the calls history. Add a method to clear the call history.
*
* 11. Add a method that calculates the total price of the calls
* in the call history. Assume the price per minute is fixed and
* is provided as a parameter.
*/

using System;
using System.Linq;
using System.Text;

namespace MobilePhone
{
    public class Call : IComparable<Call>
    {
        // Private Fields
        private DateTime date;
        private string dialedNumber;
        private TimeSpan duration = TimeSpan.Zero;

        // Constructor
        public Call(DateTime date, string dialedNumber, TimeSpan duration)
        {
            this.Date = date;
            this.DialedNumber = dialedNumber;
            this.Duration = duration;
        }

        // Properties
        public DateTime Date
        {
            get { return this.date; }
            set 
            {
                if (value == null)
                    throw new ArgumentNullException("Date and time cannot be null!");
               
                this.date = value; 
            }
        }

        public string DialedNumber
        {
            get { return this.dialedNumber; }
            set 
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException("Dialed number cannot be null!");
                
                this.dialedNumber = value; 
            }
        }

        public TimeSpan Duration
        {
            get { return this.duration; }
            set 
            { 
                if (value == TimeSpan.Zero)
                    throw new ArgumentNullException("Duration time cannot be null!");
                
                this.duration = value; 
            }
        }

        // Override methods
        public int CompareTo(Call other)
        {
            return (int)(this.Duration - other.Duration).TotalSeconds;
        }

        public override string ToString()
        {
            StringBuilder callInfo = new StringBuilder();
            
            callInfo.Append(string.Format("Number: {0} | Duration: {1} | Date: {2}",
                this.DialedNumber, this.Duration, this.Date));

            return callInfo.ToString();
        }
    }
}