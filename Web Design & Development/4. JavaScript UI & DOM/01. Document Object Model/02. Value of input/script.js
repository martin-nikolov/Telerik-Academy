/*
    2. Create a function that gets the value of 
    <input type="text"> ands prints its value to the console
*/

taskName = "2. Value of input";

function Main(bufferElement) {
    var input = ReadLine("Enter a message: "); // Create label + input

    SetSolveButton(function() {
        ConsoleClear();
        showInputContent(input);
    }, "Show input value");
}

function showInputContent(input) {
    WriteLine(input.value);
}