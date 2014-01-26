/*
    3. Write a script that finds the max and min 
    number from a sequence of numbers.
*/

taskName = "3. Max and Min from sequence";

function Main(bufferElement) {

    var numbers = ReadLine("Enter a numbers: ", GetRandomNumbers(5));

    SetSolveButton(function () {
        ConsoleClear();
        var inputValues = ParseFloatCollection(numbers.value);
        GetMinMaxNumber(inputValues);
    });
}

function GetMinMaxNumber(numbers) {
    if (!(numbers instanceof Array)) {
        WriteLine("Error! Incorrect input format!");
        return;
    }

    var max = Math.max.apply(Math, numbers);
    var min = Math.min.apply(Math, numbers);

    WriteLine('Max: ' + max);
    WriteLine('Min: ' + min);
}

function GetRandomNumbers(count) {
    var numbers = new Array();

    for (var i = 0; i < count; i++) {
        numbers.push(GetRandomInt(-25, 25));
    };

    return numbers.join(', ');
}