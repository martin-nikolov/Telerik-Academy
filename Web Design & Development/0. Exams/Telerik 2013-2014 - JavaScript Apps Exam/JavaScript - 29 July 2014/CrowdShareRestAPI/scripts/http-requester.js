define(['jquery', 'q'], function ($, Q) {
    var HttpRequester = (function () {
        var makeHttpRequst = function (url, type, data, sessionKey) {
            var deferred = Q.defer();

            $.ajax({
                       beforeSend: function (request) {
                           if (sessionKey) {
                               request.setRequestHeader("X-SessionKey", sessionKey);
                           }
                       },
                       url: url,
                       type: type,
                       data: (data ? JSON.stringify(data) : ""),
                       contentType: "application/json",
                       timeout: 5000,
                       headers: { 'X-SessionKey': sessionKey },
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

        var postJSON = function (url, data, sessionKey) {
            return makeHttpRequst(url, "POST", data, sessionKey);
        }

        var putJSON = function (url, sessionKey) {
            return makeHttpRequst(url, "PUT", null, sessionKey);
        }

        return {
            postJSON: postJSON,
            getJSON: getJSON,
            putJSON: putJSON
        }
    }());

    return HttpRequester;
})