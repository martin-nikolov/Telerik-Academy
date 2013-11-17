/*
 06. Write a script that enters the coefficients a, b and c 
 of a quadratic equation a*x2 + b*x + c = 0
 and calculates and prints its real roots. 
 Note that quadratic equations may have 0, 1 or 2 real roots.
*/

function FindRootsOfQuadraticEquation (a, b, c) {

    a = parseFloat(a);
    b = parseFloat(b);
    c = parseFloat(c);

    if (Number.isNaN(a) || Number.isNaN(b) || Number.isNaN(c)) {
        return "Error! There is some incorrect input value!";
    }

    console.log("Quadratic equation -> %d*x^2 + %d*x + %d = 0", a, b, c);

    if (a == 0)
    {
        console.log("\nx = %d\n", -c / b);
    }
    else
    {
        var discriminant = (b * b) - (4 * a * c);
        console.log("D = %d", discriminant);

        if (discriminant == 0)
        {
            console.log("x[1] = x[2] = %d\n", -b / (2 * a));
        }
        else if (discriminant < 0)
        {
            console.log("No real roots!\n");
        }
        else if (discriminant > 0)
        {
            console.log("x[1] = %d", (-b + Math.sqrt(discriminant)) / (2 * a));
            console.log("x[2] = %d\n", (-b - Math.sqrt(discriminant)) / (2 * a));
        }
    }
}

(function Solve () {
    
    FindRootsOfQuadraticEquation(2, 5, 2); // D > 0

    FindRootsOfQuadraticEquation(2, 5, 20); // D < 0

    FindRootsOfQuadraticEquation(1, 2, 1); // D == 0
    
}).call(this);