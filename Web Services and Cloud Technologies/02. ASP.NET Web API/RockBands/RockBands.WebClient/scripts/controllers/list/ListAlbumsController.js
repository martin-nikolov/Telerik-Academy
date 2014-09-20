'use strict';

rockBandsApp.controller('ListAlbumsController',
    function ListAlbumsController($scope, $rootScope, $routeParams, $location, rockBandsData) {
        $rootScope.isSearchInputShown = true;
        var bandSrc = $routeParams.name;

        rockBandsData
            .getAlbums(bandSrc)
            .then(function (data) {
                if (!data.length && bandSrc) {
                    $location.path('/albums');
                    return;
                }

                $scope.albums = data;
            });
    }
);