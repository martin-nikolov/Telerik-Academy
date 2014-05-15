/*
    Task: Basic Language
    http://bgcoder.com/Contests/8/Telerik-Academy-Exam-2-7-Feb-2012
*/

var args = [
    'PRINT(Black and yellow, ); ',
    'FOR(0,1)PRINT(black and yellow, );',
    'PRINT(black and yellow...);',
    'EXIT;'
];

var args2 = [
    'FOR   ( 1  ,   5   )    PRINT  (ha)   ;',
    'FOR(2)FOR(2,3)PRINT(xi);PRINT(i);EXIT;'
];

console.log(Solve(args));

function Solve(args) {
    var _commands = args.join("\n");
    var _resultAsString = "";

    function separateCommands(commandLine) {
        return commandLine.split(/\)\s*;/gi).filter(function (str) {
            return /\S/.test(str);
        });
    }

    function executeCommands(commandLines) {
        for (var i = 0; i < commandLines.length; i++) {
            var currentCommands = commandLines[i].split(')');
            var iterationsCount = 1;

            for (var j = 0; j < currentCommands.length; j++) {
                var firstOpenBracketIndex = currentCommands[j].indexOf('(');
                var funcName = currentCommands[j].substr(0, firstOpenBracketIndex).trim();
                var funcArgs = currentCommands[j].substr(firstOpenBracketIndex + 1);

                if (funcName == 'PRINT') {
                    if (funcArgs.length == 0) continue;

                    for (var k = 0; k < iterationsCount; k++) {
                        _resultAsString += funcArgs;
                    }
                }
                else if (funcName == 'FOR') {
                    var forArgs = funcArgs.split(',').map(function (a) {
                        return parseInt(a);
                    });

                    iterationsCount *= (forArgs.length == 1) ? forArgs[0] : forArgs[1] - forArgs[0] + 1;
                }
                else if (funcArgs.indexOf('EXIT') == 0 || funcName.indexOf('EXIT') == 0) {
                    return;
                }
            }
        }
    }

    var separatedCommands = separateCommands(_commands);
    executeCommands(separatedCommands);

    return _resultAsString;
}