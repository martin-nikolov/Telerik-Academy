/*
 05. Write a function that replaces non breaking
 white-spaces in a text with &nbsp;
*/

function EscapeWhiteSpace(text) {

    return text.replace(/ /g, '&nbsp;')
}

(function Solve () {
    
	console.log(EscapeWhiteSpace('  hello    world '))
    
}).call(this);