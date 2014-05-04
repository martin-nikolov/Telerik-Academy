/*
    6. Write an expression that checks if given
    print (x,  y) is within a circle K(O, 5).
*/

taskName = "6. Point inside Circle";

function Main(bufferElement) {

    var xCoords = ReadLine("Enter x: ", GetRandomFloat(0, 10));
    var yCoords = ReadLine("Enter y: ", GetRandomFloat(0, 10));
    var circleRadius = 5;

    SetSolveButton(function() {
        ConsoleClear();
        isPointInsideCircle(xCoords.value, yCoords.value, circleRadius);
    });
}

function isPointInsideCircle(xCoords, yCoords, circleRadius) {
    xCoords = parseFloat(xCoords);
    yCoords = parseFloat(yCoords);

    if (!IsNumber(xCoords) || !IsNumber(yCoords)) {
        WriteLine("Error! There is some incorrect input value!");
        return;
    }

    if (xCoords * xCoords + yCoords * yCoords <= circleRadius * circleRadius) {
        WriteLine(Format("Point({0}, {1}) is INSIDE a circle K(O, {2}).", xCoords, yCoords, circleRadius));
    } 
    else {
        WriteLine(Format("Point({0}, {1}) is OUTSIDE a circle K(O, {2}).", xCoords, yCoords, circleRadius));
    }
}