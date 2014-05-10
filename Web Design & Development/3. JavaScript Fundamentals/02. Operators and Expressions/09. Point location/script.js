/*
    9. Write an expression that checks for given point (x, y)
    if it is within the circle K( (1,1), 3) and out of the
    rectangle R(top=1, left=-1, width=6, height=2).
*/

taskName = "9. Point Location";

function Main(bufferElement) {

    var xCoords = ReadLine("x = ", GetRandomFloat(-2, 2, 3));
    var yCoords = ReadLine("y = ", GetRandomFloat(-2, 2, 3));

    SetSolveButton(function() {
        ConsoleClear();

        var point = {
            x: parseFloat(xCoords.value),
            y: parseFloat(yCoords.value)
        };

        checkWhereIsPoint(point);
    });
}

function checkWhereIsPoint(point) {
    if (!isNumber(point.x) || !isNumber(point.y)) {
        WriteLine("Error! There is some incorrect input value!");
        return;
    }

    var insideCircle = isInsideCircle(point);
    var insideOfRectangle = isInsideRectangle(point);

    WriteLine(Format("Point({0}, {1}) is {2}side a circle and {3}side a rectangle.",
        point.x, point.y, insideCircle ? "in" : "out", insideOfRectangle ? "in" : "out"));
}

function isNumber(n) {
    return !isNaN(parseFloat(n)) && isFinite(n);
}

function isInsideCircle(point) {
    var circleX = 1,
        circleY = 1,
        circleRadius = 3;

    var newPoint = {
        x: 0,
        y: 0
    }; // Keep the old coordinates

    newPoint.x = point.x - circleX;
    newPoint.y = point.y - circleY;

    return (newPoint.x * newPoint.x + newPoint.y * newPoint.y) <= circleRadius * circleRadius;
}

function isInsideRectangle(point) {
    var rxLeft = -1;
    var ryTop = 1;
    var rxRight = 5;
    var ryBottom = -1;

    return (point.x >= rxLeft && point.x <= rxRight) && (point.y >= ryBottom && point.y <= ryTop);
}