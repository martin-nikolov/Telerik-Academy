/*
    2. Write a function that reverses the digits
    of given decimal number. 
    Example: 256 -> 652
*/

taskName = "2. Reverse number";

function Main(bufferElement) {

    var number = ReadLine("Enter a integer: ", GetRandomInt(-1000, 1000));

    SetSolveButton(function() {
        ConsoleClear();

        WriteLine(reverseNumber(number.value));
    });
}

function reverseNumber(number) {
    var integer = parseInt(number);

    if (!IsNumber(integer)) {
        return "Error! There is some incorrect input value!";
    }

    var isNegative = integer < 0;

    if (isNegative) {
        integer *= -1;
    }

    var reversedNumber = integer.toString().split("").reverse().join("");
    reversedNumber = parseInt(reversedNumber);

    if (isNegative) {
        reversedNumber *= -1;
        integer *= -1;
    }

    return integer + " -> " + reversedNumber;
}