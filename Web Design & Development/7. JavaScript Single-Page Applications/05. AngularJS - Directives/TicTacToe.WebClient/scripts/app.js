'use strict';

var ticTacToeApp = angular.module('rockBandsApp', ['ngResource', 'ngRoute'])
    .config(function ($routeProvider) {
        MobileDeviceChecker.hideFooterIfOnMobileDevice();

        $routeProvider
            .when('/', {
                templateUrl: 'templates/list/games.html'
            })
            .when('/games/', {
                templateUrl: 'templates/list/games.html'
            })
            .when('/game/create', {
                templateUrl: 'templates/create-game.html'
            })
            .when('/games-history', {
                templateUrl: 'templates/list/games-history.html'
            })
            .when('/game/:id', {
                templateUrl: 'templates/game-status.html'
            })
            .when('/scores/', {
                templateUrl: 'templates/list/scores.html'
            })
            .when('/users/', {
                templateUrl: 'templates/list/users.html'
            })
            .when('/login', {
                templateUrl: 'templates/auth/login.html'
            })
            .when('/registration', {
                templateUrl: 'templates/auth/registration.html'
            })
            .otherwise({ redirectTo: '/' });
    })
    .constant('author', 'Martin Nikolov')
    .constant('copyright', 'Telerik Academy');