namespace Events
{
    using System;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class EventHolder
    {
        private readonly MultiDictionary<string, Event> byTitle = new MultiDictionary<string, Event>(true);
        private readonly OrderedBag<Event> byDate = new OrderedBag<Event>();

        private readonly MessageLog messageLog = new MessageLog();

        public string Log
        {
            get { return this.messageLog.Output; }
        }

        public void AddEvent(DateTime date, string title, string location)
        {
            Event newEvent = new Event(date, title, location);

            this.byTitle.Add(title.ToLower(), newEvent);
            this.byDate.Add(newEvent);

            this.messageLog.EventAdded();
        }

        public void DeleteEvents(string titleToDelete)
        {
            string title = titleToDelete.ToLower();
            int removedEvents = 0;

            foreach (var eventToRemove in this.byTitle[title])
            {
                removedEvents++;
                this.byDate.Remove(eventToRemove);
            }

            this.byTitle.Remove(title);
            this.messageLog.EventDeleted(removedEvents);
        }

        public void ListEvents(DateTime date, int count)
        {
            OrderedBag<Event>.View eventsToShow = this.byDate.RangeFrom(new Event(date, string.Empty, string.Empty), true);
            int showedEvents = 0;

            foreach (var eventToShow in eventsToShow)
            {
                if (showedEvents == count)
                {
                    break;
                }

                showedEvents++;
                this.messageLog.PrintEvent(eventToShow);
            }

            if (showedEvents == 0)
            {
                this.messageLog.NoEventsFound();
            }
        }
    }
}