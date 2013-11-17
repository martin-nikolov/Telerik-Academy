/*
 08. Write a program that converts a number in the range [0...999]
 to a text corresponding to its English pronunciation. 
 
 Examples:
 0 -> "Zero"
 273 -> "Two hundred seventy three"
 400 -> "Four hundred"
 501 -> "Five hundred AND one"
 711 -> "Seven hundred AND eleven"
*/

/*
* 11. * Write a program that converts a number in the range [0...999]
* to a text corresponding to its English pronunciation. 
* 
* Examples:
* 0 -> "Zero"
* 273 -> "Two hundred seventy three"
* 400 -> "Four hundred"
* 501 -> "Five hundred AND one"
* 711 -> "Seven hundred AND eleven"
*/

Units = 
[ "", "ZERO", "ONE", "TWO", "THREE", "FOUR", "FIVE", "SIX", "SEVEN", "EIGHT", "NINE" ];

Decimals = 
[ "", "TEN", "ELEVEN", "TWELVE", "THIRDTEEN", "FOURTHEN", "FIFTHEEN", "SIXTHEEN", "SEVENTHEEN", "EIGHTHEEN", "NINETHEEN" ];

Hundreds =
[ "", "ONE", "TWENTY", "THIRTY", "FORTY", "FIFTY", "SIXTY", "SEVENTY", "EIGHTY", "NINETY" ];

function GetNumberName (number)
{
    number = parseInt(number);

    if (Number.isNaN(number) || number < 0 || number > 999) {

        return "Invalid Number! The number is out of range [0;999]...";
    }

    console.log(number + " -> " + GetHundreds(number) + "" + GetDecimals(number) + "" + GetUnits(number) + "\n");
}

function GetHundreds(number)
{
    if (number >= 100) {

        return Units[Math.floor(number / 100) + 1] + " HUNDRED";
    }

    return "";
}

function GetDecimals(number) {

    if (number > 9 && number < 20) {

        return Decimals[Math.floor(number % 10 + 1)];
    }
    else if (number % 100 >= 10 && number % 100 <= 19) {

        if (number / 100 > 0) { 

            return " AND " + Decimals[Math.floor(Math.abs(10 - number % 100) + 1)];
        }
        else {

            return Decimals[Math.floor(number / 10 % 10)];
        }
    }
    else if (number > 100 && number % 100 != 0 && number / 10 % 10 != 0) {

        return " AND " + Hundreds[Math.floor(number / 10 % 10)];
    }
    else {

        return Hundreds[Math.floor(number / 10 % 10)];
    }
}

function GetUnits(number)
{
    if (number < 10) {

        return Units[Math.floor(number % 10 + 1)];
    }
    else if (number / 10 % 10 >= 2 && number <= 100 && number % 10 != 0) { 

        return " " + Units[Math.floor(number % 10 + 1)];
    }
    else if (number > 100 && number / 10 % 10 >= 2 && number % 10 != 0) {

        return " " + Units[Math.floor(number % 10 + 1)];
    }
    else if (number > 100 && number % 100 < 10 && number % 10 != 0) {

        return " AND " + Units[Math.floor(number % 10 + 1)];
    }

    return "";
}

function GetRandomInt(min, max) {

  return Math.floor(Math.random() * (max - min + 1) + min);
}

(function Solve () {

	for (var i = 0; i < 10; i++) {

	    GetNumberName(GetRandomInt(1, 999));
	};
    
}).call(this);