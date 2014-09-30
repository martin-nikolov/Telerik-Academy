'use strict';

app.controller('ListDriversController', ['$scope', 'appData', 'identity', 'notifier',
    function ListDriversController($scope, appData, identity, notifier) {
        $scope.currentPage = 1;
        $scope.driverName = '';

        // Get public 10 drivers
        appData.getPublicDrivers().then(function (data) {
            $scope.drivers = data;
        });

        $scope.prevPage = function (driverName) {
            if ($scope.currentPage > 1) {
                $scope.currentPage--;

                appData.filterDrivers(driverName, $scope.currentPage).then(function (data) {
                    $scope.drivers = data;
                }, function(error) {
                    notifier.error(error.message);
                })
            }
        };

        $scope.nextPage = function (driverName) {
            appData.filterDrivers(driverName, $scope.currentPage + 1).then(function (data) {
                if (data && data.length != 0) {
                    $scope.currentPage++;
                    $scope.drivers = data;
                }
            }, function(error) {
                notifier.error(error.message);
            })
        };

        $scope.filterByName = function(driverName) {
            $scope.currentPage = 1;
            appData.filterDrivers(driverName, $scope.currentPage).then(function (data) {
                $scope.drivers = data;
            }, function(error) {
                notifier.error(error.message);
            })
        }
    }]);