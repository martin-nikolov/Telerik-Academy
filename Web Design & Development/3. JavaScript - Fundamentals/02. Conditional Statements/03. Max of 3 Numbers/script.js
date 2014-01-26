/*
    3. Write a script that finds the biggest of
    three integers using nested if statements.
*/

taskName = "3. Biggest of 3 Numbers";

function Main(bufferElement) {

    var a = ReadLine("Enter a: ", GetRandomInt(-25, 100));
    var b = ReadLine("Enter b: ", GetRandomInt(-25, 100));
    var c = ReadLine("Enter c: ", GetRandomInt(-25, 100));

    SetSolveButton(function () {
        ConsoleClear();
        WriteLine(GetBiggestFromThreeNumbers(a.value, b.value, c.value));
    });
}

function GetBiggestFromThreeNumbers(a, b, c) {
    a = parseInt(a);
    b = parseInt(b);
    c = parseInt(c);

    if (Number.isNaN(a) || Number.isNaN(b) || Number.isNaN(c)) {
        return "Error! There is some incorrect input value!";
    }

    var biggest = 0;

    if (a > b) {
        if (b > c) {
            biggest = a;
        }
        else if (c > b) {      
            if (c > a) {             
                biggest = c;
            }
            else {              
                biggest = a;
            }
        }
    }
    else if (b > c) {
        biggest = b;
    }
    else {
        biggest = c;
    }

    return "Biggest number: " + biggest;
}