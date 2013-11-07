function DivisibleBy35 (number) {
	return (number % 35) == 0 ? "true" : "false";
}

(function Solve () {
	
	console.log(DivisibleBy35(25));

	console.log(DivisibleBy35(35));

	console.log(DivisibleBy35(70));

	console.log(DivisibleBy35(125));
	
}).call(this);