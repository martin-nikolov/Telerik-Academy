'use strict';

ticTacToeApp.controller('MainPageController',
    function MainPageController($scope, $rootScope, author, copyright, auth) {
        $scope.author = author;
        $scope.copyright = copyright;

        if (auth.isAuthenticated()) {
            $rootScope.isLoggedIn = true;
            $rootScope.username = auth.getUsername();
        }
    }
);