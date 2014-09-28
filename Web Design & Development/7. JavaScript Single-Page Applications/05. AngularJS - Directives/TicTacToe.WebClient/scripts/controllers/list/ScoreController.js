'use strict';

ticTacToeApp.controller('ScoreController',
    function ScoreController($scope, ticTacToeData) {
        ticTacToeData
            .getScores()
            .then(function (data) {
                $scope.scores = data;
            });
    }
);