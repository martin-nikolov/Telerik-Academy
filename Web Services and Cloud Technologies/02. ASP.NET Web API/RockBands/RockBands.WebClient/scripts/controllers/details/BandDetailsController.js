'use strict';

rockBandsApp.controller('BandDetailsController',
    function BandDetailsController($scope, $rootScope, $location, $templateCache, $routeParams, rockBandsData) {
        var baseUrl = '/bands';

        if ($routeParams.name) {
            rockBandsData
                .getBandBySrc($routeParams.name)
                .then(function (data) {
                    if (!data) {
                        $location.path(baseUrl);
                        return;
                    }

                    $scope.band = data;
                    return data.Src || null;
                })
                .then(function (bandSrc) {
                    if (!bandSrc) {
                        return null;
                    }

                    rockBandsData
                        .getAlbums(bandSrc, 4)
                        .then(function (data) {
                            $scope.albums = data;
                        });

                    return bandSrc;
                })
                .then(function (bandSrc) {
                    if (!bandSrc) {
                        return;
                    }

                    rockBandsData
                        .getSongs(bandSrc, 4)
                        .then(function (data) {
                            $scope.songs = data;
                        });
                });
        }

        $scope.upRating = upRating;
        $scope.downRating = downRating;
        $scope.showAndHideBandMembers = showAndHideBandMembers;
        $scope.isBandMembersListVisible = false;
        $scope.toggleBandMembersListButtonText = "Show";

        function showAndHideBandMembers() {
            $scope.toggleBandMembersListButtonText = $scope.isBandMembersListVisible ? "Show" : "Hide";
            $scope.isBandMembersListVisible = !$scope.isBandMembersListVisible;
        }

        function upRating(band) {
            band.Rating++;
            updateItem(band.BandId, true);
        }

        function downRating(band) {
            if (band.Rating > 0) {
                band.Rating--;
                updateItem(band.BandId, false);
            }
        }

        function updateItem(id, isUpVote) {
            rockBandsData
                .voteBand(id, isUpVote)
                .then(null, function () {
                    ErrorModalWindow.showRestrictedAccessWindow();
                });
        }
    }
);