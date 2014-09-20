'use strict';

rockBandsApp.controller('AlbumDetailsController',
    function AlbumDetailsController($scope, $location, $templateCache, $routeParams, rockBandsData) {
        var baseUrl = '/albums';

        if ($routeParams.name) {
            rockBandsData
                .getAlbumBySrc($routeParams.name)
                .then(function (data) {
                    if (!data) {
                        $location.path(baseUrl);
                        return;
                    }

                    $scope.album = data;
                    return data.AlbumId;
                })
                .then(function (albumId) {
                    rockBandsData
                        .getSongsByAlbumId(albumId)
                        .then(function (data) {
                            $scope.songs = data;
                        });
                });
        }

        $scope.upRating = upRating;
        $scope.downRating = downRating;

        function upRating(album) {
            album.Rating++;
            updateItem(album.AlbumId, true);
        }

        function downRating(album) {
            if (album.Rating > 0) {
                album.Rating--;
                updateItem(album.AlbumId, false);
            }
        }

        function updateItem(id, isUpVote) {
            rockBandsData
                .updateAlbum(id, isUpVote)
                .then(null, function () {
                    ErrorModalWindow.showRestrictedAccessWindow();
                });
        }
    }
);