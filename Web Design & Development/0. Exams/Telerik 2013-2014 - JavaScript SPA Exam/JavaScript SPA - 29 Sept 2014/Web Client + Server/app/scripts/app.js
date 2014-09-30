'use strict';

var app = angular.module('myApp', ['ngRoute', 'ngResource', 'ngCookies']).
    config(['$routeProvider', function ($routeProvider) {
        $routeProvider
            .when('/', {
                templateUrl: '../views/partials/home.html',
                controller: 'HomeController'
            })
            .when('/drivers', {
                templateUrl: 'views/partials/list/drivers.html',
                controller: 'ListDriversController'
            })
            .when('/drivers/:id', {
                templateUrl: 'views/partials/details/driver-details.html',
                controller: 'DetailsDriverController'
            })
            .when('/trips', {
                templateUrl: 'views/partials/list/trips.html',
                controller: 'ListTripsController'
            })
            .when('/trips/create', {
                templateUrl: 'views/partials/create/create-trip.html',
                controller: 'CreateTripController'
            })
            .when('/trips/:id', {
                templateUrl: 'views/partials/details/trip-details.html',
                controller: 'DetailsTripController'
            })
            .when('/users/userInfo', {
                templateUrl: 'views/partials/users/info.html',
                controller: 'UsersInfoController'
            })
            .when('/login', {
                templateUrl: 'views/partials/auth/login.html',
                controller: 'LoginController'
            })
            .when('/registration', {
                templateUrl: 'views/partials/auth/registration.html',
                controller: 'RegistrationController'
            })
            .otherwise({ redirectTo: '/' });
    }])
    .constant('author', '')
    .constant('copyright', 'Telerik Academy')
    .value('toastr', toastr)
    .constant('baseServiceUrl', 'http://localhost:1337/');

app.run(function ($rootScope, $location, authFactory, identity) {
    $rootScope.$on('$locationChangeStart', function (ev, currentRoute, previous, rejection) {
        if (authFactory.isAuthRoute(currentRoute) && !identity.isAuthenticated()) {
            $location.path('/login');
        }
    });
});