/*
    7. Write a script that finds the greatest of given 5 variables.
*/

taskName = "7. Max of given numbers";

function Main(bufferElement) {

    var numbers = ReadLine("Enter a numbers: ", getRandomNumbers(5));

    SetSolveButton(function() {
        ConsoleClear();

        var inputValues = ParseFloatCollection(numbers.value);
        WriteLine(getMaxNumber(inputValues));
    });
}

function getMaxNumber(numbers) {
    if (!(numbers instanceof Array)) {
        return "Error! Incorrect input format!";
    }

    var max = Math.max.apply(Math, numbers);
    
    return 'Max: ' + max;
}

function getRandomNumbers(count) {
    var numbers = [];

    for (var i = 0; i < count; i++) {
        numbers.push(GetRandomInt(-25, 25));
    }

    return numbers.join(', ');
}