'use strict';

ticTacToeApp.controller('ListGamesController',
    function ListGamesController($rootScope, $scope, $location, $window, ticTacToeData, auth) {
        if (!auth.isAuthenticated()) {
            $location.path('/login');
            return;
        }

        $scope.currentPlayer = $rootScope.username;

        function getJoinedGames() {
            ticTacToeData
                .getJoinedGames(auth.access_token())
                .then(function (data) {
                    $scope.joinedGames = data;
                });
        }

        function getAvailableGames() {
            ticTacToeData
                .getAvailableGames(auth.access_token())
                .then(function (data) {
                    $scope.availableGames = data;
                });
        }

        function getMyGames() {
            ticTacToeData
                .getMyGames(auth.access_token())
                .then(function (data) {
                    $scope.myGames = data;
                });
        }

        getMyGames();
        getJoinedGames();
        getAvailableGames();

        $scope.joinGame = function (gameId) {
            ticTacToeData
                .joinGame(gameId, auth.access_token())
                .then(function () {
                    getJoinedGames();
                    getAvailableGames();
                });
        };

        $scope.playGame = function (gameId) {
            $location.path('/game/' + gameId);
        };

        $scope.refreshAvailableGames = getAvailableGames;
        $scope.refreshJoinedGames = getJoinedGames;
        $scope.refreshMyGames = getMyGames;
    }
);