using System;
using System.Linq;
using System.Text;

namespace Events
{
    public class EventProcessingEngine
    {
        private static readonly StringBuilder output = new StringBuilder();
        private static readonly EventHolder events = new EventHolder();

        private const string AddEventsCommand = "AddEvent";
        private const string DeleteEventsCommand = "DeleteEvents";
        private const string ListEventsCommand = "ListEvents";

        private const char CommandSeparator = '|';

        static void Main()
        {
            bool hasValidCommand;

            do
            {
                hasValidCommand = ExecuteNextCommand();
            }
            while (hasValidCommand);

            Console.WriteLine(output);
        }

        private static bool ExecuteNextCommand()
        {
            string command = Console.ReadLine();

            if (string.IsNullOrEmpty(command))
            {
                return false;
            }

            switch (command[0])
            {
                case 'A':
                    {
                        AddEvent(command);
                        return true;
                    }
                case 'D':
                    {
                        DeleteEvents(command);
                        return true;
                    }
                case 'L':
                    {
                        ListEvents(command);
                        return true;
                    }
                default:
                    {
                        return false;
                    }
            }
        }

        private static void ListEvents(string command)
        {
            DateTime dateAndTime = GetDateAndTime(command, ListEventsCommand);

            int pipeIndex = command.IndexOf(CommandSeparator);
            string countAsString = command.Substring(pipeIndex + 1);
            int count = int.Parse(countAsString);

            events.ListEvents(dateAndTime, count);
        }

        private static void DeleteEvents(string command)
        {
            string title = command.Substring(DeleteEventsCommand.Length + 1);
            events.DeleteEvents(title);
        }

        private static void AddEvent(string command)
        {
            DateTime date;
            string title;
            string location;

            GetParameters(command, AddEventsCommand, out date, out title, out location);

            events.AddEvent(date, title, location);
        }

        private static void GetParameters(
            string commandForExecution,
            string commandType,
            out DateTime dateAndTime,
            out string eventTitle,
            out string eventLocation)
        {
            dateAndTime = GetDateAndTime(commandForExecution, commandType);

            int firstPipeIndex = commandForExecution.IndexOf(CommandSeparator);
            int lastPipeIndex = commandForExecution.LastIndexOf(CommandSeparator);
            int startIndex = firstPipeIndex + 1;

            if (firstPipeIndex == lastPipeIndex)
            {
                eventTitle = commandForExecution.Substring(startIndex).Trim();
                eventLocation = string.Empty;
            }
            else
            {
                int length = lastPipeIndex - firstPipeIndex - 1;
                eventTitle = commandForExecution.Substring(startIndex, length).Trim();

                eventLocation = commandForExecution.Substring(startIndex).Trim();
            }
        }

        private static DateTime GetDateAndTime(string command, string commandType)
        {
            string dateTimeAsString = command.Substring(commandType.Length + 1, 20);

            DateTime dateTime = DateTime.Parse(dateTimeAsString);

            return dateTime;
        }
    }
}