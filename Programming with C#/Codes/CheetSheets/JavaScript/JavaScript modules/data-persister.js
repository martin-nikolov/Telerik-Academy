/// <reference path="http-requester.js" />
/// <reference path="cryptojs-sha1.js" />
/// <reference path="class.js" />

var BullsAndCows = BullsAndCows || {};

BullsAndCows.persisters = (function () {
    var sessionKey = localStorage.getItem("sessionKey");

    var IsLoggedIn = function () {
        var sessionKey = localStorage.getItem("sessionKey");
        if (sessionKey && sessionKey != "") {
            return true;
        }
        else {
            return false;
        }
    };

    var BasePersister = Class.create({
        init: function (serviceUrl) {
            this.serviceUrl = serviceUrl;
            this.users = new UserPersister(serviceUrl + "user/");
        }
    });

    var UserPersister = Class.create({
        init: function (serviceUrl) {
            this.serviceUrl = serviceUrl;
        },
        register: function (username, nickname, password) {
            var hash = CryptoJS.SHA1(password).toString();

            return httpRequester.postJSON(this.serviceUrl + "register", {
                username: username,
                nickname: nickname,
                authCode: hash
            })
            .then(function (data) {
                localStorage.setItem("sessionKey", data.sessionKey);
                localStorage.setItem("nickname", data.nickname);
                sessionKey = data.sessionKey;
            }, function (error) {
                console.log("Error 1");
            });
        },
        login: function (username, password) {
            var hash = CryptoJS.SHA1(password).toString();

            return httpRequester.postJSON(this.serviceUrl + "login", {
                username: username,
                authCode: hash
            })
            .then(function (data) {
                localStorage.setItem("sessionKey", data.sessionKey);
                sessionKey = data.sessionKey;
            }, function (error) {
                console.log("Error 2");
            });
        },
        logout: function () {
            var sessionKey = localStorage.getItem("sessionKey");
            httpRequester.getJSON(this.serviceUrl + "logout/" + sessionKey)
                         .then(function (data) {
                             localStorage.setItem("sessionKey", "");
                             sessionKey = "";
                          });
        },
        scores: function () { }
    });

    return {
        getPersister: function (url) { return new BasePersister(url); },
        loggedIn: IsLoggedIn
    }
}());

//var localPersister = BullsAndCows.persisters.getPersister("http://localhost:40643/api/");
//localPersister.users.register("Kiro123", "Kiro123", "Kiro123");
//localPersister.users.login("Kiro123", "Kiro123");
//localPersister.users.logout();