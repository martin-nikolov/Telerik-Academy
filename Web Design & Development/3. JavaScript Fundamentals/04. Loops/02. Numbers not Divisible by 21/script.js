/*
    2. Write a script that prints all the numbers from 1 to N,
    that are not divisible by 3 and 7 at the same time.
*/

taskName = "2. Numbers to N not divisible by 21";

function Main(bufferElement) {

    var N = ReadLine("Enter N: ", GetRandomInt(150));

    SetSolveButton(function() {
        ConsoleClear();
        
        printNumbersNotDivisibleBy21(N.value);
    });
}

function printNumbersNotDivisibleBy21(count) {
    count = parseInt(count);
    var found = false;

    for (var i = 1; i <= count; i++) {
        if (i % 21 === 0) {
            WriteLine(i);
            found = true;
        }
    }

    if (!found) {
        WriteLine("No numbers divisible by 21...");
    }
}