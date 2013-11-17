/*
 01. Write a script that prints all the numbers from 1 to N
*/

function PrintNumbersToN (n) {
	
	for (var i = 1; i <= n; i++) {
		console.log(i);
	};
}

(function Solve() {

	PrintNumbersToN(n = 20);

}).call(this);