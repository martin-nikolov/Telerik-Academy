using Microsoft.CSharp;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System;

abstract class Course : ICourse
{
    private string name;

    public Course(string name, ITeacher teacher)
    {
        this.Name = name;
        this.Teacher = teacher;

        this.Topics = new List<string>();
    }

    public string Name
    {
        get { return this.name; }
        set
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException("Name");

            this.name = value;
        }
    }

    public ITeacher Teacher { get; set; }

    public IList<string> Topics { get; set; }

    public virtual void AddTopic(string topic)
    {
        this.Topics.Add(topic);
    }

    public override string ToString()
    {
        var output = new StringBuilder();
        output.AppendFormat("{0}: Name={1}", this.GetType().Name, this.Name);

        if (this.Teacher != null)
        {
            output.AppendFormat("; Teacher={0}", this.Teacher.Name);
        }

        if (this.Topics.Count > 0)
        {
            output.AppendFormat("; Topics=[{0}]", string.Join(", ", this.Topics));
        }
        
        return output.ToString();
    }
}

public class CourseFactory : ICourseFactory
{
    public ITeacher CreateTeacher(string name)
    {
        return new Teacher(name);
    }

    public ILocalCourse CreateLocalCourse(string name, ITeacher teacher, string lab)
    {
        return new LocalCourse(name, teacher, lab);
    }

    public IOffsiteCourse CreateOffsiteCourse(string name, ITeacher teacher, string town)
    {
        return new OffsiteCourse(name, teacher, town);
    }
}

public interface ICourse
{
    string Name { get; set; }

    ITeacher Teacher { get; set; }

    void AddTopic(string topic);

    string ToString();
}

public interface ICourseFactory
{
    ITeacher CreateTeacher(string name);

    ILocalCourse CreateLocalCourse(string name, ITeacher teacher, string lab);

    IOffsiteCourse CreateOffsiteCourse(string name, ITeacher teacher, string town);
}

public interface ILocalCourse : ICourse
{
    string Lab { get; set; }
}

public interface IOffsiteCourse : ICourse
{
    string Town { get; set; }
}

public interface ITeacher
{
    string Name { get; set; }

    void AddCourse(ICourse course);

    string ToString();
}

class LocalCourse : Course, ILocalCourse
{
    private string lab;

    public LocalCourse(string name, ITeacher teacher, string lab)
        : base(name, teacher)
    {
        this.Lab = lab;
    }

    public string Lab
    {
        get { return this.lab; }
        set
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException("Lab");

            this.lab = value;
        }
    }

    public override string ToString()
    {
        return string.Format("{0}; Lab={1}", base.ToString(), this.Lab);
    }
}

class OffsiteCourse : Course, IOffsiteCourse
{
    private string town;

    public OffsiteCourse(string name, ITeacher teacher, string town)
        : base(name, teacher)
    {
        this.Town = town;
    }

    public string Town
    {
        get { return this.town; }
        set
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException("Town");

            this.town = value;
        }
    }

    public override string ToString()
    {
        return string.Format("{0}; Town={1}", base.ToString(), this.Town);
    }
}

public class SoftwareAcademyCommandExecutor
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

class Teacher : ITeacher
{
    private string name;

    public Teacher(string name)
    {
        this.Name = name;
        this.Courses = new List<ICourse>();
    }

    public string Name
    {
        get { return this.name; }
        set
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException("Name");

            this.name = value;
        }
    }

    public IList<ICourse> Courses { get; private set; }

    public void AddCourse(ICourse course)
    {
        this.Courses.Add(course);
    }

    public override string ToString()
    {
        var output = new StringBuilder();
        output.AppendFormat("{0}: Name={1}", this.GetType().Name, this.Name);

        if (this.Courses.Count > 0)
        {
            output.AppendFormat("; Courses=[{0}]", string.Join(", ", this.Courses.Select(i => i.Name)));
        }

        return output.ToString();
    }
}