'use strict';

ticTacToeApp.filter('gameStatusFilter', function () {
    return function (state, status) {
        switch (status.state) {
            case 0:
            {
                return "Available"
            }
            case 1:
            {
                if (status.firstPlayerName === status.currentPlayerName) {
                    return "Your turn";
                }
                else {
                    return "Opponent turn";
                }
            }
            case 2:
            {
                if (status.firstPlayerName === status.currentPlayerName) {
                    return "Opponent turn";
                }
                else {
                    return "Your turn";
                }
            }
            case 3:
            {
                if (status.firstPlayerName === status.currentPlayerName) {
                    return "Victory"
                }
                else {
                    return "Loss";
                }
            }
            case 4:
            {
                if (status.firstPlayerName === status.currentPlayerName) {
                    return "Loss"
                }
                else {
                    return "Victory";
                }
            }
            case 5:
            {
                return "Draw"
            }
        }
    }
});