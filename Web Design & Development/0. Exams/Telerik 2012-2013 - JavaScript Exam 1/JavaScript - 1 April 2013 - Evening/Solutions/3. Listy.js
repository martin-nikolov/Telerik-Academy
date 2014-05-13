var args = [
    'def func sum[5, 3, 7, 2, 6, 3]',
    'def func2 [5, 3, 7, 2, 6, 3]',
    'def func3 min[func2]',
    'def func4 max[5, 3, 7, 2, 6, 3]',
    'def func5 avg[5, 3, 7, 2, 6, 3]',
    'def func6 sum[func2, func3, func4 ]',
    'sum[func6, func4]'
];

var args2 = [
    'def func sum[1, 2, 3, -6]',
    'def newList [func, 10, 1]',
    'def newFunc sum[func, 100, newList]',
    '[newFunc]'
];

console.log(Solve(args));

function Solve(args) {
    var _variables = [];
    var line;
    var emptySpaceIndex;
    var openBracketIndex;
    var params;
    var paramsValue;

    function declareVariable(obj, args) {
        var variableName = obj[0];
        _variables[variableName] = [];

        for (var i = 0; i < args.length; i++) {
            var number = parseInt(args[i]);

            if (isNaN(number) || Array.isArray(_variables[args[i]])) {
                [].push.apply(_variables[variableName], _variables[args[i]]); // AddRange
            }
            else {
                _variables[variableName].push(number);
            }
        }

        if (obj.length > 1) {
            executeFunction(variableName, obj[1]);
        }
    }

    function executeFunction(varName, funcName) {
        function sum(arr) {
            var result = arr.reduce(function (a, b) {
                return a + b;
            });

            return result;
        }

        if (funcName === 'min') {
            _variables[varName] = [Math.min.apply(Math, _variables[varName])];
        }
        else if (funcName === 'max') {
            _variables[varName] = [Math.max.apply(Math, _variables[varName])];
        }
        else if (funcName == 'sum') {
            _variables[varName] = [sum(_variables[varName])];
        }
        else if (funcName == 'avg') {
            var length = _variables[varName].length;
            var avgResult = (sum(_variables[varName]) / length) | 0;

            _variables[varName] = [avgResult];
        }
    }

    for (var i = 0; i < args.length; i++) {
        line = args[i].trim();
        line = line.replace('[', ' ['); // def func2[5, 3, 7, 2, 6, 3] -> def func2 [5, 3, 7, 2, 6, 3]
        line = line.replace(/\s+/g, ' '); // Remove unnecessary whitespaces

        emptySpaceIndex = (i != args.length - 1) ? line.indexOf(' ') : -1;
        openBracketIndex = line.indexOf('[');

        params = line.substring(emptySpaceIndex + 1, openBracketIndex - 1).split(' ').map(function (a) {
            return a.trim();
        });

        paramsValue = line.substring(openBracketIndex + 1, line.length - 1).split(',').map(function (a) {
            return a.trim();
        });

        declareVariable(params, paramsValue);
    }

    // Process last line -> result
    declareVariable(['_result', params[0]], paramsValue);
    return _variables['_result'][0];
}