namespace Phonebook.ConsoleClient
{
    using System;
    using Phonebook.ConsoleClient.Visitors;
    using Phonebook.Data;
    using Phonebook.Data.Loggers;

    internal class PhonebookEntryPoint
    {
        internal static void Main()
        {
            #if DEBUG
            Console.SetIn(new System.IO.StreamReader("../../input.txt"));
            #endif

            var commandProcessor = new CommandProcessorFacade();
            var consoleLogger = new StringBuilderLogger();
            
            while (true)
            {
                string line = Console.ReadLine();
                if (line == "End" || string.IsNullOrEmpty(line))
                {
                    break;
                }

                var commandResultMessage = commandProcessor.ProcessCommand(line);
                consoleLogger.AppendLine(commandResultMessage);
            }

            //! Visitor
            consoleLogger.Accept(new ConsoleLoggerVisitorWithoutNewLine());
        }
    }
}