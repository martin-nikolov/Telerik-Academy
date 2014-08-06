namespace Computers.Console
{
    using System;
    using Computers.Console.TemplateMethod;
    using Computers.Data;

    public class ComputersEntryPoint
    {
        public static void Main()
        {
            #if DEBUG
            Console.SetIn(new System.IO.StreamReader("../../input_1.txt"));
            #endif

            string manufacturerString = Console.ReadLine();
            var manufacturerFactory = new ManufacturerFactory();
            var manufacturer = manufacturerFactory.Create(manufacturerString);

            var store = new Store(manufacturer);
            var commandProcessor = new CommandProcessor(store);
            var commandExecutor = new CommandExecutor(commandProcessor);

            while (true)
            {
                var line = Console.ReadLine();
                if (string.IsNullOrEmpty(line) || line.StartsWith("Exit"))
                {
                    break;
                }

                commandExecutor.Execute(line);
            }
        }
    }
}