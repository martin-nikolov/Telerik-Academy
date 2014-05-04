/*
    5. Write a boolean expression for finding if the 
    bit 3 (counting from 0) of a given integer is 1 or 0.
*/

taskName = "5. Third bit of Integer";

function Main(bufferElement) {

    var integer = ReadLine("Enter a integer: ", GetRandomInt(256));

    SetSolveButton(function() {
        ConsoleClear();

        printResult(integer.value);
    });
}

function printResult(integer) {
    WriteLine(Format("{0} to binary -> {1}<br>", integer, convertToBinary(integer)));
    WriteLine(Format("Third bit of number {0} is: {1}", integer, getThirdBit(integer)));
}

function convertToBinary(integer) {
    return parseInt(integer).toString(2);
}

function getThirdBit(integer) {
    return (parseInt(integer) >> 3) & 1;
}