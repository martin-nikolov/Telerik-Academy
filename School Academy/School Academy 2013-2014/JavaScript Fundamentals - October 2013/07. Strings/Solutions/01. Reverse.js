/*
 01. Write a JavaScript function reverses string
 and returns it.
 Example: "sample" -> "elpmas".
*/

function Reverse(str) {

    return str.split('').reverse().join('');
}

(function Solve () {
    
	console.log(Reverse('sample'));
    
}).call(this);