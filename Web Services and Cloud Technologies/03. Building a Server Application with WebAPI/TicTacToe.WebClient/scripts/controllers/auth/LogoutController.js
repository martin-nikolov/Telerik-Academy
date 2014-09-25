'use strict';

ticTacToeApp.controller('LogoutController',
    function LogoutController($rootScope, $scope, $resource, $location, ticTacToeData, auth) {
        $scope.logout = function () {
            auth.logout();
            $rootScope.isLoggedIn = false;
            $location.path('/login');
            return;
        }
    }
);
