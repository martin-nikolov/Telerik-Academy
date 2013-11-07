function GetThirdBit (number) {
	
	var integer = parseInt(number);
	var thirdBit = (integer >> 2) & 1;

	console.log("Third bit of number %d is: %d", number, thirdBit);
}



(function Solve () {
	
	GetThirdBit(2); // 10

	GetThirdBit(4); // 100

	GetThirdBit(7); // 111

	GetThirdBit(16); // 10000
	
}).call(this);