function IsEven (number) {
	return (number & 1) == 0 ? "true" : "false";
}

(function Solve () {
	
	console.log(IsEven(1));

	console.log(IsEven(2));

	console.log(IsEven(3));

	console.log(IsEven(4));
	
}).call(this);