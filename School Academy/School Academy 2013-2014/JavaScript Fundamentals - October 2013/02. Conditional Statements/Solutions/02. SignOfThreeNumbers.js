/*
 02. Write a script that shows the sign (+ or -) of 
 the product of three real numbers without calculating
 it. Use a sequence of if statements.
*/

function GetSignOfProduct (numbers) {
	
	var minusCount = 0;

	for (var i = 0; i < numbers.length; i++) {
		if (!Number.isNaN(numbers[i]) && numbers[i] < 0) {
			minusCount++;
		}
	};

	if (minusCount % 2 == 0) {
		return "The product is positive number!"
	}
	else {
		return "The product is NEGATIVE number!"
	}
}

(function Solve () {
	
	console.log(GetSignOfProduct(new Array(1, 2, 3, 4)));

	console.log(GetSignOfProduct(new Array(-1, -2, -3, -4)));

	console.log(GetSignOfProduct(new Array(1.23, -2.23)));

	console.log(GetSignOfProduct(new Array(5.23, 2.23, -1)));
	
}).call(this);