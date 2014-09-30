'use strict';

app.controller('RegistrationController',
    function RegistrationController($rootScope, $scope, $resource, $location, identity, auth, notifier) {
        if (identity.isAuthenticated()) {
            $location.path('/');
            return;
        }

        $scope.registration = function () {
            var user = {
                email: $scope.email,
                password: $scope.password,
                confirmPassword: $scope.confirmPassword,
                isDriver: $scope.isDriver,
                car: $scope.carName
            };

            auth.signup(user).then(function () {
                notifier.success("Success registration!");
                $location.path('/');
            }, function (error) {
                notifier.error(error.message);
            });
        }
    }
);
