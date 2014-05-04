/*
    4. Write an expression that checks for given 
    integer if its third digit (right-to-left) is 7. 
    E. g. 1732 -> true.
*/

taskName = "4. Is third digit 7";

function Main(bufferElement) {

    var number = ReadLine("Enter a number: ", "1732");

    SetSolveButton(function() {
        ConsoleClear();

        WriteLine(Format("Third digit of number {0} is 7: {1}",
            number.value, isThirdDigit7(number.value) ? "YES" : "NO"));
    });
}

function isThirdDigit7(number) {
    number = parseInt(number);

    var thirdDigit = ((number / 100) | 0) % 10;

    return thirdDigit == 7;
}