'use strict';

rockBandsApp.controller('ListBandsController',
    function ListBandsController($scope, $rootScope, rockBandsData) {
        $rootScope.isSearchInputShown = true;
        var BANDS_FACTORY_NAME = 'bands';

        rockBandsData
            .getCoverOfItems(BANDS_FACTORY_NAME)
            .then(function (data) {
                $scope.bands = data;
            });
    }
);