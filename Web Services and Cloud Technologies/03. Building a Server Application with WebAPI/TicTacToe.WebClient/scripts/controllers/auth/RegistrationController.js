'use strict';

ticTacToeApp.controller('RegistrationController',
    function RegistrationController($rootScope, $scope, $resource, $location, ticTacToeData, auth) {
        if (auth.isAuthenticated()) {
            $location.path('/');
            return;
        }

        $scope.username = null;

        $scope.registration = function () {
            ticTacToeData.register($scope.username, $scope.password)
                .then(function () {
                    ticTacToeData.login($scope.username, $scope.password)
                        .then(function (data) {
                            auth.login(data.userName, data.access_token);
                            $rootScope.isLoggedIn = true;
                            $rootScope.username = auth.getUsername();
                            $location.path('/');
                        }, function (data) {
                            ErrorModalWindow.showRestrictedAccessWindow("The request is invalid.", data.error_description);
                        });
                }, function (data) {
                    ErrorModalWindow.showRestrictedAccessWindow(data.Message, data.ModelState[Object.keys(data.ModelState)[0]][0]);
                });
        }
    }
);
