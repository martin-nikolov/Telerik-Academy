/*
    5. Write a function that counts how many times given 
    number appears in given array. Write a test function
    to check if the function is working correctly.
*/

taskName = "5. Frequents of number in array";

function Main(bufferElement) {

    var elements = ReadLine("Enter elements: ", "0, 1, 2, 2, 3, 3, 3, 4, 4, 4, 4");
    var number = ReadLine("Enter a number: ", 2);

    SetSolveButton(function() {
        ConsoleClear();

        var elementsArray = ParseIntCollection(elements.value, [',', ' ']);
        var searchedNumber = parseInt(number.value);

        WriteLine(Format("Number '{0}' occurs {1} time(s) in the array.",
            searchedNumber, getFrequentsOfNumber(elementsArray, searchedNumber)));

        testFunction();
    });
}

function getFrequentsOfNumber(collection, number) {
    var searchedNumber = parseInt(number);

    if (!Array.isArray(collection) || (!searchedNumber && number !== 0)) {
        throw new Error("Error! There is some invalid input value");
    }

    var count = 0;

    for (number in collection) {
        if (collection[number] === searchedNumber) {
            count++;
        }
    }

    return count;
}

function testFunction() {
    var elements = [1, 2, 2, 3, 2, 2];
    var searchedNumber = 2;

    var expected = 4;
    var actual = getFrequentsOfNumber(elements, 2);

    WriteLine("<br>Test 1 passed: " + (actual == expected ? "TRUE" : "FALSE"));

    /* --------------- */

    elements = [1, 1, 1];
    searchedNumber = 1;

    expected = 3;
    actual = getFrequentsOfNumber(elements, 1);

    WriteLine("Test 2 passed: " + (actual == expected ? "TRUE" : "FALSE"));

    /* --------------- */

    elements = [1, 2, 3, 4];
    searchedNumber = 5;

    expected = 0;
    actual = getFrequentsOfNumber(elements, 5);

    WriteLine("Test 3 passed: " + (actual == expected ? "TRUE" : "FALSE"));
}