/* 
    Task: C# Brackets
    http://bgcoder.com/Contests/54/CSharp-Part-2-2012-2013-5-Feb-2013
*/

var args = [
    '3',
    '>>',
    '{a{',
    '}  ',
    '}'
];

var args2 = [
    '5',
    '....',
    'using System;    namespace Stars',
    '{class Program{',
    'static    string[] separators ',
    '= new string[] { " " };}',
    '}'
];

console.log(Solve(args));

function Solve(args) {
    args.shift(); // length
    var indentSymbols = args.shift();

    var _formatted = [];
    var index = 0;
    var repeatIndentCount = 0;

    function addFormattedLine(text, repeat) {
        var trimmedText = text.trim();
        var tabulation = new Array(repeat).join(indentSymbols);

        if (!trimmedText) return;

        _formatted[index++] = [tabulation + trimmedText];
    }

    for (var line in args) {
        var currentLine = args[line].replace(/\s+/g, ' ');

        for (var i = 0; i < currentLine.length; i++) {
            var currentSymbol = currentLine[i];

            if (currentSymbol === '{') {
                addFormattedLine(currentSymbol, ++repeatIndentCount);
            }
            else if (currentSymbol === '}') {
                addFormattedLine(currentSymbol, repeatIndentCount--);
            }
            else {
                var textBetweenBrackets = "";

                while (i < currentLine.length && currentLine[i] != '{' && currentLine[i] != '}') {
                    textBetweenBrackets += currentLine[i++];
                }
                i--;

                addFormattedLine(textBetweenBrackets, repeatIndentCount + 1);
            }
        }
    }

    return _formatted.join('\n');
}