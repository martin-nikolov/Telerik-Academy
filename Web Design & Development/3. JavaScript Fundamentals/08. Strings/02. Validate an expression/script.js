/*
    2. Write a JavaScript function to check if in
    a given expression the brackets are put correctly.
    - Example of correct expression: ((a+b)/5-d).
    - Example of incorrect expression: )(a+b)).
*/

taskName = "2. Validate an expression";

function Main(bufferElement) {

    var input = ReadLine("Enter an expression: ", "((a+b)/5-d)");

    SetSolveButton(function() {
        ConsoleClear();

        var isValid = isValidExpression(input.value);

        WriteLine(Format("{0} is correct: {1}", input.value, isValid ? "TRUE" : "FALSE"));
    });
}

function isValidExpression(exp) {
    var bracketCount = 0;

    for (i = 0; i < exp.length; i++) {
        if (exp[i] == '(') {
            bracketCount++;
        }
        else if (exp[i] == ')') {
            bracketCount--;
        }

        if (bracketCount < 0) {
            return false;
        }
    }

    return bracketCount === 0;
}