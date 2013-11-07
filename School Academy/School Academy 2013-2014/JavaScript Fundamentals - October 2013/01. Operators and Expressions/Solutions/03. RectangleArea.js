function CalculateRectangleArea (width, height) {

	var w = parseFloat(width);
	var h = parseFloat(height);

	console.log("Area -> %dx%d = %d", w, h, w * h)
}

(function Solve () {
	
	CalculateRectangleArea(5, 10);

	CalculateRectangleArea(5.23, 10.01);
	
}).call(this);