'use strict';

app.filter('driverDetailsFilter', function () {
    return function (collection, driverName, isMineTripSelected, isOnlyDriverTripSelected) {
        var filteredCollection = [];

        if (!collection || !collection.length) {
            return collection;
        }

        for (var i = 0; i < collection.length; i++) {
            var currentTrip = collection[i];

            if (isMineTripSelected === true && currentTrip.isMine === true ||
                isOnlyDriverTripSelected === true && currentTrip.driverName === driverName) {
                filteredCollection.push(currentTrip);
            }
            else if (!isMineTripSelected && !isOnlyDriverTripSelected) {
                filteredCollection.push(currentTrip);
            }
        }

        return filteredCollection;
    }
});