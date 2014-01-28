taskName = "2. Comparing char arrays";

function Main(bufferElement) {

    var charsText1 = ReadLine('Enter chars: ', 'a, c, b');
    var charsText2 = ReadLine('Enter chars: ', 'a, b, c');

    SetSolveButton(function () {
        ConsoleClear();

        var firstArray = SplitBySeparator(charsText1.value, [',', ' ']);
        var secondArray = SplitBySeparator(charsText2.value, [',', ' ']);

        WriteLine(CompareTwoCharArrays(firstArray, secondArray));
    });
}

function CompareTwoCharArrays(firstArray, secondArray) {

    if (!Array.isArray(firstArray) || !Array.isArray(secondArray) ||
        firstArray.length == 0 || secondArray.length == 0) {
        return "Error! There is some incorrect input value!";
    }

    var smallerSize = Math.min(firstArray.length, secondArray.length);

    for (i = 0; i < smallerSize; i++) {
        if (firstArray[i] < secondArray[i]) {
            return PrintResult(firstArray, secondArray, "<")
        }
        else if (firstArray[i] > secondArray[i]) {
            return PrintResult(firstArray, secondArray, ">")
        }
    }

    if (firstArray.length == secondArray.length) {
        return PrintResult(firstArray, secondArray, "==")
    }
    else {
        return PrintResult(firstArray, secondArray, firstArray.length > secondArray.length ? "<" : ">")
    }
}

function PrintResult(firstArray, secondArray, sign) {
    return Format("[{0}] {1} [{2}]", firstArray, sign, secondArray);
}