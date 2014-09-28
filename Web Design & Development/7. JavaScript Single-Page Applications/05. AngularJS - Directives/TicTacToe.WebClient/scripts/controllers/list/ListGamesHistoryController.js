'use strict';

ticTacToeApp.controller('ListGamesHistoryController',
    function ListGamesHistoryController($rootScope, $scope, $location, $window, ticTacToeData, auth) {
        if (!auth.isAuthenticated()) {
            $location.path('/login');
            return;
        }

        $scope.currentPlayer = $rootScope.username;

        ticTacToeData
            .getMyGamesHistory(auth.access_token())
            .then(function (data) {
                $scope.myGamesHistory = data;
            });

        $scope.seeStatus = function (gameId) {
            $location.path('/game/' + gameId);
        };
    }
);