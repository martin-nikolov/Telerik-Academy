using System;
using System.Linq;
using System.Text;

namespace Events
{
    public class MessageLog
    {
        private const string EventAddedMessage = "Event added";
        private const string NoEventsFoundMessage = "No events found";
        private const string EventsDeletedMessage = "event(s) deleted";

        private readonly StringBuilder output = new StringBuilder();

        public string Output
        {
            get { return this.output.ToString(); }
        }

        public void EventAdded()
        {
            this.output.AppendLine(EventAddedMessage);
        }

        public void EventDeleted(int count)
        {
            if (count == 0)
            {
                this.NoEventsFound();
            }
            else
            {
                this.output.AppendLine(string.Format("{0} {1}", count, EventsDeletedMessage));
            }
        }

        public void NoEventsFound()
        {
            this.output.AppendLine(NoEventsFoundMessage);
        }

        public void PrintEvent(Event eventToPrint)
        {
            if (eventToPrint != null)
            {
                this.output.AppendLine(eventToPrint.ToString());
            }
        }
    }
}