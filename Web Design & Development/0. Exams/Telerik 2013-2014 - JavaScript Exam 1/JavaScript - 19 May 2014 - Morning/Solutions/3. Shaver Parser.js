function Solve(args) {
    var paramLength = parseInt(args.shift());
    var htmlLines = parseInt(args[paramLength]);

    var funcNames = [ 'section', 'renderSection', 'if', 'foreach' ];

    var _params = [];
    var _sections = [];
    var _resultAsString = [];

    // Process variables
    for (var i = 0; i < paramLength; i++) {
        var currentLine = args.shift();
        var separatorIndex = currentLine.indexOf(":");

        // TODO: Trim ?
        var paramName = currentLine.substr(0, separatorIndex).trim();
        var paramArgs = currentLine.substr(separatorIndex + 1);

//        console.log(paramName);
//        console.log(paramArgs);
//        console.log();

        // TODO: Check for white-spaces
        if (paramArgs == 'true') {
            _params[paramName] = true;
        }
        else if (paramArgs == 'false') {
            _params[paramName] = false;
        }
        else if (paramArgs.indexOf(',') != -1) { // Array
            var values = paramArgs.split(',');
            _params[paramName] = values;
        }
        else { // String
            _params[paramName] = paramArgs;
        }
    }

    var isCommand = false;
    var isInCommand = false;
    var currentCommand = "";

    args.shift();
    var htmlAsText = args.join('\n');

    var currentResult = "";

    function getNumberOfSpaces(startIndex) {
        var count = 0;

        while (startIndex >= 0 && htmlAsText[startIndex] === ' ') {
            count++;
            startIndex--;
        }

        return count + 1;
    }

    // Process HTML
    for (var i = 0; i < htmlAsText.length; i++) {
        if (htmlAsText[i] == '@') {
            // Escape symbol
            if (htmlAsText[i + 1] == '@') {
                _resultAsString += '@';
                i++;
                continue;
            }

            // Check the name of the command
            for (var j = 0; j < funcNames.length + 1; j++) {
                var index = htmlAsText.indexOf(funcNames[j], i);

                if (j == funcNames.length) {
                    var varName = "";

                    while (htmlAsText[i] != '<' && htmlAsText[i] != '\n') {
                        varName += htmlAsText[i];
                        i++;
                    }

                    currentResult += _params[varName.substr(1).trim()];

                    break;
                }

                // Its function
                if (index == i + 1) {
                    if (funcNames[j] == 'renderSection') {
                        var numberOfSpaces = getNumberOfSpaces(index - 2);
                        var closedBracketIndex = htmlAsText.indexOf(')', index);
                        var sectionName = htmlAsText.substring(i + 16, closedBracketIndex - 1);

                        var lines = _sections[sectionName].split('\n');
                        for (var k = 1; k < lines.length; k++) {
                            lines[k] = new Array(numberOfSpaces).join(" ") + lines[k];
                        }

                        currentResult += lines.join('\n');
                        i = closedBracketIndex + 1;
                        break;
                    }
                    else if (funcNames[j] == 'section') {
                        var closedBracketIndex = htmlAsText.indexOf('}', index);

                        var sectionName = htmlAsText.substring(i + 9, htmlAsText.indexOf('{', index) - 1);
                        _sections[sectionName.trim()] = htmlAsText.substring(htmlAsText.indexOf('{', index) + 2,
                                closedBracketIndex - 1);

                        i = closedBracketIndex + 1;
                        break;
                    }
                    else if (funcNames[j] == 'if') {
                        var closedBracketIndex = htmlAsText.indexOf('}', index);

                        var ifCondition = htmlAsText.substring(i + 5, htmlAsText.indexOf(')', index));
                        var ifArgs = htmlAsText.substring(htmlAsText.indexOf('{', index) + 2, closedBracketIndex - 5);

//                        console.log(ifCondition);
//                        console.log(ifArgs);
//                        console.log("------------");

                        if (_params[ifCondition] == true) {
                            var indent = getNumberOfSpaces(index - 2);
                            var lines = ifArgs.split('\n').map(function (a) {
                                return a.trimLeft();
                            });

                            for (var k = 1; k < lines.length; k++) {
                                lines[k] = new Array(indent).join(" ") + lines[k];
                            }

//                            var numberOfSpaces = getNumberOfSpaces(index - 2);
                            currentResult += lines.join('\n')
                            i = closedBracketIndex + 1;
                        }
                        else {
                            i = closedBracketIndex + 2;
                        }

                        break;
                    }
                    else if (funcNames[j] == 'foreach ') {
//                        // proccess foreach
//                        console.log(funcNames[j]);
//                        console.log(htmlAsText.substring(i, htmlAsText.indexOf('}', index) + 1));
//                        console.log('-----------------------------------');
                        break;
                    }
                }
            }
        }

        currentResult += htmlAsText[i];
    }

    console.log(currentResult); // TODO Trim
}