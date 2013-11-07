// 2013-11-07 15:05:42

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;


// .\AudioDocument.cs


namespace DocumentSystem
{
    class AudioDocument : MultimediaDocument
    {
        public long SampleRate { get; set; }

        public override void LoadProperty(string key, string value)
        {
            if (key.Equals("samplerate"))
            {
                this.SampleRate = long.Parse(value);
            }
            else
            {
                base.LoadProperty(key, value);
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            output.Add(new KeyValuePair<string, object>("samplerate", this.SampleRate));

            base.SaveAllProperties(output);
        }
    }
}
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!

// .\BinaryDocument.cs


namespace DocumentSystem
{
    public abstract class BinaryDocument : Document
    {
        public long? Size { get; protected set; }

        public override void LoadProperty(string key, string value)
        {
            if (key.Equals("size"))
            {
                this.Size = long.Parse(value);
            }
            else
            {
                base.LoadProperty(key, value);
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            output.Add(new KeyValuePair<string, object>("size", this.Size));

            base.SaveAllProperties(output);
        }
    }
}
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!

// .\Document.cs


namespace DocumentSystem
{
    public class Document : IDocument
    {
        public string Name { get; protected set; }

        public string Content { get; protected set; }

        public virtual void LoadProperty(string key, string value)
        {
            if (key.Equals("name"))
            {
                this.Name = value;
            }
            else if (key.Equals("content"))
            {
                this.Content = value;
            }
        }

        public virtual void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            output.Add(new KeyValuePair<string, object>("name", this.Name));
            output.Add(new KeyValuePair<string, object>("content", this.Content));
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append(this.GetType().Name);
            result.Append("[");

            var attributes = new List<KeyValuePair<string, object>>();
            this.SaveAllProperties(attributes);
            var sortedAttributes = attributes.OrderBy(attrib => attrib.Key);

            foreach (var attrib in sortedAttributes)
            { 
                if (attrib.Value != null)
                {
                    result.Append(attrib.Key + "=" + attrib.Value + ";");
                }
            }

            result.Length--;
            result.Append("]");

            return result.ToString();
        }
    }
}
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!

// .\DocumentSystem.cs


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
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!

// .\EncryptableDocument.cs


namespace DocumentSystem
{
    abstract class EncryptableDocument : BinaryDocument, IEncryptable
    {
        public bool IsEncrypted { get; private set; }

        public void Encrypt()
        {
            this.IsEncrypted = true;
        }

        public void Decrypt()
        {
            this.IsEncrypted = false;
        }

        public override string ToString()
        {
            if (this.IsEncrypted)
            {
                return this.GetType().Name + "[encrypted]";
            }
            else
            {
                return base.ToString();
            }
        }
    }
}
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!

// .\ExcelDocument.cs


namespace DocumentSystem
{
    class ExcelDocument : OfficeDocument
    {
        public int? NumberOfRows { get; set; }

        public int? NumberOfCols { get; set; }

        public override void LoadProperty(string key, string value)
        {
            if (key.Equals("rows"))
            {
                this.NumberOfRows = int.Parse(value);
            }
            else if (key.Equals("cols"))
            {
                this.NumberOfCols = int.Parse(value);
            }
            else
            {
                base.LoadProperty(key, value);
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            output.Add(new KeyValuePair<string, object>("rows", this.NumberOfRows));
            output.Add(new KeyValuePair<string, object>("cols", this.NumberOfCols));

            base.SaveAllProperties(output);
        }
    }
}
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!

// .\IDocument.cs


namespace DocumentSystem
{
    public interface IDocument
    {
        string Name { get; }

        string Content { get; }

        void LoadProperty(string key, string value);

        void SaveAllProperties(IList<KeyValuePair<string, object>> output);

        string ToString();
    }
}
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!

// .\IEditable.cs

namespace DocumentSystem
{
    public interface IEditable
    {
        void ChangeContent(string newContent);
    }
}
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!

// .\IEncryptable.cs

namespace DocumentSystem
{
    public interface IEncryptable
    {
        bool IsEncrypted { get; }

        void Encrypt();

        void Decrypt();
    }
}
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!

// .\MultimediaDocument.cs


namespace DocumentSystem
{
    public abstract class MultimediaDocument : BinaryDocument
    {
        public long? Length { get; protected set; }

        public override void LoadProperty(string key, string value)
        {
            if (key.Equals("length"))
            {
                this.Length = long.Parse(value);
            }
            else
            {
                base.LoadProperty(key, value);
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            output.Add(new KeyValuePair<string, object>("length", this.Length));

            base.SaveAllProperties(output);
        }
    }
}
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!

// .\OfficeDocument.cs


namespace DocumentSystem
{
    abstract class OfficeDocument : EncryptableDocument
    {
        public string Version { get; set; }

        public override void LoadProperty(string key, string value)
        {
            if (key.Equals("version"))
            {
                this.Version = value;
            }
            else
            {
                base.LoadProperty(key, value);
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            output.Add(new KeyValuePair<string, object>("version", this.Version));

            base.SaveAllProperties(output);
        }
    }
}
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!

// .\PdfDocument.cs


namespace DocumentSystem
{
    class PDFDocument : EncryptableDocument
    {
        public long? NumberOfPages { get; set; }

        public override void LoadProperty(string key, string value)
        {
            if (key.Equals("pages"))
            {
                this.NumberOfPages = long.Parse(value);
            }
            else
            {
                base.LoadProperty(key, value);
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            output.Add(new KeyValuePair<string, object>("pages", this.NumberOfPages));

            base.SaveAllProperties(output);
        }
    }
}
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!

// .\TextDocument.cs


namespace DocumentSystem
{
    class TextDocument : Document, IEditable
    {
        public string Charset { get; set; }

        public override void LoadProperty(string key, string value)
        {
            if (key.Equals("charset"))
            {
                this.Charset = value;
            }
            else
            {
                base.LoadProperty(key, value);
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            output.Add(new KeyValuePair<string, object>("charset", this.Charset));

            base.SaveAllProperties(output);
        }

        public void ChangeContent(string newContent)
        {
            this.Content = newContent;
        }
    }
}
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!

// .\VideoDocument.cs


namespace DocumentSystem
{
    public class VideoDocument : MultimediaDocument
    {
        public long? FrameRate { get; set; }

        public override void LoadProperty(string key, string value)
        {
            if (key.Equals("framerate"))
            {
                this.FrameRate = long.Parse(value);
            }
            else
            {
                base.LoadProperty(key, value);
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            output.Add(new KeyValuePair<string, object>("framerate", this.FrameRate));

            base.SaveAllProperties(output);
        }
    }
}
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!

// .\WordDocument.cs


namespace DocumentSystem
{
    class WordDocument : OfficeDocument, IEditable
    {
        public long? NumberOfCharacters { get; set; }

        public override void LoadProperty(string key, string value)
        {
            if (key.Equals("chars"))
            {
                this.NumberOfCharacters = long.Parse(value);
            }
            else
            {
                base.LoadProperty(key, value);
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            output.Add(new KeyValuePair<string, object>("chars", this.NumberOfCharacters));

            base.SaveAllProperties(output);
        }

        public void ChangeContent(string newContent)
        {
            this.Content = newContent;
        }
    }
}
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
// !!! DON'T FORGET TO SET THE PROBLEM NUMBER !!!
