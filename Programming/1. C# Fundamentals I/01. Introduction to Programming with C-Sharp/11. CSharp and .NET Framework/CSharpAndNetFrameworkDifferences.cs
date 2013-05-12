// 11. Describe the difference between C# and .NET Framework.

using System;

class CSharpAndNetFrameworkDifferences
{
    static void Main(string[] args)
    {
        Console.SetWindowSize(78, 25);
        Console.SetBufferSize(78, 27);

        string cSharp =
            @"It is an elegant and type-safe object-oriented language that enables
developers to build a variety of secure and robust applications
that run on the .NET Framework. You can use C# to create traditional
Windows client applications, XML Web services, distributed components,
client-server applications, database applications, and much, much more.";

        string dotNetFramework =
            @"C# programs run on the .NET Framework, an integral component of Windows
that includes a virtual execution system called the common language
runtime (CLR) and a unified set of class libraries. The CLR is the 
commercial implementation by Microsoft of the common language
infrastructure (CLI), an international standard that is the basis
for creating execution and development environments in which
languages and libraries work together seamlessly.

In addition to the run time services, the .NET Framework also includes an
extensive library of over 4000 classes organized into namespaces that 
provide a wide variety of useful functionality for everything from file 
input and output to string manipulation to XML parsing, to Windows Forms
controls. The typical C# application uses the .NET Framework class library 
extensively to handle common ""plumbing"" chores.";


        PrintText("C#", cSharp);
        PrintText(".NET Framework", dotNetFramework);
        Console.ReadKey();
    }

    static void PrintText(string title, string bodyText)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(title+ ": ");

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(bodyText);
        Console.WriteLine();
        Console.ResetColor();
    }
}