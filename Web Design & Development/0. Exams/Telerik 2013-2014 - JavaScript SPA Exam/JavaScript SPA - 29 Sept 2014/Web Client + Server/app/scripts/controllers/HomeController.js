'use strict';

app.controller('HomeController', ['$scope', 'appData', 'identity',
    function HomeController($scope, appData, identity) {
        // Get public 10 trips
        appData.getPublicTrips().then(function (data) {
            $scope.trips = data;
        });

        // Get public 10 drivers
        appData.getPublicDrivers().then(function (data) {
            $scope.drivers = data;
        });

        // Get trip stats
        appData.getTripStats().then(function (data) {
            $scope.stats = {
                trips: data.trips,
                finishedTrips: data.finishedTrips,
                users: data.users,
                drivers: data.drivers
            };
        });
    }]);