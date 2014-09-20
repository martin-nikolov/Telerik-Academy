'use strict';

var rockBandsApp = angular.module('rockBandsApp', ['ngResource', 'ngRoute'])
    .config(function ($routeProvider) {
        MobileDeviceChecker.hideFooterIfOnMobileDevice();

        $routeProvider
            .when('/', {
                templateUrl: 'templates/home.html'
            })
            .when('/bands/', {
                templateUrl: 'templates/list/bands.html'
            })
            .when('/band/:name', {
                templateUrl: 'templates/details/band-details.html'
            })
            .when('/albums/', {
                templateUrl: 'templates/list/albums.html'
            })
            .when('/albums/:name', {
                templateUrl: 'templates/list/albums.html'
            })
            .when('/album/:name', {
                templateUrl: 'templates/details/album-details.html'
            })
            .when('/songs/', {
                templateUrl: 'templates/list/songs.html'
            })
            .when('/songs/:name', {
                templateUrl: 'templates/list/songs.html'
            })
            .when('/song/:name', {
                templateUrl: 'templates/details/song-details.html'
            })
            .otherwise({redirectTo: '/'});
    })
    .constant('author', 'Martin Nikolov')
    .constant('copyright', 'Telerik Academy');