using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wintellect.PowerCollections;

class CalendarSystem
{
    static readonly StringBuilder output = new StringBuilder();

    static MultiDictionary<string, Event> byTitle = new MultiDictionary<string, Event>(true, new CaseInsensitiveComparer());
    static OrderedMultiDictionary<DateTime, Event> byDate = new OrderedMultiDictionary<DateTime, Event>(true);

    public static void Main()
    {
        ExecuteCommands();

        Console.Write(output);
    }
  
    static void ExecuteCommands()
    {
        string[] parameters;
        string command = string.Empty;
        int firstSpace = -1;

        string input = Console.ReadLine();

        while (input != "End")
        {
            firstSpace = input.IndexOf(' ');

            command = input.Substring(0, firstSpace);
            parameters = input.Substring(firstSpace + 1).Split('|').Select(a => a.Trim()).ToArray();

            switch (command)
            {
                case "AddEvent": output.AppendLine(AddEvent(parameters)); break;
                case "DeleteEvents": output.AppendLine(DeleteEvents(parameters[0])); break;
                case "ListEvents": ListEvents(parameters); break;
            }

            input = Console.ReadLine();
        }
    }

    static string AddEvent(string[] parameters)
    {
        var ev = new Event(DateTime.Parse(parameters[0]), parameters[1]);

        if (parameters.Length >= 3)
            ev.Location = parameters[2];

        byTitle.Add(ev.Title, ev);
        byDate.Add(ev.Date, ev);

        return "Event added";
    }

    static string DeleteEvents(string title)
    {
        var eventsForDeletion = byTitle[title];
        int count = eventsForDeletion.Count;

        foreach (var ev in eventsForDeletion)
            byDate[ev.Date].Remove(ev);

        byTitle[title].Clear();

        return count > 0 ? count + " events deleted" : "No events found";
    }

    static void ListEvents(string[] parameters)
    {
        DateTime from = DateTime.Parse(parameters[0]);
        int count = int.Parse(parameters[1]);

        PrintSortedProducts(byDate.RangeFrom(from, true).Values.Take(count).ToArray());
    }

    static void PrintSortedProducts(ICollection<Event> events)
    {
        if (events.Count == 0)
        {
            output.AppendLine("No events found");
            return;
        }

        output.AppendLine(string.Join(Environment.NewLine, events));
    }
}

class Event : IComparable<Event>
{
    public Event(DateTime date, string title, string location = null)
    {
        this.Date = date;
        this.Title = title;
        this.Location = location;
    }

    public DateTime Date { get; set; }

    public string Title { get; set; }

    public string Location { get; set; }

    public int CompareTo(Event other)
    {
        int comparisonByDate = DateTime.Compare(this.Date, other.Date);

        if (comparisonByDate != 0)
            return comparisonByDate;

        int comparisonByTitle = string.Compare(this.Title, other.Title, StringComparison.InvariantCulture);

        if (comparisonByTitle != 0)
            return comparisonByTitle;

        return string.Compare(this.Location, other.Location, StringComparison.InvariantCulture);
    }

    public override string ToString()
    {
        return string.Format("{0:yyyy-MM-ddTHH:mm:ss} | {1}{2}",
            this.Date, this.Title, this.Location != null ? " | " + this.Location : string.Empty);
    }
}

class CaseInsensitiveComparer : IEqualityComparer<string>
{
    public bool Equals(string x, string y)
    {
        return string.Equals(x, y, StringComparison.CurrentCultureIgnoreCase);
    }

    public int GetHashCode(string obj)
    {
        return obj.ToLower().GetHashCode();
    }
}