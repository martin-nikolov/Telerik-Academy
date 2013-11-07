function IsPrime (number) {
	
	var num = parseInt(number);

	if (num < 0 || num > 100)
	{
		console.log("Number must be positive and less than 100!");
	}
	else
	{
		for (var i = 2; i <= Math.sqrt(num); i++) 
		{
			if ((num % i) == 0)
			{
				console.log("Number %d is NOT prime!", num);
				return;
			}
		}

		console.log("Number %d is prime!", num);
	}
}

(function Solve () {
	
	IsPrime(3);

	IsPrime(5);

	IsPrime(16);

	IsPrime(31);

	IsPrime(40);
	
}).call(this);