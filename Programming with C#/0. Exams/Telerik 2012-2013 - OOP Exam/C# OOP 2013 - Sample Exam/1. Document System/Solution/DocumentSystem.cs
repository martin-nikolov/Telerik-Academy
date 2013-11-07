using System;
using System.Collections.Generic;

namespace DocumentSystem
{
    public class DocumentSystem
    {
        public static readonly IList<IDocument> documents = new List<IDocument>();

        static void Main()
        {
            IList<string> allCommands = ReadAllCommands();
            ExecuteCommands(allCommands);
        }

        private static IList<string> ReadAllCommands()
        {
            List<string> commands = new List<string>();
            while (true)
            {
                string commandLine = Console.ReadLine();
                if (commandLine == "")
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

        private static void ExecuteCommand(string cmd, string parameters)
        {
            string[] cmdAttributes = parameters.Split(
                new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            if (cmd == "AddTextDocument")
            {
                AddTextDocument(cmdAttributes);
            }
            else if (cmd == "AddPDFDocument")
            {
                AddPdfDocument(cmdAttributes);
            }
            else if (cmd == "AddWordDocument")
            {
                AddWordDocument(cmdAttributes);
            }
            else if (cmd == "AddExcelDocument")
            {
                AddExcelDocument(cmdAttributes);
            }
            else if (cmd == "AddAudioDocument")
            {
                AddAudioDocument(cmdAttributes);
            }
            else if (cmd == "AddVideoDocument")
            {
                AddVideoDocument(cmdAttributes);
            }
            else if (cmd == "ListDocuments")
            {
                ListDocuments();
            }
            else if (cmd == "EncryptDocument")
            {
                EncryptDocument(parameters);
            }
            else if (cmd == "DecryptDocument")
            {
                DecryptDocument(parameters);
            }
            else if (cmd == "EncryptAllDocuments")
            {
                EncryptAllDocuments();
            }
            else if (cmd == "ChangeContent")
            {
                ChangeContent(cmdAttributes[0], cmdAttributes[1]);
            }
            else
            {
                throw new InvalidOperationException("Invalid command: " + cmd);
            }
        }

        private static void AddDocument(IDocument document, string[] attributes)
        {
            foreach (var attrib in attributes)
            {
                string[] args = attrib.Split('=');
                document.LoadProperty(args[0], args[1]);
            }

            if (!string.IsNullOrEmpty(document.Name))
            {
                documents.Add(document);
                Console.WriteLine("Document added: " + document.Name);
            }
            else
            {
                Console.WriteLine("Document has no name");
            }
        }

        private static void AddTextDocument(string[] attributes)
        {
            AddDocument(new TextDocument(), attributes);
        }
       
        private static void AddPdfDocument(string[] attributes)
        {
            AddDocument(new PDFDocument(), attributes);
        }

        private static void AddWordDocument(string[] attributes)
        {
            AddDocument(new WordDocument(), attributes);
        }

        private static void AddExcelDocument(string[] attributes)
        {
            AddDocument(new ExcelDocument(), attributes);
        }

        private static void AddAudioDocument(string[] attributes)
        {
            AddDocument(new AudioDocument(), attributes);
        }

        private static void AddVideoDocument(string[] attributes)
        {
            AddDocument(new VideoDocument(), attributes);
        }

        private static void ListDocuments()
        {
            if (documents.Count == 0)
            {
                Console.WriteLine("No documents found");
            }
            else
            {
                foreach (var doc in documents)
                {
                    Console.WriteLine(doc);
                }
            }
        }

        private static void EncryptDocument(string name)
        {
            bool found = false;

            foreach (var doc in documents)
            {
                if (doc.Name.Equals(name))
                {
                    found = true;

                    if (doc is EncryptableDocument)
                    {
                        (doc as EncryptableDocument).Encrypt();
                        Console.WriteLine("Document encrypted: " + name);
                    }
                    else
                    {
                        Console.WriteLine("Document does not support encryption: " + name);
                    }
                }
            }

            if (!found)
            {
                Console.WriteLine("Document not found: " + name);
            }
        }

        private static void DecryptDocument(string name)
        {
            bool found = false;

            foreach (var doc in documents)
            {
                if (doc.Name.Equals(name))
                {
                    found = true;

                    if (doc is EncryptableDocument)
                    {
                        (doc as EncryptableDocument).Decrypt();
                        Console.WriteLine("Document decrypted: " + name);
                    }
                    else
                    {
                        Console.WriteLine("Document does not support decryption: " + name);
                    }
                }
            }

            if (!found)
            {
                Console.WriteLine("Document not found: " + name);
            }
        }

        private static void EncryptAllDocuments()
        {
            bool foundEncryptable = false;

            foreach (var doc in documents)
            {
                if (doc is EncryptableDocument)
                {
                    foundEncryptable = true;
                    (doc as EncryptableDocument).Encrypt();
                }
            }

            if (foundEncryptable)
            {
                Console.WriteLine("All documents encrypted");
            }
            else
            {
                Console.WriteLine("No encryptable documents found");
            }
        }

        private static void ChangeContent(string name, string content)
        {
            bool found = false;

            foreach (var doc in documents)
            {
                if (doc.Name.Equals(name))
                { 
                    found = true;

                    if (doc is IEditable)
                    {
                        (doc as IEditable).ChangeContent(content);
                        Console.WriteLine("Document content changed: " + name);
                    }
                    else
                    {
                        Console.WriteLine("Document is not editable: " + name);
                    }
                }
            }

            if (!found)
            {
                Console.WriteLine("Document not found: " + name);
            }
        }
    }
}