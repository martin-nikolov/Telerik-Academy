using System;
using System.CodeDom.Compiler;
using System.Reflection;
using System.Text;
using Microsoft.CSharp;

class RuntimeCompiledClass
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