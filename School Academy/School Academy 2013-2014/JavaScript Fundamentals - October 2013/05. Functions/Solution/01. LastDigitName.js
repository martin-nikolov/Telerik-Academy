/*
 01. Write a function that returns the last digit of
 given integer as an English word.
 Examples: 512 -> "two", 1024 -> "four", 12309 -> "nine"
*/

function GetLastDigitName (number) {
    
	var integer = parseInt(number);

    if (Number.isNaN(integer)) {
        return "Error! There is some incorrect input value!";
    }

    var lastDigit = integer % 10;

    switch (lastDigit)
    {
    	case 0: return "zero";
    	case 1: return "one";
    	case 2: return "two";
    	case 3: return "three";
    	case 4: return "four";
    	case 5: return "five";
    	case 6: return "six";
    	case 7: return "seven";
    	case 8: return "eight";
    	case 9: return "nine";
    }
}

function GetRandomInt(min, max) {

  return Math.floor(Math.random() * (max - min + 1) + min);
}

(function Solve () {
    
	for (var i = 0; i < 10; i++) {

        var randomNumber = GetRandomInt(100, 4444);
	    console.log(randomNumber + " - " + GetLastDigitName(randomNumber));
	};
    
}).call(this);