define(function(require) {

    var _scoreContainer = null;

    function ScoreBoard() {
        scoreContainer = document.getElementById('score-result');
        var showTip10 = document.getElementById('top10');

        var that = this;
        showTip10.onclick = function() {
            that.showTop10();
        };

        this.update(0);
    }

    function getScore() {
        var score = parseInt(scoreContainer.textContent) || 0;
        return score;
    }

    ScoreBoard.prototype.showTop10 = function() {
        var top10 = [];

        for (var i in localStorage) {
            top10.push([i, localStorage.getItem(i)]);
        }

        top10.sort(function(a, b) {
            return b[1] - a[1];
        });

        var top10toText = [];

        for (var i = 1; i <= top10.length && i <= 10; i++) {
            top10toText.push(i + ". " + top10[i - 1][0] + " -> " + top10[i - 1][1]);
        }

        if (top10toText.length > 0) {
            alert(top10toText.join("\n"));
        }
        else {
            alert("No players!");
        }
    };

    ScoreBoard.prototype.addPlayerToRank = function() {
        var playerName = prompt("Enter your name: ");
        if (playerName) {
            localStorage.setItem(playerName, getScore());
        }
    };

    ScoreBoard.prototype.update = function(value) {
        var result = getScore() + value;
        scoreContainer.textContent = result;
    };

    return ScoreBoard;
});