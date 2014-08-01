namespace Phonebook.ConsoleClient
{
    using System;
    using Phonebook.Data;

    internal class PhonebookEntryPoint
    {
        internal static void Main()
        {
            #if DEBUG
            Console.SetIn(new System.IO.StreamReader("../../input.txt"));
            #endif

            var commandProcessor = new CommandProcessor();
            var output = new StringBuilderLogger();

            while (true)
            {
                string line = Console.ReadLine();
                if (line == "End" || string.IsNullOrEmpty(line))
                {
                    break;
                }

                var result = commandProcessor.ProcessCommand(line);
                output.AppendLine(result);
            }

            Console.Write(output.GetAllText());
        }
    }
}