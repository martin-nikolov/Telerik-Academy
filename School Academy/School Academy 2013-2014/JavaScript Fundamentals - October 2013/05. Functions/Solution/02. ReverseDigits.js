/*
 02. Write a function that reverses the digits
 of given decimal number. Example: 256 -> 652
*/

function ReverseDigits (number) {
    
    // Check that numbers is Integer
	var integer = parseInt(number);

    if (Number.isNaN(integer)) {
        return "Error! There is some incorrect input value!";
    }

    var numberToString = number.toString();
    var reversedNumber = "";

    for (var i = 0; i < numberToString.length; i++) {
        reversedNumber = numberToString[i] + reversedNumber;
    };

    return parseInt(reversedNumber);
}

function GetRandomInt(min, max) {

  return Math.floor(Math.random() * (max - min + 1) + min);
}

(function Solve () {
    
	for (var i = 0; i < 10; i++) {

        var randomNumber = GetRandomInt(100, 4444);
	    console.log(randomNumber + " - " + ReverseDigits(randomNumber));
	};
    
}).call(this);