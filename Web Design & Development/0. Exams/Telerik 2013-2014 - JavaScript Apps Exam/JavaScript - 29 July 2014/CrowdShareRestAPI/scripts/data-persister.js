define(['http-requester', 'sha1'], function (HttpRequester, SHA1) {
    var DataPersister = (function () {
        function _getUsername() {
            return localStorage.getItem('username');
        }

        function _setUsername(username) {
            localStorage.setItem('username', username);
        }

        function _getSessionKey() {
            return localStorage.getItem('sessionKey');
        }

        function _setSessionKey(sessionKey) {
            localStorage.setItem('sessionKey', sessionKey);
        }

        function _isLoggedIn() {
            var username = _getUsername(),
                sessionKey = _getSessionKey(),
                isLoggedIn = username != null && sessionKey != null;
            return isLoggedIn;            
        }

        function _destroySession() {
            localStorage.clear();
        }

        var BasePersister = function (rootUrl) {
            this.rootUrl = rootUrl;
            this.user = new UserPersister(rootUrl);
            this.post = new PostPersister(rootUrl);
        }

        BasePersister.prototype = {
            isLoggedIn: _isLoggedIn,
            getUsername: _getUsername
        };

        var UserPersister = function (rootUrl) {
            this.rootUrl = rootUrl;
        }

        UserPersister.prototype = {
            register: function (username, password) {
                var url = this.rootUrl + '/user',
                    hash = '' + username + password,
                    authCode = CryptoJS.SHA1(hash).toString();

                return HttpRequester.postJSON(url, {
                                                  username: username,
                                                  authCode: authCode
                                              });
            },
            login: function (username, password) {
                var url = this.rootUrl + '/auth',
                    hash = '' + username + password,
                    authCode = CryptoJS.SHA1(hash).toString();

                return HttpRequester.postJSON(url, {
                                                  username: username,
                                                  authCode: authCode
                                              })
                                    .then(function (response) {
                                        _setUsername(response.username);
                                        _setSessionKey(response.sessionKey);
                                    });
            },
            logout: function () {
                var sessionKey = _getSessionKey(),
                    url = this.rootUrl + '/user';

                return HttpRequester.putJSON(url, sessionKey)
                                    .then(function () {
                                        _destroySession();
                                    });
            },
        };

        var PostPersister = function (rootUrl) {
            this.rootUrl = rootUrl;
        }

        PostPersister.prototype = {
            getPosts: function (fulterByUsername, filterByPattern) {
                var url = this.rootUrl + '/post';

                // TODO: Filtering

                return HttpRequester.getJSON(url);
            },
            create: function (postData) {
                var sessionKey = _getSessionKey(),
                    url = this.rootUrl + '/post';

                return HttpRequester.postJSON(url, postData, sessionKey);
            }
        }

        return {
            getPersister: function (rootUrl) {
                return new BasePersister(rootUrl);
            }
        };
    }());

    return DataPersister;
})