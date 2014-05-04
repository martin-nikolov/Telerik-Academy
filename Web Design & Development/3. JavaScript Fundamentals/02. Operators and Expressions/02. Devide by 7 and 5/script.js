/*
    2. Write a boolean expression that checks for given 
    integer if it can be divided (without remainder) by
    7 and 5 in the same time.
*/

taskName = "2. Devide by 7 and 5";

function Main(bufferElement) {

    var number = ReadLine("Enter a number: ", GetRandomInt(100));

    SetSolveButton(function() {
        ConsoleClear();

        isDivisibleBy21(number.value);
    });
}

function isDivisibleBy21(number) {
    number = parseInt(number);

    if (!IsNumber(number)) {
        WriteLine("Error! Incorrect input value!");
        return;
    }

    WriteLine(Format("{0} is divisible by 7 and 5: {1}", number, number % 21 === 0 ? "TRUE" : "FALSE"));
}