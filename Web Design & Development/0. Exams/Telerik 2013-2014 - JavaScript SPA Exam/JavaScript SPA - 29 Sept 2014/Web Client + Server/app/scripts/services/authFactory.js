'use strict';

app.factory('authFactory', function () {
    var AUTH_ROUTES = [ 'about', 'trips/create', 'users/userInfo' /*'trips/create' */];

    function getRoute(url) {
        var ROUTE_SEPARATOR = '/#/';
        var indexOfDies = url.indexOf(ROUTE_SEPARATOR);
        var route = url.substr(indexOfDies + ROUTE_SEPARATOR.length);
        return route;
    }

    return {
        isAuthRoute: function (url) {
            var route = getRoute(url);
            var isAuthRout = AUTH_ROUTES.indexOf(route) !== -1;
            return isAuthRout;
        },
        getRoute: function (url) {
            return getRoute(url);
        }
    }
});