namespace Phonebook.ConsoleClient
{
    using System;
    using System.Linq;
    using System.Text;
    using Phonebook.Data;

    internal class PhonebookDemo
    {
        internal static void Main()
        {
            #if DEBUG
            Console.SetIn(new System.IO.StreamReader("../../input.txt"));
            #endif

            var phonebookRepository = new PhonebookRepositoryFast();
            var commandFactory = new CommandFactory();
            var commandProcessor = new CommandProcessor(phonebookRepository);
            var output = new StringBuilder();

            while (true)
            {
                string line = Console.ReadLine();
                if (line == "End" || string.IsNullOrEmpty(line))
                {
                    break;
                }

                var command = commandFactory.Parse(line);
                var result = commandProcessor.ProcessCommand(command);
                output.AppendLine(result);
            }

            Console.Write(output);
        }
    }
}