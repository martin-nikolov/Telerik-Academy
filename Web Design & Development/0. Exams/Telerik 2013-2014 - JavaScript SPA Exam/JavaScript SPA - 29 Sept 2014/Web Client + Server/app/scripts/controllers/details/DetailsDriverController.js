'use strict';

app.controller('DetailsDriverController', ['$scope', '$routeParams', '$location', 'appData', 'notifier', 'identity',
    function DetailsDriverController($scope, $routeParams, $location, appData, notifier, identity) {
        if (!identity.isAuthenticated()) {
            $location.path('/login');
            return;
        }

        var tripId = $routeParams.id;

        appData.getDriverDetailsById(tripId).then(function (data) {
            $scope.driver = data;
        });
    }]);