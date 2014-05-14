/*
    Task: Console Justification
    http://bgcoder.com/Contests/52/CSharp-Part-2-2012-2013-4-Feb-2013-Morning
*/

var args = [
    '5',
    '20',
    'We happy few        we band',
    'of brothers for he who sheds',
    'his blood',
    'with',
    'me shall be my brother'
];

var args = [
    '10',
    '18',
    'Beer beer beer Im going for ',
    '   a',
    'beer',
    'Beer beer beer Im gonna',
    'drink some beer',
    'I love drinkiiiiiiiiing ',
    'beer',
    'lovely ',
    'lovely',
    'beer'
];

console.log(Solve(args));

function Solve(args) {
    var maxSymbolsOnLine = parseInt(args[1]);

    var _words = [];
    var _result = [];
    var currentLine = "";

    for (var i = 2; i < args.length; i++) {
        var wordsOnLine = args[i].match(/\w+/g);
        [].push.apply(_words, wordsOnLine); // AddRange
    }

    for (var i = 0; i < _words.length; i++) {
        if (currentLine.length + _words[i].length > maxSymbolsOnLine) {
            _result.push(justifyText(currentLine));
            currentLine = "";
            i--;
        }
        else if (currentLine.length + _words[i].length <= maxSymbolsOnLine) {
            currentLine += _words[i] + " ";
        }
    }

    // Adding last skipped line
    _result.push(justifyText(currentLine));

    function justifyText(text) {
        text = text.trimRight();

        if (text.length == maxSymbolsOnLine || text.indexOf(' ') === -1) {
            return text;
        }

        var spaceLength = 2;
        var currentStringLength = 0;

        function replacer(match) {
            if (match.length == spaceLength || currentStringLength + 1 > maxSymbolsOnLine) {
                return match;
            }

            currentStringLength++;
            return match + " ";
        }

        while (text.length < maxSymbolsOnLine) {
            currentStringLength = text.length;
            text = text.replace(/\s+/gi, replacer);
            spaceLength++;
        }

        return text;
    }

    return _result.join('\n');
}