'use strict';

ticTacToeApp.controller('GameStatusController',
    function GameStatusController($rootScope, $scope, $location, $routeParams, ticTacToeData, auth) {
        if (!auth.isAuthenticated()) {
            $location.path('/login');
            return;
        }

        if (!$routeParams.id) {
            $location.path('/');
            return;
        }

        getGameStatus();
        var timer = setInterval(getGameStatus, 2000);

        function getGameStatus() {
            if ($location.path().indexOf('/game/') === -1) {
                clearInterval(timer);
                return;
            }

            ticTacToeData
                .getGameStatus($routeParams.id, auth.access_token())
                .then(function (data) {
                    if ($scope.board != data.Board) {
                        $scope.gameId = data.Id;
                        $scope.board = data.Board;
                        $scope.gameStatus = data.State;
                        $scope.cursorClass = 'allowed';

                        $scope.hasTwoPlayers = data.FirstPlayerName && data.SecondPlayerName;
                        if ($scope.hasTwoPlayers) {
                            $scope.currentPlayer = $rootScope.username;
                            $scope.firstPlayer = data.FirstPlayerName;
                            $scope.secondPlayer = data.SecondPlayerName;
                        }

                        if (data.FirstPlayerName === $rootScope.username && data.State == 2 ||
                            data.FirstPlayerName !== $rootScope.username && data.State == 1) {
                            $scope.cursorClass = 'notAllowed';
                        }

                        if ([0, 3, 4, 5].indexOf(data.State) !== -1) {
                            clearInterval(timer);
                            $scope.cursorClass = 'notAllowed';
                            return;
                        }
                    }
                }, function () {
                    clearInterval(timer);
                    $location.path('/');
                    return;
                });
        }


        $scope.click = function (row, col) {
            if ($scope.board[row * 3 + col] === '-' && [0, 3, 4, 5].indexOf($scope.gameStatus) === -1) {
                ticTacToeData.playGame($scope.gameId, row + 1, col + 1, auth.access_token())
                    .then(function () {
                        getGameStatus();
                    }, function (e) {
                        console.log(e)
                    });
            }
        }
    }
);