/*
    11. Write a function that formats a string using placeholders:

    var str = stringFormat("Hello {0}!","Peter");
    //str = "Hello Peter!";

    The function should work with up to 30 placeholders and all types

    var format = "{0}, {1}, {0} text {2}";
    var str = stringFormat(format,1,"Pesho","Gosho");
    //str = "1, Pesho, 1 text Gosho"
*/

taskName = "11. Format string";

function Main(bufferElement) {

    var str1 = stringFormat("Hello {0}!", "Peter");

    WriteLine(str1);

    var format = "{0}, {1}, {0} text {2}";
    var str2 = stringFormat(format, 1, "Pesho", "Gosho");

    WriteLine(str2);
}

function stringFormat(str) {
    var selfArguments = arguments;

    return str.replace(/\{(\d+)\}/g, function(match, arg) {
        return selfArguments[+arg + 1];
    });
}