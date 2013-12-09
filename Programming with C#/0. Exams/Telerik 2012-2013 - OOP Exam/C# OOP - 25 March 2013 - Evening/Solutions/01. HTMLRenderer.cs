using Microsoft.CSharp;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System;

class HtmlElement : IElement
{
    private ICollection<IElement> childElements;

    public HtmlElement(string name)
    {
        this.Name = name;
        this.childElements = new List<IElement>();
    }

    public HtmlElement(string name, string textContent)
        : this(name)
    {
        this.TextContent = textContent;
    }

    public string Name { get; private set; }

    public virtual string TextContent { get; set; }

    public virtual IEnumerable<IElement> ChildElements
    {
        get { return this.childElements; }
    }

    public virtual void AddElement(IElement element)
    {
        this.childElements.Add(element);
    }

    public virtual void Render(StringBuilder output)
    {
        output.AppendFormat(!string.IsNullOrEmpty(this.Name) ? "<" + this.Name + ">" : string.Empty);

        output.Append(!string.IsNullOrEmpty(this.TextContent) ? this.Encode(this.TextContent) : string.Empty);

        foreach (var child in this.ChildElements)
        {
            child.Render(output);
        }

        output.AppendFormat(!string.IsNullOrEmpty(this.Name) ? "</" + this.Name + ">" : string.Empty);
    }

    public override string ToString()
    {
        var output = new StringBuilder();
        this.Render(output);

        return output.ToString();
    }

    protected string Encode(string textContent)
    {
        return textContent.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;");
    }
}

public class HTMLElementFactory : IElementFactory
{
    public IElement CreateElement(string name)
    {
        return new HtmlElement(name);
    }

    public IElement CreateElement(string name, string content)
    {
        return new HtmlElement(name, content);
    }

    public ITable CreateTable(int rows, int cols)
    {
        return new HtmlTable(rows, cols);
    }
}

public class HTMLRendererCommandExecutor
{
    static void Main()
    {
        string csharpCode = ReadInputCSharpCode();
        CompileAndRun(csharpCode);
    }

    private static string ReadInputCSharpCode()
    {
        StringBuilder result = new StringBuilder();
        string line;
        while ((line = Console.ReadLine()) != "")
        {
            result.AppendLine(line);
        }
        return result.ToString();
    }

    static void CompileAndRun(string csharpCode)
    {
        // Prepare a C# program for compilation
        string[] csharpClass =
        {
            @"using System;

                public class RuntimeCompiledClass
                {
                   public static void Main()
                   {" +
            csharpCode + @"
                   }
                }"
        };

        // Compile the C# program
        CompilerParameters compilerParams = new CompilerParameters();
        compilerParams.GenerateInMemory = true;
        compilerParams.TempFiles = new TempFileCollection(".");
        compilerParams.ReferencedAssemblies.Add("System.dll");
        compilerParams.ReferencedAssemblies.Add(Assembly.GetExecutingAssembly().Location);
        CSharpCodeProvider csharpProvider = new CSharpCodeProvider();
        CompilerResults compile = csharpProvider.CompileAssemblyFromSource(
            compilerParams, csharpClass);

        // Check for compilation errors
        if (compile.Errors.HasErrors)
        {
            string errorMsg = "Compilation error: ";
            foreach (CompilerError ce in compile.Errors)
            {
                errorMsg += "\r\n" + ce.ToString();
            }
            throw new Exception(errorMsg);
        }

        // Invoke the Main() method of the compiled class
        Assembly assembly = compile.CompiledAssembly;
        Module module = assembly.GetModules()[0];
        Type type = module.GetType("RuntimeCompiledClass");
        MethodInfo methInfo = type.GetMethod("Main");
        methInfo.Invoke(null, null);
    }
}

class HtmlTable : HtmlElement, ITable
{
    private const string TableName = "table";
    private const string TableRowOpenTag = "<tr>";
    private const string TableRowCloseTag = "</tr>";
    private const string TableCellOpenTag = "<td>";
    private const string TableCellCloseTag = "</td>";

    private IElement[,] childElements;

    public HtmlTable(int rows, int cols)
        : base(TableName)
    {
        this.Rows = rows;
        this.Cols = cols;

        this.childElements = new IElement[this.Rows, this.Cols];
    }

    public int Rows { get; set; }

    public int Cols { get; set; }

    public IElement this[int row, int col]
    {
        get { return this.childElements[row, col]; }
        set { this.childElements[row, col] = value; }
    }

    public override void Render(StringBuilder output)
    {
        output.AppendFormat("<{0}>", TableName);

        for (int row = 0; row < this.Rows; row++)
        {
            output.Append(TableRowOpenTag);

            for (int col = 0; col < this.Cols; col++)
            {
                output.Append(TableCellOpenTag);
                output.Append(this.childElements[row, col]);
                output.Append(TableCellCloseTag);
            }

            output.Append(TableRowCloseTag);
        }

        output.AppendFormat("</{0}>", TableName);
    }

    public override string ToString()
    {
        var output = new StringBuilder();
        this.Render(output);

        return output.ToString();
    }
}

public interface IElement
{
    string Name { get; }

    string TextContent { get; set; }

    IEnumerable<IElement> ChildElements { get; }

    void AddElement(IElement element);

    void Render(StringBuilder output);

    string ToString();
}

public interface IElementFactory
{
    IElement CreateElement(string name);

    IElement CreateElement(string name, string content);

    ITable CreateTable(int rows, int cols);
}

public interface ITable : IElement
{
    int Rows { get; }

    int Cols { get; }

    IElement this[int row, int col] { get; set; }
}