/*
 01. Write a script that allocates array of 20 integers
 and initializes each element by its index multiplied
 by 5. Print the obtained array on the console.
*/

function InitializeArray(length) {
	
	var numbers = new Array();

	for (var i = 0; i < length; i++) {
		numbers[i] = i + 1;
	};

	return numbers;
}

function PrintMultipliedNumbersBy5 (n) {
	
	var numbers = InitializeArray(n);

	for (var i = 0; i < n; i++) {
		numbers[i] *= 5;
	};

	console.log(numbers.join(", "));
}

(function Solve() {

	PrintMultipliedNumbersBy5(n = 20);

}).call(this);