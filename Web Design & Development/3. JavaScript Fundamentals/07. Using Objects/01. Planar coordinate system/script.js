/*
    1. Write functions for working with shapes in  standard Planar coordinate system
    Points are represented by coordinates P(X, Y)
    Lines are represented by two points, marking their beginning and ending
    L(P1(X1,Y1),P2(X2,Y2))
    - Calculate the distance between two points
    - Check if three segment lines can form a triangle
*/

taskName = "1. Planar coordinate system";

function Main(bufferElement) {

    var rangeFrom = -3;
    var rangeTo = 3;

    var pointA = ReadLine("A(x, y): ", 
                 GetRandomFloat(rangeFrom, rangeTo) + "; " + GetRandomFloat(rangeFrom, rangeTo));

    var pointB = ReadLine("B(x, y): ", 
                 GetRandomFloat(rangeFrom, rangeTo) + "; " + GetRandomFloat(rangeFrom, rangeTo));

    SetSolveButton(function () {
        ConsoleClear();

        // Test 1
        var coordsA = ParseFloatCollection(pointA.value);
        var coordsB = ParseFloatCollection(pointB.value);

        var A = Point(coordsA[0], coordsA[1]);
        var B = Point(coordsB[0], coordsB[1]);

        var line = Line(A, B);

        WriteLine(line.toString());
        WriteLine("Distance between 2 points: " + line.distance());

        WriteLine("<br>-------- Test - invalid triangle --------<br>");

        // Test 2
        try {
            var invalidTriangle = Triangle(Line(Point(0, 0), Point(5, 30)),
                                           Line(Point(0, 0), Point(10, 0)),
                                           Line(Point(10, 0), Point(5, 10)));

            WriteLine("Segment lines can form a triangle!"); // throws exception before print this
        }
        catch (e) {
            WriteLine("Error: " + e.message);
        }
    });
}

// POINT CONSTRUCTOR

function Point(x, y) {
    if (!IsNumber(x) || !IsNumber(y)) {
        throw new Error("Error! There is some incorrect input value!");
    }

    if (!(this instanceof Point)) {
        return new Point(x, y);
    }

    this.x = x;
    this.y = y;
}

// POINT PROTOTYPES

Point.prototype.toString = function() {
    return Format("Point({0}, {1})", this.x, this.y);
};

// LINE CONSTRUCTOR

function Line(startPoint, endPoint) {
    if (!(startPoint instanceof Point) || !(endPoint instanceof Point)) {
        throw new Error("Error! There is some incorrect input value!");
    }

    if (!(this instanceof Line)) {
        return new Line(startPoint, endPoint);
    }

    this.startPoint = startPoint;
    this.endPoint = endPoint;
}

// LINE PROTOTYPES

Line.prototype.distance = function() {
    var x = Math.pow(this.startPoint.x - this.endPoint.x, 2);
    var y = Math.pow(this.startPoint.y - this.endPoint.y, 2);

    return Math.sqrt(x + y);
};

Line.prototype.toString = function() {
    return Format("Line[{0}, {1}]", this.startPoint, this.endPoint);
};

// TRIANGLE CONSTRUCTOR

function Triangle(a, b, c) {
    if (!(this instanceof Triangle)) {
        return new Triangle(a, b, c);
    }

    if (!canFormTriangle(a, b, c)) {
        throw new Error("Segment lines cannot form a triangle!");
    }

    this.a = a;
    this.b = b;
    this.c = c;
}

// FUNCTIONS

function canFormTriangle(a, b, c) {
    return a.distance() < b.distance() + c.distance() &&
           b.distance() < a.distance() + c.distance() &&
           c.distance() < a.distance() + b.distance();
}