'use strict';

rockBandsApp.controller('HomeController',
    function HomeController($scope, $resource, rockBandsData) {
        var NUMBER_OF_ITEMS_TO_TAKE = 3,
            BANDS_FACTORY_NAME = 'bands',
            ALBUMS_FACTORY_NAME = 'albums',
            SONGS_FACTORY_NAME = 'songs';

        getCoverOfItems(BANDS_FACTORY_NAME);
        getCoverOfItems(ALBUMS_FACTORY_NAME);
        getCoverOfItems(SONGS_FACTORY_NAME);

        function getCoverOfItems(factoryName) {
            rockBandsData.getCoverOfItems(factoryName, NUMBER_OF_ITEMS_TO_TAKE)
                .then(function (data) {
                    $scope[factoryName] = data;
                });
        }
    }
);