/*
    1. Write an if statement that examines two integer variables
    and exchanges their values if the first one is greater than the second one.
*/

taskName = "1. Find Min/Max";

function Main(bufferElement) {

    var a = ReadLine("Enter a integer: ", GetRandomInt(-25, 100));
    var b = ReadLine("Enter a integer: ", GetRandomInt(-25, 100));

    SetSolveButton(function() {
        ConsoleClear();
        
        findMinMax(a.value, b.value);
    });
}

function findMinMax(a, b) {
    a = parseInt(a);
    b = parseInt(b);

    if (!IsNumber(a) || !IsNumber(b)) {
        WriteLine("Error! There is some incorrect input value!");
        return;
    }

    var min, max;

    min = a < b ? a : b;
    max = a > b ? a : b;

    WriteLine('Min: ' + min);
    WriteLine('Max: ' + max);
}