// 2013-11-07 15:02:52

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;


// .\AudioDocument.cs


namespace DocumentSystem
{
    public class AudioDocument : MultimediaDocument
    {
        public int SampleRate
        {
            get
            {
                return this.GetProperty("SampleRate").ToInteger();
            }
            set
            {
                this.LoadProperty("SampleRate", value.ToString());
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

// .\BinaryDocument.cs


namespace DocumentSystem
{
    public abstract class BinaryDocument : Document
    {
        public ulong Size
        {
            get
            {
                return this.GetProperty("Size").ToUnsignedLong();
            }
            set
            {
                this.LoadProperty("Size", value.ToString());
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

// .\Document.cs


namespace DocumentSystem
{
    // TODO: Implement ToString()
    public abstract class Document : IDocument
    {
        public string Name
        {
            get
            {
                return this.GetProperty("Name") as string;
            }
            set
            {
                this.LoadProperty("Name", value.ToString());
            }
        }

        public string Content
        {
            get
            {
                return this.GetProperty("Content").ToString();
            }
            set
            {
                this.LoadProperty("Content", value.ToString());
            }
        }

        protected readonly Dictionary<string, object> properties = new Dictionary<string, object>();

        public void LoadProperty(string key, string value)
        {
            string loweredKey = key.ToLower();
            if (this.properties.ContainsKey(loweredKey))
            {
                this.properties[loweredKey] = value;
            }
            else
            {
                this.properties.Add(loweredKey, value);
            }
        }

        public void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            output = this.properties.ToList();
            output = output.OrderBy(x => x.Key).ToList();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(this.GetType().Name);
            sb.Append('[');

            var list = this.properties.ToList();
            list = list.OrderBy(x => x.Key).ToList();

            foreach (var item in list)
            {
                if (item.Value != null)
                {
                    sb.AppendFormat("{0}={1};", item.Key.ToLower(), item.Value);
                }
            }

            string result = sb.ToString().Trim(';') + "]";
            return result;
        }

        protected object GetProperty(string key)
        {
            string loweredKey = key.ToLower();
            if (this.properties.ContainsKey(loweredKey))
            {
                return properties[loweredKey];
            }
            else
            {
                return null;
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

// .\DocumentSystem.cs


namespace DocumentSystem
{
    public class DocumentSystem
    {
        private IList<IDocument> documents;

        private KeyValuePair<string, string> ParseAttribute(string attribute)
        {
            var parts = attribute.Split('=');
            return new KeyValuePair<string,string>(parts[0], parts[1]);
        }

        public DocumentSystem()
        {
            this.documents = new List<IDocument>();
        }

        private string AddDocument(IDocument document, string[] attributes)
        {
            foreach (var attribute in attributes)
            {
                var keyValue = this.ParseAttribute(attribute);
                document.LoadProperty(keyValue.Key, keyValue.Value);
            }

            if (document.Name == null)
            {
                return "Document has no name";
            }
            else
            {
                documents.Add(document);
                return string.Format("Document added: {0}", document.Name);
            }
        }

        public string AddTextDocument(string[] attributes)
        {
            var document = new TextDocument();
            return this.AddDocument(document, attributes);
        }

        public string AddPdfDocument(string[] attributes)
        {
            var document = new PdfDocument();
            return this.AddDocument(document, attributes);
        }

        public string AddWordDocument(string[] attributes)
        {
            var document = new WordDocument();
            return this.AddDocument(document, attributes);
        }

        public string AddExcelDocument(string[] attributes)
        {
            var document = new ExcelDocument();
            return this.AddDocument(document, attributes);
        }

        public string AddAudioDocument(string[] attributes)
        {
            var document = new AudioDocument();
            return this.AddDocument(document, attributes);
        }

        public string AddVideoDocument(string[] attributes)
        {
            var document = new VideoDocument();
            return this.AddDocument(document, attributes);
        }

        public string ListDocuments()
        {
            var sb = new StringBuilder();
            foreach (var document in documents)
            {
                sb.AppendLine(document.ToString());
            }
            if (sb.Length == 0)
            {
                return "No documents found";
            }
            return sb.ToString().Trim();
        }

        public string EncryptDocument(string name)
        {
            var sb = new StringBuilder();
            foreach (var document in documents)
            {
                if (document.Name == name)
                {
                    if (document is EncryptableDocument)
                    {
                        (document as EncryptableDocument).Encrypt();
                        sb.AppendLine(string.Format("Document encrypted: {0}", document.Name));
                    }
                    else
                    {
                        sb.AppendLine(string.Format("Document does not support encryption: {0}", document.Name));
                    }
                }
            }

            if (sb.Length == 0)
            {
                sb.AppendLine(string.Format("Document not found: {0}", name));
            }

            return sb.ToString().Trim();
        }

        public string DecryptDocument(string name)
        {
            var sb = new StringBuilder();
            foreach (var document in documents)
            {
                if (document.Name == name)
                {
                    if (document is EncryptableDocument)
                    {
                        (document as EncryptableDocument).Decrypt();
                        sb.AppendLine(string.Format("Document decrypted: {0}", document.Name));
                    }
                    else
                    {
                        sb.AppendLine(string.Format("Document does not support decryption: {0}", document.Name));
                    }
                }
            }

            if (sb.Length == 0)
            {
                sb.AppendLine(string.Format("Document not found: {0}", name));
            }

            return sb.ToString().Trim();
        }

        public string EncryptAllDocuments()
        {
            bool atLeastOneDocumentEncrypted = false;
            foreach (var document in documents)
            {
                if (document is EncryptableDocument)
                {
                    (document as EncryptableDocument).Encrypt();
                    atLeastOneDocumentEncrypted = true;
                }
            }

            if (atLeastOneDocumentEncrypted)
            {
                return "All documents encrypted";
            }
            else
            {
                return "No encryptable documents found";
            }
        }

        public string ChangeContent(string name, string content)
        {
            var sb = new StringBuilder();
            foreach (var document in documents)
            {
                if (document.Name == name)
                {
                    if (document is IEditable)
                    {
                        (document as IEditable).ChangeContent(content);
                        sb.AppendLine(string.Format("Document content changed: {0}", document.Name));
                    }
                    else
                    {
                        sb.AppendLine(string.Format("Document is not editable: {0}", document.Name));
                    }
                }
            }

            if (sb.Length == 0)
            {
                sb.AppendLine(string.Format("Document not found: {0}", name));
            }

            return sb.ToString().Trim();
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

// .\DocumentSystemConsole.cs


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
    // TODO: Implement ToString() ([encrypted])
    public abstract class EncryptableDocument : BinaryDocument, IEncryptable
    {
        private bool isEncrypted = false;

        public bool IsEncrypted
        {
            get { return isEncrypted; }
        }

        public void Encrypt()
        {
            this.isEncrypted = true;
        }

        public void Decrypt()
        {
            this.isEncrypted = false;
        }

        public override string ToString()
        {
            if (this.isEncrypted)
            {
                return string.Format("{0}[encrypted]", this.GetType().Name);
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
    public class ExcelDocument : OfficeDocument
    {
        public int NumberOfRows
        {
            get
            {
                return this.GetProperty("rows").ToInteger();
            }
            set
            {
                this.LoadProperty("rows", value.ToString());
            }
        }

        public int NumberOfColumns
        {
            get
            {
                return this.GetProperty("cols").ToInteger();
            }
            set
            {
                this.LoadProperty("cols", value.ToString());
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

// .\ExtensionMethods.cs


namespace DocumentSystem
{
    public static class ExtensionMethods
    {
        public static int ToInteger(this object obj)
        {
            int result = 0;
            int.TryParse(obj.ToString(), out result);
            return result;
        }

        public static ulong ToUnsignedLong(this object obj)
        {
            ulong result = 0;
            ulong.TryParse(obj.ToString(), out result);
            return result;
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
        public int Length
        {
            get
            {
                return this.GetProperty("Length").ToInteger();
            }
            set
            {
                this.LoadProperty("Length", value.ToString());
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

// .\OfficeDocument.cs


namespace DocumentSystem
{
    public abstract class OfficeDocument : EncryptableDocument
    {
        public string Version
        {
            get
            {
                return this.GetProperty("Version").ToString();
            }
            set
            {
                this.LoadProperty("Version", value.ToString());
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

// .\PdfDocument.cs


namespace DocumentSystem
{
    public class PdfDocument : EncryptableDocument
    {
        public int NumberOfPages 
        {
            get
            {
                return this.GetProperty("pages").ToInteger();
            }
            set
            {
                this.LoadProperty("pages", value.ToString());
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

// .\TextDocument.cs


namespace DocumentSystem
{
    public class TextDocument : Document, IEditable
    {
        public string Charset
        {
            get
            {
                return this.GetProperty("chars").ToString();
            }
            set
            {
                this.LoadProperty("chars", value.ToString());
            }
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
        public int FrameRate 
        {
            get
            {
                return this.GetProperty("framerate").ToInteger();
            }
            set
            {
                this.LoadProperty("framerate", value.ToString());
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

// .\WordDocument.cs


namespace DocumentSystem
{
    public class WordDocument : OfficeDocument, IEditable
    {
        public ulong NumberOfCharacters
        {
            get
            {
                return this.GetProperty("chars").ToUnsignedLong();
            }
            set
            {
                this.LoadProperty("chars", value.ToString());
            }
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
