/*
    3. Create a module to work with the console object.
       Implement functionality for:

        - Writing a line to the console 
        - Writing a line to the console using a format
        - Writing to the console should call toString() to each element
        - Writing errors and warnings to the console with and without format
*/

taskName = "3. Console Module";

function Main(bufferElement) {
    var specialConsole = new ConsoleModule(bufferElement);
    specialConsole.writeLine("Message: hello");
    specialConsole.writeLine("Message: {0}", "hello");
    specialConsole.writeError("Error: {0}", "Something happened");
    specialConsole.writeWarning("Warning: {0}", "A warning");
}