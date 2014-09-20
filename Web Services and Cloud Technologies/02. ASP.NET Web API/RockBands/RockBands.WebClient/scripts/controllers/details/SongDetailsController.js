'use strict';

rockBandsApp.controller('SongDetailsController',
    function SongDetailsController($scope, $location, $anchorScroll, $routeParams, $sce, rockBandsData) {
        var baseUrl = '/songs';

        if ($routeParams.name) {
            rockBandsData
                .getSongBySrc($routeParams.name)
                .then(function (data) {
                    if (!data) {
                        $location.path(baseUrl);
                        return;
                    }

                    $scope.song = data;
                    $scope.song.YouTubeLink = $sce.trustAsResourceUrl($scope.song.Link.replace('watch?v=', 'embed/'));
                });
        }

        $scope.upRating = upRating;
        $scope.downRating = downRating;
        $scope.onShowVideoButtonClick = onShowVideoButtonClick;

        function upRating(song) {
            song.Rating++;
            updateItem(song.SongId, true);
        }

        function downRating(song) {
            if (song.Rating > 0) {
                song.Rating--;
                updateItem(song.SongId, false);
            }
        }

        function updateItem(id, isUpVote) {
            rockBandsData
                .updateSong(id, isUpVote)
                .then(null, function () {
                    ErrorModalWindow.showRestrictedAccessWindow();
                });
        }

        function onShowVideoButtonClick() {
            $('.video-container').show();
            $location.hash('video');
            $anchorScroll();
        }
    }
);