/*
	1. Write an expression that checks if given integer is odd or even.
*/

taskName = "1. Odd Or Even";

function Main(bufferElement) {

	var number = ReadLine("Enter a number: ", GetRandomInt(100));

	SetSolveButton(function () {
		ConsoleClear();
		CheckOddOrEven(number.value);
	});
}

function CheckOddOrEven(number) {
	number = parseInt(number);

	if (Number.isNaN(number)) {
		WriteLine("Error! Incorrect input value!");
		return;
	}

	WriteLine(Format("The number {0} is: {1}", number, (number % 2 != 0 ? "ODD" : "EVEN")));
}
