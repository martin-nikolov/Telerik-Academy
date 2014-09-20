'use strict';

rockBandsApp.factory('rockBandsData', function ($resource, $http, $q) {
    var url = 'http://localhost:3333/api/';

    function repositoryFactory(name) {
        if (name === 'bands') {
            return Bands;
        }
        else if (name === 'albums') {
            return Albums;
        }
        else if (name === 'songs') {
            return Songs;
        }
    }

    function numberOfItems(repositoryName) {
        var deferred = $q.defer();

        $http({ method: 'GET', url: url + repositoryName + '/Count' })
            .success(function (data, status, headers, config) {
                deferred.resolve(data);
            })

        return deferred.promise;
    }

    function getCoverOfItems(repositoryName, count) {
        var deferred = $q.defer();

        $http({ method: 'GET', url: url + repositoryName + '/GetCovers?count=' + count })
            .success(function (data, status, headers, config) {
                deferred.resolve(data);
            })

        return deferred.promise;
    }

    return {
        getCoverOfItems: function (repositoryName, count) {
            if (!count) {
                return numberOfItems(repositoryName)
                      .then(function(data) {
                          return getCoverOfItems(repositoryName, data);
                      });
            }
            else {
                return getCoverOfItems(repositoryName, count);
            }
        },
        getBandBySrc: function (src) {
            var deferred = $q.defer();

            $http({
                    method: 'GET',
                    url: url + 'Bands/GetBySrc',
                    params: {
                        src: src
                    }
                })
                .success(function (data, status, headers, config) {
                    deferred.resolve(data);
                })

            return deferred.promise;
        },
        getAlbums: function (bandSrc, count) {
            var deferred = $q.defer();

            $http({
                    method: 'GET',
                    url: url + 'Albums/GetByBandSrc',
                    params: {
                            BandSrc: bandSrc,
                            count: count
                        }
                })
                .success(function (data, status, headers, config) {
                    deferred.resolve(data);
                })

            return deferred.promise;
        },
        getAlbumBySrc: function (src) {
            var deferred = $q.defer();

            $http({
                method: 'GET',
                url: url + 'Albums/GetBySrc',
                params: {
                    src: src
                }
            })
            .success(function (data, status, headers, config) {
                deferred.resolve(data);
            })

            return deferred.promise;
        },
        getSongs: function (bandSrc, count) {
            var deferred = $q.defer();

            $http({
                method: 'GET',
                url: url + 'Songs/GetByBandSrc',
                params: {
                    bandSrc: bandSrc,
                    count: count
                }
            })
            .success(function (data, status, headers, config) {
                deferred.resolve(data);
            })

            return deferred.promise;
        },
        getSongBySrc: function (songSrc) {
            var deferred = $q.defer();

            $http({
                method: 'GET',
                url: url + 'Songs/GetBySrc',
                params: {
                    songSrc: songSrc
                }
            })
            .success(function (data, status, headers, config) {
                deferred.resolve(data);
            })

            return deferred.promise;
        },
        getSongsByAlbumId: function (albumId) {
            var deferred = $q.defer();

            $http({
                method: 'GET',
                url: url + 'Songs/GetByAlbumId',
                params: {
                    albumId: albumId
                }
            })
            .success(function (data, status, headers, config) {
                deferred.resolve(data);
            })

            return deferred.promise;
        },
        voteBand: function (bandId, isUpVote) {
            var deferred = $q.defer();

            $http({
                method: 'POST',
                url: url + 'Bands/Vote',
                params: {
                    bandId: bandId,
                    isUpVote: isUpVote
                }
            })
            .success(function (data, status, headers, config) {
                deferred.resolve(data);
            })

            return deferred.promise;
        },
        updateAlbum: function (albumId, isUpVote) {
            var deferred = $q.defer();

            $http({
                method: 'POST',
                url: url + 'Albums/Vote',
                params: {
                    albumId: albumId,
                    isUpVote: isUpVote
                }
            })
            .success(function (data, status, headers, config) {
                deferred.resolve(data);
            })

            return deferred.promise;
        },
        updateSong: function (songId, isUpVote) {
            var deferred = $q.defer();

            $http({
                method: 'POST',
                url: url + 'Songs/Vote',
                params: {
                    songId: songId,
                    isUpVote: isUpVote
                }
            })
            .success(function (data, status, headers, config) {
                deferred.resolve(data);
            })

            return deferred.promise;
        }
    }
});