'use strict';

ticTacToeApp.controller('CreateGameController',
    function CreateGameController($scope, $location, ticTacToeData, auth) {
        if (!auth.isAuthenticated()) {
            $location.path('/login');
            return;
        }

        $scope.createGame = function (gameName) {
            ticTacToeData.createGame(gameName, auth.access_token())
                .then(function () {
                    $location.path('/');
                });
        };
    }
);