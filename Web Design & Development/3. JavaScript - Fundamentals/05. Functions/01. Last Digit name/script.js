/*
    1. Write a function that returns the last digit of 
    given integer as an English word. 
    Examples: 512 -> "two", 1024 -> "four", 12309 -> "nine"
*/

taskName = "1. Last digit name";

function Main(bufferElement) {

    var number = ReadLine("Enter a integer: ", GetRandomInt(1000));

    SetSolveButton(function() {
        ConsoleClear();

        WriteLine(getResult(number.value));
    });
}

function getResult(number) {
     var integer = parseInt(number);

    if (!IsNumber(integer)) {
        return "Error! There is some incorrect input value!";
    }
    
    return integer + " -> " + getLastDigitName(integer % 10);
}

function getLastDigitName(number) {    
    switch (number) {
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