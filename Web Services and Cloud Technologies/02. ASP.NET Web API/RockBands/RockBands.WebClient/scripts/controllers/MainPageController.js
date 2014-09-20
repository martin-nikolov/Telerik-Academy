'use strict';

rockBandsApp.controller('MainPageController',
    function MainPageController($scope, $rootScope, author, copyright) {
        $scope.author = author;
        $scope.copyright = copyright;
        $scope.$on('$locationChangeStart', function () {
            $rootScope.isSearchInputShown = false;
            $scope.search = undefined;
        });
    }
);