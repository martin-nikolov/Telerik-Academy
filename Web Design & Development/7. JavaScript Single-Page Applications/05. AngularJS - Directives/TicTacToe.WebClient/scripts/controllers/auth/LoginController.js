'use strict';

ticTacToeApp.controller('LoginController',
    function LoginController($rootScope, $scope, $resource, $location, ticTacToeData, auth) {
        if (auth.isAuthenticated()) {
            $location.path('/');
            return;
        }

        $scope.username = null;

        $scope.login = function () {
            ticTacToeData.login($scope.username, $scope.password)
                .then(function (data) {
                    auth.login(data.userName, data.access_token);
                    $rootScope.isLoggedIn = true;
                    $rootScope.username = auth.getUsername();
                    $location.path('/');
                }, function (data) {
                    ErrorModalWindow.showRestrictedAccessWindow("The request is invalid.", data.error_description);
                });
        }
    }
);
