'use strict';

app.controller('UsersInfoController',
    function UsersInfoController($rootScope, $scope, $resource, $location, notifier, appData, identity, auth) {
        if (!identity.isAuthenticated()) {
            $location.path('/');
            return;
        }

        appData.getUserInfo().then(function (data) {
            var user = {
                email: data.email,
                isDriver: data.isDriver,
                car: data.car
            };

            $scope.user = user;
        });
    }
);
