'use strict';

rockBandsApp.controller('ListSongsController',
    function ListSongsController($scope, $rootScope, $routeParams, $location, rockBandsData) {
        $rootScope.isSearchInputShown = true;
        var bandSrc = $routeParams.name;

        rockBandsData
            .getSongs(bandSrc)
            .then(function (data) {
                if (!data.length && bandSrc) {
                    $location.path('/songs');
                    return;
                }

                $scope.songs = data;
            });
    }
);