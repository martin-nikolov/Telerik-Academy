'use strict';

ticTacToeApp.controller('ListUsersController',
    function ListUsersController($scope, ticTacToeData) {
        ticTacToeData
            .getUsers()
            .then(function (data) {
                $scope.users = data;
            });
    }
);