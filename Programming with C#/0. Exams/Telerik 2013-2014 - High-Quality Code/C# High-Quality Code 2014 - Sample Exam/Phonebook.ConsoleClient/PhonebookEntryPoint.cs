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

            var commandParser = new CommandParser();
            var commandFactory = new CommandFactoryWithLazyLoading();
            //var commandProcessor = new CommandProcessor();
            var consoleLogger = new StringBuilderLogger();

            while (true)
            {
                string line = Console.ReadLine();
                if (line == "End" || string.IsNullOrEmpty(line))
                {
                    break;
                }

                var commandInfo = commandParser.Parse(line);
                var command = commandFactory.Create(commandInfo);
                var result = command.Execute(commandInfo.Arguments);
                consoleLogger.AppendLine(result);

                //var result = commandProcessor.ProcessCommand(commandInfo);
                //consoleLogger.AppendLine(result);
            }

            //! Visitor
            consoleLogger.Accept(new ConsoleLoggerVisitorWithoutNewLine());
            //logger.Accept(new ConsoleLoggerVisitorWithNewLine());
            //Console.Write(logger.GetAllText());
        }
    }
}