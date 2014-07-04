define(function(require) {
    var ScoreBoard = (function() {
        // Constructor
        function ScoreBoard(scoreContainerId, showTop10Id) {
            var that = this;
            this._scoreContainer = document.getElementById(scoreContainerId);
            this._showTop10 = document.getElementById(showTop10Id);
            this._showTop10.onclick = function() {
                that.showTop10();
            };
            this.update(0);
        }

        ScoreBoard.prototype._getScore = function() {
            var score = parseInt(this._scoreContainer.textContent) || 0;
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
                localStorage.setItem(playerName, this._getScore());
            }
        };

        ScoreBoard.prototype.update = function(value) {
            var result = this._getScore() + value;
            this._scoreContainer.textContent = result;
        };

        return ScoreBoard;
    }());

    return ScoreBoard;
});