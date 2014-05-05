/*
    1. Write a JavaScript function reverses string
    and returns it.
    Example: "sample" -> "elpmas".
*/

taskName = "1. Reverse a string";

function Main(bufferElement) {

    var inputText = ReadLine("Enter a string: ", "sample");

    SetSolveButton(function() {
        ConsoleClear();

        var reversedText = inputText.value.split("").reverse().join("");
        WriteLine("Reversed: " + reversedText);
    });
}