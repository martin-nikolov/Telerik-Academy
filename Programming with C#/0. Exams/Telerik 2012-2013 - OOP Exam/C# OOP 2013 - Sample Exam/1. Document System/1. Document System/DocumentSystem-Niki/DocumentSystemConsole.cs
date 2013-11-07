using System;
using System.Collections.Generic;

namespace DocumentSystem
{
    public class DocumentSystemConsole
    {
        static DocumentSystem system;
        static void Main()
        {
            system = new DocumentSystem();
            IList<string> allCommands = ReadAllCommands();
            ExecuteCommands(allCommands);
        }

        private static IList<string> ReadAllCommands()
        {
            List<string> commands = new List<string>();
            while (true)
            {
                string commandLine = Console.ReadLine();
                if (commandLine == string.Empty)
                {
                    // End of commands
                    break;
                }
                commands.Add(commandLine);
            }
            return commands;
        }

        private static void ExecuteCommands(IList<string> commands)
        {
            foreach (var commandLine in commands)
            {
                int paramsStartIndex = commandLine.IndexOf("[");
                string cmd = commandLine.Substring(0, paramsStartIndex);
                int paramsEndIndex = commandLine.IndexOf("]");
                string parameters = commandLine.Substring(
                    paramsStartIndex + 1, paramsEndIndex - paramsStartIndex - 1);
                ExecuteCommand(cmd, parameters);


            }
        }

        private static void ExecuteCommand(string commandName, string parameters)
        {
            string[] cmdAttributes = parameters.Split(
                new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            if (commandName == "AddTextDocument")
            {
                Console.WriteLine(system.AddTextDocument(cmdAttributes));
            }
            else if (commandName == "AddPDFDocument")
            {
                Console.WriteLine(system.AddPdfDocument(cmdAttributes));
            }
            else if (commandName == "AddWordDocument")
            {
                Console.WriteLine(system.AddWordDocument(cmdAttributes));
            }
            else if (commandName == "AddExcelDocument")
            {
                Console.WriteLine(system.AddExcelDocument(cmdAttributes));
            }
            else if (commandName == "AddAudioDocument")
            {
                Console.WriteLine(system.AddAudioDocument(cmdAttributes));
            }
            else if (commandName == "AddVideoDocument")
            {
                Console.WriteLine(system.AddVideoDocument(cmdAttributes));
            }
            else if (commandName == "ListDocuments")
            {
                Console.WriteLine(system.ListDocuments());
            }
            else if (commandName == "EncryptDocument")
            {
                Console.WriteLine(system.EncryptDocument(parameters));
            }
            else if (commandName == "DecryptDocument")
            {
                Console.WriteLine(system.DecryptDocument(parameters));
            }
            else if (commandName == "EncryptAllDocuments")
            {
                Console.WriteLine(system.EncryptAllDocuments());
            }
            else if (commandName == "ChangeContent")
            {
                Console.WriteLine(system.ChangeContent(cmdAttributes[0], cmdAttributes[1]));
            }
            else
            {
                throw new InvalidOperationException("Invalid command: " + commandName);
            }
        }
    }
}