function IsNumber(n) {
	return !isNaN(parseFloat(n)) && isFinite(n);
}

function InsideCircle (point) {

	if(!IsNumber(point.x) || !IsNumber(point.y))
		return;

	var circleX = 1, circleY = 1, circleRadius = 3;
	var newPoint = { x: 0, y: 0 }; // Saving the original coordinates

    newPoint.x = point.x - circleX;
    newPoint.y = point.y - circleY;

    if (newPoint.x * newPoint.x + newPoint.y * newPoint.y <= circleRadius * circleRadius)
    {
        return true;
    }
    else
    {
        return false;
    }
}

function OutsideOfRectangle (point) {

	if(!IsNumber(point.x) || !IsNumber(point.y))
		return;

	var rxLeft = -1, ryTop = 1, rxRight = 5, ryBottom = -1;

    if ((point.x >= rxLeft && point.x <= rxRight) && (point.y >= ryBottom && point.y <= ryTop))
    {
        return false;
    }
    else
    {
        return true;
    }
}

function Result (point) {
	
	if(!IsNumber(point.x) || !IsNumber(point.y))
		return;

	if (InsideCircle(point) && !OutsideOfRectangle(point))
	{
	    console.log("Point(%d, %d) is inside a circle and inside a rectangle", point.x, point.y);
	}
	else if (!InsideCircle(point) && OutsideOfRectangle(point))
	{
	    console.log("Point(%d, %d) is out of circle and out of rectangle", point.x, point.y);
	}
	else if (InsideCircle(point) && OutsideOfRectangle(point))
	{
	    console.log("Point(%d, %d) is inside a circle and out of rectangle", point.x, point.y);
	}
	else if (!InsideCircle(point) && !OutsideOfRectangle(point))
	{
	    console.log("Point(%d, %d) is out of circle and inside a rectangle", point.x, point.y);
	}
}

(function Solve () {
	
	var point = { x: 2, y: 3 };
	Result(point);

}).call(this);