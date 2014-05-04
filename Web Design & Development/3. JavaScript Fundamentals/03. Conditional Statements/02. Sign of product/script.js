/*
	2. Write a script that shows the sign (+ or -) of the
	product of three real numbers without calculating it.
	Use a sequence of if statements.
*/

taskName = "2. Sign of Product of 3 Numbers";

function Main(bufferElement) {

	var a = ReadLine("Enter a: ", GetRandomInt(-25, 100));
	var b = ReadLine("Enter b: ", GetRandomInt(-25, 100));
	var c = ReadLine("Enter c: ", GetRandomInt(-25, 100));

	SetSolveButton(function() {
		ConsoleClear();
		
		WriteLine(signOfProduct(a.value, b.value, c.value));
	});
}

function signOfProduct(a, b, c) {
	a = parseFloat(a);
	b = parseFloat(b);
	c = parseFloat(c);

	if (!IsNumber(a) || !IsNumber(b) || !IsNumber(c)) {
		return "Error! There is some incorrect input value!";
	}

	var isPositive = true;

	if (a < 0) {
		isPositive = !isPositive;
	}

	if (b < 0) {
		isPositive = !isPositive;
	}

	if (c < 0) {
		isPositive = !isPositive;
	}

	return Format('The sign of the product is: {0}', isPositive ? '(+)' : '(-)');
}