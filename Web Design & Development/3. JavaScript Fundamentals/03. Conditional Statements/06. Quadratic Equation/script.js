/*
    6. Write a script that enters the coefficients
    a, b and c of a quadratic equation:
        -> a*x2 + b*x + c = 0
    and calculates and prints its real roots. 
    Note that quadratic equations may have 0, 1 or 2 real roots.
*/

taskName = "6. Quadratic Equation";

function Main(bufferElement) {

    var a = ReadLine("Enter a: ", GetRandomInt(-15, 35));
    var b = ReadLine("Enter b: ", GetRandomInt(-10, 35));
    var c = ReadLine("Enter c: ", GetRandomInt(-20, 35));

    SetSolveButton(function() {
        ConsoleClear();

        findRootsOfQuadraticEquation(a.value, b.value, c.value);
    });
}

function findRootsOfQuadraticEquation(a, b, c) {
    a = parseFloat(a);
    b = parseFloat(b);
    c = parseFloat(c);

    if (!IsNumber(a) || !IsNumber(b) || !IsNumber(c)) {
        WriteLine("Error! There is some incorrect input value!");
        return;
    }

    WriteLine(Format("Quadratic equation -> {0}*x^2 + {1}*x + {2} = 0 <br>", a, b, c));

    if (a === 0) {
        WriteLine("x = " + (-c / b));
    }
    else {
        var discriminant = (b * b) - (4 * a * c);
        WriteLine("D = " + discriminant + '<br>');

        if (discriminant === 0) {
            WriteLine("x[1] = x[2] = " + (-b / (2 * a)));
        }
        else if (discriminant < 0) {
            WriteLine("No real roots!");
        }
        else if (discriminant > 0) {
            WriteLine("x[1] = " + (-b + Math.sqrt(discriminant)) / (2 * a));
            WriteLine("x[2] = " + (-b - Math.sqrt(discriminant)) / (2 * a));
        }
    }
}