/*
 11. Write a function that formats a string using placeholders:

 var str = stringFormat("Hello {0}!","Peter");
 //str = "Hello Peter!";

 The function should work with up to 30 placeholders and all types
 
 var format = "{0}, {1}, {0} text {2}";
 var str = stringFormat(format,1,"Pesho","Gosho");
 //str = "1, Pesho, 1 text Gosho"
*/

function Format(str) {

    var selfArguments = arguments;

    return str.replace(/\{(\d+)\}/g, function(match, p1) {

        return selfArguments[+p1 + 1];
    });
}

(function Solve () {
    
	console.log(Format('{0}, {1}!', 'Hello', 'World'))
    
}).call(this);