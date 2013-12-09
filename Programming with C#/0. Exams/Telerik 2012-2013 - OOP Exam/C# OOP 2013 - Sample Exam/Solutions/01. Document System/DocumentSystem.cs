namespace DocumentSystem
{
    using System;
    using System.Collections.Generic;

    public class DocumentSystem
    {
        private static ICollection<IDocument> documents = new List<IDocument>();

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
            foreach (var attr in attributes)
            {
                string[] args = attr.Split('=');
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
                foreach (var document in documents)
                {
                    Console.WriteLine(document);
                }
            }
        }

        private static void EncryptDocument(string name)
        {
            bool found = false;

            foreach (var document in documents)
            {
                var encryptableDocument = document as IEncryptable;

                if (document.Name.Equals(name))
                {
                    found = true;

                    if (encryptableDocument != null)
                    {
                        encryptableDocument.Encrypt();
                        Console.WriteLine("Document encrypted: " + document.Name);
                    }
                    else
                    {
                        Console.WriteLine("Document does not support encryption: " + document.Name);
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

            foreach (var document in documents)
            {
                var decryptableDocument = document as IEncryptable;

                if (document.Name.Equals(name))
                {
                    found = true;

                    if (decryptableDocument != null)
                    {
                        decryptableDocument.Decrypt();
                        Console.WriteLine("Document decrypted: " + document.Name);
                    }
                    else
                    {
                        Console.WriteLine("Document does not support decryption: " + document.Name);
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
            bool fountEncryptable = false;

            foreach (var document in documents)
            {
                var decryptableDocument = document as IEncryptable;

                if (decryptableDocument != null)
                {
                    fountEncryptable = true;
                    decryptableDocument.Encrypt();
                }
            }

            Console.WriteLine(fountEncryptable ? "All documents encrypted" : "No encryptable documents found");
        }

        private static void ChangeContent(string name, string content)
        {
            bool found = false;

            foreach (var document in documents)
            {
                var editableDocument = document as IEditable;

                if (document.Name.Equals(name))
                {
                    found = true;

                    if (editableDocument != null)
                    {
                        editableDocument.ChangeContent(content);
                        Console.WriteLine("Document content changed: " + document.Name);
                    }
                    else
                    {
                        Console.WriteLine("Document is not editable: " + document.Name);
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