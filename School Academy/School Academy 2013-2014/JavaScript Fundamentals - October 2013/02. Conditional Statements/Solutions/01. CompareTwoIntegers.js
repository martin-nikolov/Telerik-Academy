/*
 01. Write an if statement that examines two integer
 variables and exchanges their values if the first 
 one is greater than the second one.
*/

function CompareTwoIntegers (firstNumber, secondNumber) {
	
	var numbers = new Array(2);
	numbers[0] = parseFloat(firstNumber);
	numbers[1] = parseFloat(secondNumber);

	if (numbers[0] != Number.NaN && numbers[1] != Number.Nan) {
		if (numbers[0] > numbers[1]){
			SwapValues(numbers);
		}
	}

	PrintIntegers(numbers);
}

function SwapValues (numbers) {
	
	var swap = numbers[0];
	numbers[0] = numbers[1];
	numbers[1] = swap;
}

function PrintIntegers(numbers) {
	console.log("First number: %d | Second number: %d", numbers[0], numbers[1]);
}

(function Solve () {
	
	CompareTwoIntegers(1, 2); // not swaped

	CompareTwoIntegers(-1, -2); // swaped

	CompareTwoIntegers(1.23, 2.23); // not swaped

	CompareTwoIntegers(5.23, 2.23); // swaped
	
}).call(this);