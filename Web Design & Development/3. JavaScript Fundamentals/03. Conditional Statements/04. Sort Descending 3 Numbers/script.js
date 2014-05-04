/*
    4. Sort 3 real values in descending order using nested if statements.
*/

taskName = "4. Sort Descending 3 Numbers";

function Main(bufferElement) {

    var a = ReadLine("Enter a: ", GetRandomFloat(-15, 35, 1));
    var b = ReadLine("Enter b: ", GetRandomFloat(-20, 35, 1));
    var c = ReadLine("Enter c: ", GetRandomFloat(-10, 35, 1));

    SetSolveButton(function() {
        ConsoleClear();

        sortDescendingThreeRealValues(a.value, b.value, c.value);
    });
}

function sortDescendingThreeRealValues(a, b, c) {
    a = parseFloat(a);
    b = parseFloat(b);
    c = parseFloat(c);

    if (!IsNumber(a) || !IsNumber(b) || !IsNumber(c)) {
        WriteLine("Error! There is some incorrect input value!");
        return;
    }

    var swap = 0;

    if (a > b) {
        if (a > c) {
            swap = a;
            a = c;
            c = swap;
        }

        if (a > b) {
            swap = a;
            a = b;
            b = swap;
        }
    }
    else if (b > c) {
        if (a > c) {
            swap = a;
            a = c;
            c = swap;
        }

        if (b > c) { 
            swap = b;
            b = c;
            c = swap;
        }
    }

    var sortedNumbers = new Array(a, b, c);

    WriteLine('Sorted ascending: ' + sortedNumbers.join(", ") + '<br>');
    WriteLine('Sorted descending: ' + sortedNumbers.reverse().join(", "));
}