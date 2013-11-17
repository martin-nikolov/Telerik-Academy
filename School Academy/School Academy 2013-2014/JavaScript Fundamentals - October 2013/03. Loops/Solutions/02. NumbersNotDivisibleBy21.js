/*
 02. Write a script that prints all the numbers from 1 to N, 
 that are not divisible by 3 and 7 at the same time
*/

function PrintNumbersNotDivisibleBy21 (count) {
	
	for (var i = 1; i <= count; i++) {
		
		if (i % 21 != 0) {
			console.log(i);
		}
	};
}

(function Solve() {

	PrintNumbersNotDivisibleBy21(n = 42); // skip 21 and 42

}).call(this);