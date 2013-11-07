function IsInCircle (x, y) {
	
	var circleRadius = 5;

	if (x * x + y * y <= circleRadius * circleRadius)
	{
		console.log("Point(%d, %d) is in circle K(0, %d).", x, y, circleRadius);
	}
	else
	{
		console.log("Point(%d, %d) is NOT in circle K(0, %d).", x, y, circleRadius);
	}
}

(function Solve () {
	
	IsInCircle(1, 1);

	IsInCircle(5, 0);

	IsInCircle(0, 5);

	IsInCircle(5, 5); // false

	IsInCircle(4, 3);
	
}).call(this);