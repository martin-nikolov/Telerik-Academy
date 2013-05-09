.NET isn't just a library, but also a runtime for executing applications.
The knowledge of C# implies some knowledge of .NET (because the C# object model corresponds to the .NET object model and you can do anything interesting in C# just by using .NET libraries). The opposite isn't necessarily true as you can use other languages to write .NET applications.

The distinction between a language and runtime and library is more strict in .NET/C# than for example in C++, where the language specification also includes some basic library functions. The C# specification says only a very little about the environment (basically, that it should contain some types such as int, but that's more or less all).

C# is a programming language, .NET is a blanket term that tends to cover both the .NET Framework (an application framework library) and the Common Language Runtime which is the runtime in which .NET assemblies are run.

Microsoft's implementation of C# is heavily integrated with the .NET Framework so it is understandable that the two concepts would be confused. However it is important to understand that they are two very different things.