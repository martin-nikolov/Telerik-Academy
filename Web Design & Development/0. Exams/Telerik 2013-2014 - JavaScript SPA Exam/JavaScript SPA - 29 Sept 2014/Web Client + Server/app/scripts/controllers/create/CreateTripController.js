'use strict';

app.controller('CreateTripController', ['$scope', '$location', 'appData', 'notifier', 'identity',
    function CreateTripController($scope, $location, appData, notifier, identity) {

        // Get cities
        appData.getCities().then(function (data) {
            $scope.cities = data;
        });

        $scope.createNewTrip = function () {
            var tripModel = {
                From: $scope.from,
                To: $scope.to,
                AvailableSeats: $scope.availableSeats,
                DepartureTime: $scope.departureTime
            };

            appData.createNewTrip(tripModel).then(function (data) {
                notifier.success("Trip was created successfully!");
                $location.path('/trips/' + data.id);
            }, function (error) {
                notifier.error(error.message);
            })
        }
    }]);