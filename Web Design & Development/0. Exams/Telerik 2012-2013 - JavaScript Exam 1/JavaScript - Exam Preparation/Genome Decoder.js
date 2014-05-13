/*
    Task: Genome Decoder
    http://bgcoder.com/Contests/10/CSharp-Fundamentals-2011-2012-Part-2-Test-Exam
*/

var args = [
    '6 3',
    '10A15G3CA6T19C'
];

var args2 = [
    '9 4',
    '18A13C10T10GA18GT17C'
];

console.log(Solve(args));

function Solve(args) {
    var _result = [];
    var params = args[0].split(' ');
    var lettersOnLine = parseInt(params[0]);
    var lettersInGroup = parseInt(params[1]);
    var totalLetters = 0;

    var sequenceOfLetters = args[1];
    var keyValuePair = []; // A -> 5 time(s)

    // Separates letters
    for (var i = 0, count = 0; i < sequenceOfLetters.length; i++) {
        if (sequenceOfLetters[i].match(/[0-9]/gi)) {
            count = count * 10 + (parseInt(sequenceOfLetters[i]));
        }
        else if (sequenceOfLetters[i].match(/[A-Z]/g)) {
            if (count == 0) count = 1;

            keyValuePair.push({ letter: sequenceOfLetters[i], count: count });
            totalLetters += count;
            count = 0;
        }
    }

    var totalLines = Math.ceil(totalLetters / lettersOnLine);
    var indentSpaces = Math.floor(Math.log(totalLines) / Math.LN10);
    var tabulations = new Array(indentSpaces + 1).join(' ');
    var rowDividerBy10 = 10;
    var letterIndex = 0;

    // Generates lines
    while (totalLetters > 0) {
        var currentLine = "";

        // Concatenates letters
        for (var i = 1; i <= lettersOnLine && totalLetters > 0; i++, totalLetters--) {
            currentLine += keyValuePair[letterIndex].letter;
            keyValuePair[letterIndex].count--;

            if (i % lettersInGroup === 0 && i != lettersOnLine) currentLine += " ";

            if (keyValuePair[letterIndex].count <= 0) letterIndex++;
        }

        // Adds tabulations and number of row + result of concatenation above
        var numberOfRow = _result.length + 1;
        if (numberOfRow % rowDividerBy10 === 0) {
            indentSpaces--;
            rowDividerBy10 *= 10;
            tabulations = new Array(indentSpaces + 1).join(' ');
        }

        _result.push(tabulations + numberOfRow + " " + currentLine);
    }

    return _result.join('\n');
}