/*
* 11. Create a [Version] attribute that can be applied to structures,
* classes, interfaces, enumerations and methods and holds a version
* in the format major.minor (e.g. 2.11). Apply the version attribute
* to a sample class and display its version at runtime.
*/

using System;
using Attribute;

[Version("1.0 (Beta)")]
class Program
{
    static void Main()
    {
        object[] attributes = typeof(Program).GetCustomAttributes(false);

        Console.WriteLine("Version: {0}", attributes[0]);
    }
}