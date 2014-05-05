/*
    3. Write a JavaScript function that finds how many times
    a substring is contained in a given text (perform case
    insensitive search).

    Example: The target substring is "in". The text is as follows:
    -> We are living in an yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.

    The result is: 9.
*/

taskName = "3. Occurs of substring";

function Main(bufferElement) {

    var text = "We are living in an yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";

    var searchedSubstring = "in";
    var occurs = allOccursLength(text, searchedSubstring, true, false);

    WriteLine(text);
    WriteLine();

    WriteLine("Target substring: " + searchedSubstring);
    WriteLine("Result: " + occurs);
}

function allOccursLength(str, pattern, isSubstring, isCaseSensitive) {
    var caseSensitive = isCaseSensitive ? "g" : "gi";
    var format = isSubstring ? "{0}" : "\\b{0}\\b";

    var regex = new RegExp(Format(format, pattern), caseSensitive);

    return str.match(regex).length;
}