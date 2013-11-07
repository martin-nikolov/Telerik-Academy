function CalculateTrapezoidArea (a, b, h) {
	return (a + b) / 2 * h;
}



(function Solve () {
	
	console.log(CalculateTrapezoidArea(2, 4, 5));

	console.log(CalculateTrapezoidArea(1.32, 2.32, 5.32));
	
}).call(this);