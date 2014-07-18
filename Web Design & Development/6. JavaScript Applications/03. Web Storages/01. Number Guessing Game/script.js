taskName = "1. Number Guessing Game";

function Main(bufferElement) {
    var guessingGame = new GuessingGame();
    guessingGame.start();

    var inputNumber = ReadLine("Enter a 4-digit number: ", "", "number-input");

    SetSolveButton(function() {
        ConsoleClear();
        try {
            var result = guessingGame.isNumberGuessed(inputNumber.value);
            printResult(result);
        }
        catch (ex) {
            WriteLine(" - Error: " + ex.message);
        }
    }, "Guess a number!");
}

function printResult(result) {
    if (result.isNumberGuessed) {
        ConsoleClear();
        WriteLine("You guessed the number!");
        WriteLine();

        disableInputs();
        registerPlayerInScoreboard();
        showScoreboardButton();
    }
    else {
        WriteLine("Sheep(s): " + result.sheepCount);
        WriteLine("Ram(s): " + result.ramCount);
    }
}

function disableInputs() {
    var guessNumberButton = document.getElementById('btn');
    guessNumberButton.disabled = true;

    var numberInput = document.getElementById('number-input');
    numberInput.disabled = true;
}

function registerPlayerInScoreboard() {
    var playerName = ReadLine("Please enter your nickname: ");
    var isPlayerAlreadyAdded = false;
    SetSolveButton(function() {
        if (playerName.value && !isPlayerAlreadyAdded) {
            ScoreBoard.addPlayerToRank(playerName.value);
            isPlayerAlreadyAdded = true;
        }
    }, "Confirm");
}

function showScoreboardButton() {
    SetSolveButton(function() {
        ScoreBoard.showTop10();
    }, "See ranklist");
}