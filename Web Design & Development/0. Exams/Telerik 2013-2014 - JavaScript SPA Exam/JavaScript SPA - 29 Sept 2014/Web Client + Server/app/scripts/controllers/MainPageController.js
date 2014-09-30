'use strict';

app.controller('MainPageController',
    function MainPageController($scope, $rootScope, author, copyright, identity) {
        $scope.author = author;
        $scope.copyright = copyright;

        if (identity.isAuthenticated()) {
            $rootScope.isLoggedIn = true;
            $rootScope.username = identity.getCurrentUser().userName;
        }
    }
);