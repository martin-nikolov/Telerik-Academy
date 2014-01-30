/*
    5. Write a function that counts how many times given 
    number appears in given array. Write a test function
    to check if the function is working correctly.
*/

taskName = "5. Frequents of number in array";

function Main(bufferElement) {

    var elements = ReadLine("Enter elements: ", "0, 1, 2, 2, 3, 3, 3, 4, 4, 4, 4");
    var number = ReadLine("Enter a number: ", 2);

    SetSolveButton(function () {
        ConsoleClear();

        var elementsArray = ParseIntCollection(elements.value, [',', ' ']);
        var searchedNumber = parseInt(number.value);

        WriteLine(getFrequentsOfNumber(elementsArray, searchedNumber));
    });
}

function getFrequentsOfNumber(collection, number) {
    var searchedNumber = parseInt(number);

    if (!Array.isArray(collection) || (!searchedNumber && number !== 0)) {
        return "Error! There is some invalid input value";
    }

    var count = 0;

    for (number in collection) {
        if (collection[number] === searchedNumber) {
            count++;
        }
    }

    return Format("Number '{0}' occurs {1} time(s) in the array.", searchedNumber, count);
}

function testFunction() {

}
