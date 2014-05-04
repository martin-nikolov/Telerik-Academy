/*
    5. Write script that asks for a digit and depending on the 
    input shows the name of that digit (in English) using a switch statement.
*/

taskName = "5. Get digit name";

function Main(bufferElement) {

    for (var i = 0; i < 10; i++) {
        WriteLine(Format('{0} -> {1}', i, getDigitName(i)));
    }
}

function getDigitName(number) {
    var integer = parseInt(number);

    if (!IsNumber(integer)) {
        return "Error! There is some incorrect input value!";
    }

    switch (integer) {
        case 0: return "zero";
        case 1: return "one";
        case 2: return "two";
        case 3: return "three";
        case 4: return "four";
        case 5: return "five";
        case 6: return "six";
        case 7: return "seven";
        case 8: return "eight";
        case 9: return "nine";
    }
}