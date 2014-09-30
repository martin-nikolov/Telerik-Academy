'use strict';

app.controller('DetailsTripController', ['$scope', '$routeParams', '$location', 'appData', 'notifier', 'identity',
    function DetailsTripController($scope, $routeParams, $location, appData, notifier, identity) {
        if (!identity.isAuthenticated()) {
            $location.path('/login');
            return;
        }

        var tripId = $routeParams.id;
        getTripById(tripId);

        function getTripById(id) {
            appData.getTripById(id).then(function (data) {
                var tripModel = {
                    from: data.from,
                    to: data.to,
                    passengers: data.passengers.join(', '),
                    numberOfFreeSeats: data.numberOfFreeSeats,
                    driverName: data.driverName,
                    departureDate: data.departureDate,
                    isMine: data.isMine
                };

                $scope.trip = tripModel;
            });
        }

        $scope.joinInTrip = function () {
            // Join in trip by id
            appData.joinInTrip(tripId).then(function (data) {
                notifier.success("You joined successfully in trip!");
                getTripById(tripId);
            }, function(error) {
                notifier.error(error.message);
            });
        }
    }]);