/*
    8. Write an expression that calculates trapezoid's
    area by given sides a and b and height h.
*/

taskName = "8. Calculate trapezoid area";

function Main(bufferElement) {

    var a = ReadLine("a = ", GetRandomFloat(0, 10, 3));
    var b = ReadLine("b = ", GetRandomFloat(0, 10, 3));
    var height = ReadLine("height = ", GetRandomFloat(0, 10, 3));

    SetSolveButton(function() {
        ConsoleClear();

        WriteLine(Format("Trapezoid area is: {0} units",
            calculateTrapezoidArea(a.value, b.value, height.value).toFixed(5)));
    });
}

function calculateTrapezoidArea(a, b, height) {
    a = parseFloat(a);
    b = parseFloat(b);
    height = parseFloat(height);

    return (a + b) / 2 * height;
}