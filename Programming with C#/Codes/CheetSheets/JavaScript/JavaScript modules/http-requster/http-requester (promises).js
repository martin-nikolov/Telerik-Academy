/// <reference path="jquery-2.0.2.js" />
/// <reference path="q.js" />

var httpRequester = (function () {
    var makeHttpRequst = function (url, type, data) {
        var deferred = Q.defer();

        var stringifiedData = "";
        if (data) {
            stringifiedData = JSON.stringify(data);
        }

        $.ajax({
            url: url,
            type: type,
            data: stringifiedData,
            contentType: "application/json",
            timeout: 5000,
            success: function (resultData) {
                deferred.resolve(resultData);
            },
            error: function (errorData) {
                deferred.reject(errorData);
            }
        })

        return deferred.promise;
    }

    var getJSON = function (url) {
        return makeHttpRequst(url, "GET");
    }

    var postJSON = function (url, data) {
        return makeHttpRequst(url, "POST", data);
    }

    return {
        postJSON: postJSON,
        getJSON: getJSON
    }
}());