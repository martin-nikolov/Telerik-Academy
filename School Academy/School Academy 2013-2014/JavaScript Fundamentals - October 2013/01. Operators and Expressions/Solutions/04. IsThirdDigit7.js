function IsThirdDigit7 (number) {
	return ((number / 100) | 0) % 10 == 7 ? "true" : "false";
}

(function Solve () {
	
	console.log(IsThirdDigit7(1732));

	console.log(IsThirdDigit7(2371));

	console.log(IsThirdDigit7(777));

}).call(this);