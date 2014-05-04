/*
    1. Write a script that prints all the numbers from 1 to N
*/

taskName = "1. Numbers to N";

function Main(bufferElement) {

    var N = ReadLine("Enter N: ", GetRandomInt(20));

    SetSolveButton(function() {
        ConsoleClear();

        printNumbers(N.value);
    });
}

function printNumbers(count) {
    count = parseInt(count);

    for (var i = 1; i <= count; i++) {
        WriteLine(i);
    }
}