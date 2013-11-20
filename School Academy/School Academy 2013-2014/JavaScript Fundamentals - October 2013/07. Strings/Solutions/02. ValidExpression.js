/*
02. Write a JavaScript function to check
if in a given expression the brackets are put correctly.
Example of correct expression: ((a+b)/5-d).
Example of incorrect expression: )(a+b)).
*/

function IsValidExpression(exp)
{
    var bracketCount = 0;

    for (i = 0; i < exp.length; i++)
    {
        if (exp[i] == '(') bracketCount++;
        else if (exp[i] == ')') bracketCount--;

        if (bracketCount < 0) return false;
    }

    if (bracketCount != 0) return false;

    return true;
}

(function Solve () {
    
    console.log(IsValidExpression("((a+b)/5-d)"));
    console.log(IsValidExpression(")(a+b))"));
    
}).call(this);

