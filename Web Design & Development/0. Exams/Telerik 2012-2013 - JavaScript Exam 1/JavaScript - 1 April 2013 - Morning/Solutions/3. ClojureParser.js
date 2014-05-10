var args = [
    '(def func 10)',
    '(def newFunc (+  func 2))',
    '(def sumFunc (+ func func newFunc 0 0 0))',
    '(* sumFunc 2)'
];

var args2 = [
    '(def func (+ 5 2))',
    '(def func2 (/  func 5 2 1 0))',
    '(def func3 (/ func 2))',
    '(+ func3 func)'
];

console.log(Solve(args));

function Solve(args) {
    var _variables = [];
    var line = null;
    var openBracketIndex;
    var params;
    var paramsValue;

    // If arg is numbers => return it, otherwise arg is variable name => gets its value
    function tryParseNumber(arg) {
        var result = parseInt(arg);

        if (isNaN(result)) {
            result = parseInt(_variables[arg]);
        }

        return result;
    }

    function calculate(params) {
        var sign = params[0]; // +, -, /, *
        var result = 0;
        var number;

        if (params.length > 1) {
            result = tryParseNumber(params[1]);

            for (var i = 2; i < params.length; i++) {
                number = tryParseNumber(params[i]);

                if (sign === '+') {
                    result += number;
                }
                else if (sign === '-') {
                    result -= number;
                }
                else if (sign === '*') {
                    result *= number;
                }
                else if (sign === '/') {
                    if (number === 0) {
                        throw new Error();
                    }

                    result /= number;
                }
            }
        }

        return result | 0; // Return integer
    }

    for (var i = 0; i < args.length - 1; i++) {
        line = args[i].trim();
        line = line.replace(/\s+/g, ' '); // Remove unnecessary whitespaces
        line = line.substr(1, line.length - 2); // Get params between brackets ( ... )

        if (line.indexOf('def') === 0) {
            openBracketIndex = line.indexOf('(');

            if (openBracketIndex == -1) {
                // Example: 'def func 10' / 'def func func2'
                params = line.split(" ");
                _variables[params[1]] = tryParseNumber(params[2], _variables); // Assign: variable -> value
            }
            else {
                // Example: 'def sumFunc (+ 1 func 2)'
                params = line.substring(0, openBracketIndex - 1).trim().split(" "); // Gets and split: 'def sumFunc'
                paramsValue = line.substring(openBracketIndex + 1, line.length - 1).trim().split(" "); // Gets and split: '+ 1 func 2'

                try {
                    _variables[params[1]] = calculate(paramsValue, _variables); // Assign: variable -> value
                }
                catch (Exception) {
                    return 'Division by zero! At Line:' + (i + 1);
                }
            }
        }
    }

    // Processing last line
    line = args[args.length - 1].replace(/\s+/g, ' ').trim(); // Remove unnecessary whitespaces
    openBracketIndex = line.indexOf('(');
    params = line.substring(openBracketIndex + 1, line.length - 1).trim().split(" ");

    return calculate(params, _variables);
}