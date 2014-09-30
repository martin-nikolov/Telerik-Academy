'use strict';

app.controller('LoginController',
    function LoginController($rootScope, $scope, $resource, $location, notifier, identity, auth) {
        if (identity.isAuthenticated()) {
            $location.path('/');
            return;
        }

        $scope.login = function () {
            var user = {
                username: $scope.username,
                password: $scope.password
            };

            auth.login(user).then(function (isLoggedInSuccessfully) {
                if (isLoggedInSuccessfully === true) {
                    $rootScope.isLoggedIn = true;
                    $rootScope.username = identity.getCurrentUser().userName;
                    notifier.success("You logged in successfully!");
                    $location.path('/');
                }
            }, function(error) {
                notifier.error(error.error_description);
            });
        }
    }
);
