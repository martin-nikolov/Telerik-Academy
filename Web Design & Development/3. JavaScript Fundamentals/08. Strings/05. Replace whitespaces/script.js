/*
    5. Write a function that replaces non breaking 
    white-spaces in a text with &nbsp;
*/

taskName = "5. Replace white-spaces";

function Main(bufferElement) {

    var text = "This is   an example .";
    var newSubstring = "&nbsp;";

    var result = text.replace(/ /g, newSubstring);

    WriteLine(text);
    WriteLine();
    WriteLine(result);
}