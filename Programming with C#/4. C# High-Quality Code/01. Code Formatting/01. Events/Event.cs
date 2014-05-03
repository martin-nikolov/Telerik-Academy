namespace Events
{
    using System;
    using System.Linq;
    using System.Text;

    public class Event : IComparable
    {
        private const string EventMessageFormat = " | {0}";
        private const string DateTimeFormat = "yyyy-MM-ddTHH:mm:ss";
        private const string EventObjectIsNullExceptionMessage = "Object is not instance of Event";

        private DateTime date;
        private string title;
        private string location;

        public Event(DateTime date, string title, string location)
        {
            this.DateAndTime = date;
            this.Title = title;
            this.Location = location;
        }

        public DateTime DateAndTime
        {
            get { return this.date; }
            private set { this.date = value; }
        }

        public string Title
        {
            get { return this.title; }
            private set { this.title = value; }
        }

        public string Location
        {
            get { return this.location; }
            private set { this.location = value; }
        }

        public int CompareTo(object obj)
        {
            Event other = obj as Event;

            if (other != null)
            {
                int compareByDate = this.DateAndTime.CompareTo(other.DateAndTime);
                int compareByTitle = this.Title.CompareTo(other.Title);
                int compareByLocation = this.Location.CompareTo(other.Location);

                if (compareByDate == 0)
                {
                    if (compareByTitle == 0)
                    {
                        return compareByLocation;
                    }
                    else
                    {
                        return compareByTitle;
                    }
                }
                else
                {
                    return compareByDate;
                }
            }
            else
            {
                throw new ArgumentException(EventObjectIsNullExceptionMessage);
            }
        }

        public override string ToString()
        {
            StringBuilder eventMessage = new StringBuilder();
            eventMessage.Append(this.DateAndTime.ToString(DateTimeFormat));
            eventMessage.AppendFormat(EventMessageFormat, this.Title);

            if (!string.IsNullOrEmpty(this.Location) && !string.IsNullOrEmpty(this.Location))
            {
                eventMessage.AppendFormat(EventMessageFormat, this.Location);
            }

            return eventMessage.ToString();
        }
    }
}