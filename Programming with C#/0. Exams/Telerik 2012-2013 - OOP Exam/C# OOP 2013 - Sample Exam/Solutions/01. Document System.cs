using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;

class AudioDocument : MultimediaDocument
{
    public long? SampleRate { get; private set; }

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

abstract class BinaryDocument : Document
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

abstract class Document : IDocument
{
    public string Name { get; private set; }

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
        var output = new StringBuilder();
        output.Append(this.GetType().Name + "[");

        var docInfo = new List<KeyValuePair<string, object>>();
        this.SaveAllProperties(docInfo);

        var sortedAttributes = docInfo.OrderBy(attrib => attrib.Key);

        foreach (var item in sortedAttributes)
        {
            if (item.Value != null)
            {
                output.AppendFormat("{0}={1};", item.Key, item.Value);
            }
        }

        output.Length--;

        output.Append("]");

        return output.ToString();
    }
}

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

class ExcelDocument : OfficeDocument
{
    public long? NumberOfRows { get; set; }

    public long? NumberOfColumns { get; set; }

    public override void LoadProperty(string key, string value)
    {
        if (key.Equals("rows"))
        {
            this.NumberOfRows = long.Parse(value);
        }
        else if (key.Equals("cols"))
        {
            this.NumberOfColumns = long.Parse(value);
        }
        else
        {
            base.LoadProperty(key, value);
        }
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        output.Add(new KeyValuePair<string, object>("rows", this.NumberOfRows));
        output.Add(new KeyValuePair<string, object>("cols", this.NumberOfColumns));

        base.SaveAllProperties(output);
    }
}

public interface IDocument
{
    string Name { get; }

    string Content { get; }

    void LoadProperty(string key, string value);

    void SaveAllProperties(IList<KeyValuePair<string, object>> output);

    string ToString();
}

public interface IEditable
{
    void ChangeContent(string newContent);
}

public interface IEncryptable
{
    bool IsEncrypted { get; }

    void Encrypt();

    void Decrypt();
}

abstract class MultimediaDocument : BinaryDocument
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

abstract class OfficeDocument : EncryptableDocument
{
    public string Version { get; protected set; }

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

class PDFDocument : EncryptableDocument
{
    public long? NumberOfPages { get; private set; }

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

class TextDocument : Document, IEditable
{
    public string Charset { get; private set; }

    public void ChangeContent(string newContent)
    {
        this.Content = newContent;
    }

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
}

class VideoDocument : MultimediaDocument
{
    public long? FrameRate { get; private set; }

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

class WordDocument : OfficeDocument, IEditable
{
    public long? NumberOfCharacters { get; private set; }

    public void ChangeContent(string newContent)
    {
        this.Content = newContent;
    }

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
}