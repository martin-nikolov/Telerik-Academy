/*
    3. Write a function that finds all the occurrences of word in a text
    - The search can case sensitive or case insensitive
    - Use function overloading
*/

taskName = "3. All occurrences of word";

function Main(bufferElement) {

    var text = "Living, submarine, In, in, Inside, IN";
    var pattern = "in";

    WriteLine("Text: " + text);
    WriteLine(Format("Searched word: '{0}'", pattern));

    WriteLine();
    WriteLine("Searching a whole word: ")
    WriteLine("Case sensitive: " + allOccursLength(text, pattern, false, true));
    WriteLine("Case insensitive: " + allOccursLength(text, pattern, false, false));

    WriteLine();
    WriteLine("Searching a part of word: ")
    WriteLine("Case sensitive: " + allOccursLength(text, pattern, true, true));
    WriteLine("Case insensitive: " + allOccursLength(text, pattern, true, false));
}

function allOccursLength(str, pattern, isSubstring, isCaseSensitive) {
    var caseSensitive = isCaseSensitive ? "g" : "gi";
    var format = isSubstring ? "{0}" : "\\b{0}\\b";

    var regex = new RegExp(Format(format, pattern), caseSensitive);

    return str.match(regex).length;
}