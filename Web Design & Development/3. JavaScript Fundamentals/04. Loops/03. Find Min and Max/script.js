/*
    3. Write a script that finds the max and min 
    number from a sequence of numbers.
*/

taskName = "3. Max and Min from sequence";

function Main(bufferElement) {

    var numbers = ReadLine("Enter a numbers: ", getRandomNumbers(5));

    SetSolveButton(function() {
        ConsoleClear();

        var inputValues = ParseFloatCollection(numbers.value);
        getMinMaxNumber(inputValues);
    });
}

function getMinMaxNumber(numbers) {
    if (!(numbers instanceof Array)) {
        WriteLine("Error! Incorrect input format!");
        return;
    }

    var max = Math.max.apply(Math, numbers);
    var min = Math.min.apply(Math, numbers);

    WriteLine('Max: ' + max);
    WriteLine('Min: ' + min);
}

function getRandomNumbers(count) {
    var numbers = [];

    for (var i = 0; i < count; i++) {
        numbers.push(GetRandomInt(-25, 25));
    }

    return numbers.join(', ');
}