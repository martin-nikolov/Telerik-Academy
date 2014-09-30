'use strict';

app.controller('ListTripsController', ['$scope', '$location', 'appData', 'notifier',
    function ListTripsController($scope, $location, appData, notifier) {
        $scope.currentPage = 1;
        $scope.filter = {
            sort: 'driver',
            orderBy: 'asc',
            from: '',
            to: '',
            isIncludeFinishedSelected: false,
            isMineTripSelected: false
        };

        // Get public 10 trips
        appData.getPublicTrips().then(function (data) {
            $scope.trips = data;
        });

        // Get cities
        appData.getCities().then(function (data) {
            $scope.cities = data;
        });

        $scope.createTrip = function () {
            $location.path('/trips/create');
        };

        // Get public 10 drivers
        appData.getPublicDrivers().then(function (data) {
            $scope.drivers = data;
        });

        $scope.prevPage = function () {
            if ($scope.currentPage > 1) {
                $scope.currentPage--;

                appData.filterTrips($scope.currentPage, $scope.filter.sort || '', $scope.filter.orderBy || '',
                        $scope.filter.from || '', $scope.filter.to || '', $scope.filter.isIncludeFinishedSelected,
                    $scope.filter.isMineTripSelected).then(function (data) {
                        $scope.trips = data;
                    }, function (error) {
                        notifier.error(error.message);
                    })
            }
        };

        $scope.nextPage = function () {
            appData.filterTrips($scope.currentPage + 1, $scope.filter.sort || '', $scope.filter.orderBy || '',
                    $scope.filter.from || '', $scope.filter.to || '', $scope.filter.isIncludeFinishedSelected,
                $scope.filter.isMineTripSelected)
                .then(function (data) {
                    if (data && data.length != 0) {
                        $scope.currentPage++;
                        $scope.trips = data;
                    }
                }, function (error) {
                    notifier.error(error.message);
                })
        };

        $scope.filter = function () {
            appData.filterTrips($scope.currentPage, $scope.filter.sort || '', $scope.filter.orderBy || '',
                    $scope.filter.from || '', $scope.filter.to || '', $scope.filter.isIncludeFinishedSelected,
                $scope.filter.isMineTripSelected).then(function (data) {
                    $scope.trips = data;
                    $scope.currentPage = 1;
                }, function (error) {
                    notifier.error(error.message);
                })
        };
    }]);