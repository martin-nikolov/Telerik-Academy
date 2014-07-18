var ScoreBoard = (function() {
    function showTop10() {
        var top10Players = _getSortedTop10Players(),
            top10PlayersToString = [];

        for (var i = 1; i <= top10Players.length && i <= 10; i++) {
            top10PlayersToString.push(i + ". " + top10Players[i - 1][0] + " -> " + top10Players[i - 1][1]);
        }

        if (top10PlayersToString.length > 0) {
            alert(top10PlayersToString.join("\n"));
        }
        else {
            alert("No players!");
        }
    }

    function addPlayerToRank(playerNickname) {
        var guessedNumbersByPlayer = localStorage.getItem(playerNickname) | 0;
        localStorage.setItem(playerNickname, guessedNumbersByPlayer + 1);
    }

    function _getSortedTop10Players() {
        var top10 = [];
        for (var i in localStorage) {
            top10.push([i, localStorage.getItem(i)]);
        }

        // Sort them by number of guessed numbers
        top10.sort(function(a, b) {
            return b[1] - a[1];
        });

        return top10;
    }

    return {
        addPlayerToRank: addPlayerToRank,
        showTop10: showTop10
    }
}());