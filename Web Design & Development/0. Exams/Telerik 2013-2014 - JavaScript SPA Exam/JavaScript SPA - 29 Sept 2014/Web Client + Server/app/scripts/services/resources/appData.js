'use strict';

app.factory('appData', function ($resource, $http, $q, authorization) {
    var url = 'http://localhost:1337/';

    function getJson(toUrl) {
        var deferred = $q.defer();

        $http.get(toUrl)
            .success(function (data) {
                deferred.resolve(data);
            })
            .error(function (data) {
                deferred.reject(data);
            });

        return deferred.promise;
    }

    return {
        getPublicTrips: function () {
            return getJson(url + 'api/trips/');
        },
        getPublicDrivers: function () {
            return getJson(url + 'api/drivers/');
        },
        getTripStats: function () {
            return getJson(url + 'api/stats/');
        },
        getCities: function () {
            return getJson(url + 'api/cities/');
        },
        createNewTrip: function (data) {
            var deferred = $q.defer();

            var headers = authorization.getAuthorizationHeader();
            $http.post(url + 'api/trips', data, { headers: headers })
                .success(function (success) {
                    deferred.resolve(success);
                })
                .error(function (error) {
                    deferred.reject(error);
                });

            return deferred.promise;
        },
        getTripById: function (id) {
            var deferred = $q.defer();

            var headers = authorization.getAuthorizationHeader();
            $http.get(url + 'api/trips/' + id, { headers: headers })
                .success(function (success) {
                    deferred.resolve(success);
                })
                .error(function (error) {
                    deferred.reject(error);
                });

            return deferred.promise;
        },
        joinInTrip: function (id) {
            var deferred = $q.defer();

            var headers = authorization.getAuthorizationHeader();
            $http.put(url + 'api/trips/' + id, {}, { headers: headers })
                .success(function (success) {
                    deferred.resolve(success);
                })
                .error(function (error) {
                    deferred.reject(error);
                });

            return deferred.promise;
        },
        filterDrivers: function (driverName, page) {
            var deferred = $q.defer();

            var headers = authorization.getAuthorizationHeader();
            $http.get(url + 'api/drivers/?page=' + page + '&username=' + driverName, { headers: headers })
                .success(function (success) {
                    deferred.resolve(success);
                })
                .error(function (error) {
                    deferred.reject(error);
                });

            return deferred.promise;
        },
        getDriverDetailsById: function (id) {
            var deferred = $q.defer();

            var headers = authorization.getAuthorizationHeader();
            $http.get(url + 'api/drivers/' + id, { headers: headers })
                .success(function (success) {
                    deferred.resolve(success);
                })
                .error(function (error) {
                    deferred.reject(error);
                });

            return deferred.promise;
        },
        filterTrips: function (page, orderBy, orderType, from, to, finished, onlyMine) {
            finished = finished === true ? true : false;
            onlyMine = onlyMine === true ? true : false;

            var queryUrl = 'api/trips?page=' + page + '&from=' + from +
                '&to=' + to + '&finished=' + finished + '&onlyMine=' + onlyMine;

            if (orderBy && orderType) {
                queryUrl += '&orderBy=' + orderBy + '&orderType=' + orderType;
            }

            var deferred = $q.defer();

            var headers = authorization.getAuthorizationHeader();
            $http.get(url + queryUrl, { headers: headers })
                .success(function (success) {
                    deferred.resolve(success);
                })
                .error(function (error) {
                    deferred.reject(error);
                });

            return deferred.promise;
        },
        getUserInfo: function () {
            var deferred = $q.defer();

            var headers = authorization.getAuthorizationHeader();
            $http.get(url + 'api/users/userInfo', { headers: headers })
                .success(function (success) {
                    deferred.resolve(success);
                })
                .error(function (error) {
                    deferred.reject(error);
                });

            return deferred.promise;
        }
    }
});
