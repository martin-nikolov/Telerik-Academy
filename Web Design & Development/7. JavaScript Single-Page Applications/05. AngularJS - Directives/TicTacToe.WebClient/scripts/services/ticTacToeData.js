'use strict';

ticTacToeApp.factory('ticTacToeData', function ($resource, $http, $q) {
    var url = 'http://localhost:4444/';

    function getGames(type, access_token) {
        var deferred = $q.defer();

        $http.get(url + 'api/Games/' + type,
            {
                transformRequest: function (obj) {
                    var str = [];
                    for (var p in obj)
                        str.push(encodeURIComponent(p) + "=" + encodeURIComponent(obj[p]));
                    return str.join("&");
                },
                headers: {
                    'Content-Type': 'application/x-www-form-urlencoded',
                    'authorization': 'Bearer ' + access_token
                }
            })
            .success(function (data) {
                deferred.resolve(data);
            })
            .error(function (data) {
                deferred.reject(data);
            });

        return deferred.promise;
    }

    return {
        register: function (username, password) {
            var deferred = $q.defer();

            $http.post(url + 'api/Account/Register', {
                Username: username,
                Password: password,
                ConfirmPassword: password
            },
                {
                    transformRequest: function (obj) {
                        var str = [];
                        for (var p in obj)
                            str.push(encodeURIComponent(p) + "=" + encodeURIComponent(obj[p]));
                        return str.join("&");
                    },
                    headers: {
                        'Content-Type': 'application/x-www-form-urlencoded'
                    }
                })
                .success(function (data) {
                    deferred.resolve(data);
                })
                .error(function (data) {
                    deferred.reject(data);
                });

            return deferred.promise;
        },
        login: function (username, password) {
            var deferred = $q.defer();

            $http.post(url + 'Token', {
                username: username,
                password: password,
                grant_type: "password"
            },
                {
                    transformRequest: function (obj) {
                        var str = [];
                        for (var p in obj)
                            str.push(encodeURIComponent(p) + "=" + encodeURIComponent(obj[p]));
                        return str.join("&");
                    },
                    headers: {
                        'Content-Type': 'application/x-www-form-urlencoded'
                    }
                })
                .success(function (data) {
                    deferred.resolve(data);
                })
                .error(function (data) {
                    deferred.reject(data);
                });

            return deferred.promise;
        },
        getUsers: function () {
            var deferred = $q.defer();

            $http.get(url + 'api/Users/All')
                .success(function (data) {
                    deferred.resolve(data);
                })
                .error(function (data) {
                    deferred.resolve(data);
                });

            return deferred.promise;
        },
        getScores: function () {
            var deferred = $q.defer();

            $http.get(url + 'api/Scores/Top')
                .success(function (data) {
                    deferred.resolve(data);
                })
                .error(function (data) {
                    deferred.resolve(data);
                });

            return deferred.promise;
        },
        getMyGames: function (access_token) {
            return getGames('MyGames', access_token);
        },
        getMyGamesHistory: function (access_token) {
            return getGames('MyGamesHistory', access_token);
        },
        getAvailableGames: function (access_token) {
            return getGames('AvailableGames', access_token);
        },
        getJoinedGames: function (access_token) {
            return getGames('JoinedGames', access_token);
        },
        createGame: function (gameName, access_token) {
            var deferred = $q.defer();

            $http.post(url + 'api/Games/Create', {
                Name: gameName
            },
                {
                    transformRequest: function (obj) {
                        var str = [];
                        for (var p in obj)
                            str.push(encodeURIComponent(p) + "=" + encodeURIComponent(obj[p]));
                        return str.join("&");
                    },
                    headers: {
                        'Content-Type': 'application/x-www-form-urlencoded',
                        'authorization': 'Bearer ' + access_token
                    }
                })
                .success(function (data) {
                    deferred.resolve(data);
                })
                .error(function (data) {
                    deferred.reject(data);
                });

            return deferred.promise;
        },
        joinGame: function (gameId, access_token) {
            var deferred = $q.defer();

            $http.post(url + 'api/Games/Join', {
                GameId: gameId
            },
                {
                    transformRequest: function (obj) {
                        var str = [];
                        for (var p in obj)
                            str.push(encodeURIComponent(p) + "=" + encodeURIComponent(obj[p]));
                        return str.join("&");
                    },
                    headers: {
                        'Content-Type': 'application/x-www-form-urlencoded',
                        'authorization': 'Bearer ' + access_token
                    }
                })
                .success(function (data) {
                    deferred.resolve(data);
                })
                .error(function (data) {
                    deferred.reject(data);
                });

            return deferred.promise;
        },
        getGameStatus: function (gameId, access_token) {
            var deferred = $q.defer();

            $http.post(url + 'api/Games/Status', {
                GameId: gameId
            },
                {
                    transformRequest: function (obj) {
                        var str = [];
                        for (var p in obj)
                            str.push(encodeURIComponent(p) + "=" + encodeURIComponent(obj[p]));
                        return str.join("&");
                    },
                    headers: {
                        'Content-Type': 'application/x-www-form-urlencoded',
                        'authorization': 'Bearer ' + access_token
                    }
                })
                .success(function (data) {
                    deferred.resolve(data);
                })
                .error(function (data) {
                    deferred.reject(data);
                });

            return deferred.promise;
        },
        playGame: function (gameId, row, col, access_token) {
            var deferred = $q.defer();

            $http.post(url + 'api/Games/Play', {
                GameId: gameId,
                Row: row,
                Col: col
            },
                {
                    transformRequest: function (obj) {
                        var str = [];
                        for (var p in obj)
                            str.push(encodeURIComponent(p) + "=" + encodeURIComponent(obj[p]));
                        return str.join("&");
                    },
                    headers: {
                        'Content-Type': 'application/x-www-form-urlencoded',
                        'authorization': 'Bearer ' + access_token
                    }
                })
                .success(function (data) {
                    deferred.resolve(data);
                })
                .error(function (data) {
                    deferred.reject(data);
                });

            return deferred.promise;
        }
    }
});
