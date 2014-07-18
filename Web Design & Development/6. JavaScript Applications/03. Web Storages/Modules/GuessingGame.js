var GuessingGame = (function() {
    'use strict';

    var NUMBER_OF_DIGITS = 4,
        POSSIBLE_DIGITS = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9];

    function GuessingGame() {}

    GuessingGame.prototype = {
        start: function() {
            this.secretNumber = _generateNumber();

            // For testing purpose
            console.log('You are trying to cheat!');
            console.log('Secret number is: ' + this.secretNumber);
        },
        isNumberGuessed: function(chosenNumber) {
            chosenNumber = chosenNumber | 0;

            if (this.secretNumber === undefined) {
                throw new Error("Game engine must be first started.");
            }

            _throwErrorIfNotValidNumber(chosenNumber);

            var sheepCount = _getNumberOfGuessedDigits.call(this, chosenNumber, true);
            var ramCount = _getNumberOfGuessedDigits.call(this, chosenNumber, false);

            return {
                sheepCount: sheepCount,
                ramCount: ramCount,
                isNumberGuessed: ramCount === NUMBER_OF_DIGITS
            }
        }
    };

    function _throwErrorIfNotValidNumber(chosenNumber) {
        var isNumberInRange = chosenNumber >= Math.pow(10, NUMBER_OF_DIGITS - 1) && chosenNumber < Math.pow(10, NUMBER_OF_DIGITS);
        if (!isNumberInRange) {
            throw new Error("Chosen number is not in valid range!")
        }

        var chosenNumberAsArray = chosenNumber.toString().split(""),
            digitCounter = [],
            uniqueDigitsCount = 0;

        for (var i = 0; i < chosenNumberAsArray.length; i++) {
            var digit = chosenNumberAsArray[i];
            if (!digitCounter[digit]) {
                uniqueDigitsCount++;
            }
            digitCounter[digit] = true;
        }

        if (uniqueDigitsCount !== NUMBER_OF_DIGITS) {
            throw new Error("Chosen number contains non-unique digits!")
        }
    }

    function _getNumberOfGuessedDigits(chosenNumber, isSheepChecker) {
        var guessedDigits = 0,
            chosenNumberAsArray = chosenNumber.toString().split(""),
            secretNumberAsArray = this.secretNumber.toString().split("");

        for (var i = 0; i < NUMBER_OF_DIGITS; i++) {
            var digit = secretNumberAsArray[i],
                indexOfDigit = chosenNumberAsArray.indexOf(digit),
                isDigitGuessed = isSheepChecker ? indexOfDigit !== i : indexOfDigit === i;

            if (indexOfDigit !== -1 && isDigitGuessed) {
                guessedDigits++;
            }
        }

        return guessedDigits;
    }

    function _generateNumber() {
        var randomIndex, randomDigit,
            possibleDigits = POSSIBLE_DIGITS.slice(0),
            numberAsArray = [];

        randomIndex = GetRandomInt(1, possibleDigits.length - 1);
        randomDigit = possibleDigits.splice(randomIndex, 1);
        numberAsArray.push(randomDigit);

        for (var i = 0; i < NUMBER_OF_DIGITS - 1; i++) {
            randomIndex = GetRandomInt(0, possibleDigits.length - 1);
            randomDigit = possibleDigits.splice(randomIndex, 1);
            numberAsArray.push(randomDigit);
        }

        var parsedNumber = numberAsArray.join("") | 0;
        return parsedNumber;
    }

    return GuessingGame;
}());