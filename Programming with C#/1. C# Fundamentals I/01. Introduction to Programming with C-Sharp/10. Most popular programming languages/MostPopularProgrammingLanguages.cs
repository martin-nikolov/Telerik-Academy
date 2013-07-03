// 10. Provide a short list with information about the most popular 
// programming languages. How do they differ from C#?

using System;

class MostPopularProgrammingLanguages
{
    static void Main(string[] args)
    {
        Console.Title = "Information about the most popular programming languages";
        Console.SetWindowSize(80, 40);
        Console.SetBufferSize(80, 44);

        string cSharp =
            @"It is a compiled, multi-paradigm and object-oriented language 
written by Microsoft. It is an open specifications, but rarely seen
on any non-Windows platform. It is very similar to Java in both
syntax and nature.";
        string cSharpAdditional =
            @"Strengths: Powerful and pretty fast
Weaknesses: Only really suitable for Windows";

        string cPlusPlus =
            @"It is a compiled, multi-paradigm and object-oriented language
written as an update to C in 1979. Despite it's age, C++ is used to
create a wide array of applications from games to office suites.";
        string cPlusPlusAdditional =
            @"Strengths: Speed
Weaknesses: Older & considered clumsy if compared with Java";

        string visualBasic =
            @"Interpreted, multi-paradigm language developed by
Microsoft Corporation for the Windows Platform. VB is a good language
for scripting Windows applications that do not need the power and
the speed of C#.";
        string visualVasisAdditional =
            @"Strengths: None
Weaknesses: Only runs in Windows";

        string java =
            @"It uses a compiler, and is an object-oriented language released in
1995 by Sun Microsystems. Java is the number one programming
language today for many reasons.";
        string javaAdditional =
            @"Strengths: WORA (Write once, run anywhere), popularity
Weaknesses: Slower than natively compiled languages";

        string javaScript =
            @"Interpreded, multi-paradigm, and is a prototype-based
scripting language that is dynamic, weakly typed, and has first-class
functions. Its syntax was influenced by the language C.";
        string javaScriptAdditional =
            @"Strengths: Only reliable way to do client-side web programming
Weaknesses: Only really useful in a web browser";

        string php =
            @"It uses a run-time interpreter, and is a multi-paradigm language
originally developed in 1996 by Rasmus Lerdorf to create dynamic
web pages.";
        string phpAdditional =
            @"Strengths: Web programming, good documentation
Weaknesses: Inconsistent syntax, too many ways to do the same 
things,a history of bizarre security decisions";

        PrintText("C#", cSharp, cSharpAdditional);
        PrintText("C++", cPlusPlus, cPlusPlusAdditional);
        PrintText("Visual Basic", visualBasic, visualVasisAdditional);
        PrintText("Java", java, javaAdditional);
        PrintText("JavaScript", javaScript, javaScriptAdditional);
        PrintText("PHP", php, phpAdditional);
        Console.ReadKey();
    }

    static void PrintText(string title, string bodyText, string additionalText)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write(title + ": ");

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(bodyText);
        Console.BackgroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine(additionalText);
        Console.WriteLine();
        Console.ResetColor();
    }
}