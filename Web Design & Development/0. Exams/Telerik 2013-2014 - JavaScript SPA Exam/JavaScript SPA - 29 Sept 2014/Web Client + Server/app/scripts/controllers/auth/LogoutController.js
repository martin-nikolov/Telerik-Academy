'use strict';

app.controller('LogoutController',
    function LogoutController($rootScope, $scope, $resource, $location, notifier, auth) {
        $scope.logout = function () {
            auth.logout().then(function () {
                notifier.success("You logged out successfully!");
                $rootScope.isLoggedIn = false;
                $location.path('/');
                return;
            });
        }
    }
);
