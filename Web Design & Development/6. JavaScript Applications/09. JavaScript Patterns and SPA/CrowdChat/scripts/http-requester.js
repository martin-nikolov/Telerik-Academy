define(['jquery', 'q'], function($, Q) {
    var HttpRequester = (function() {
        var makeHttpRequest = function(url, type, data) {
            var deferred = Q.defer();

            $.ajax({
                url: url,
                type: type,
                data: data ? JSON.stringify(data) : "",
                contentType: "application/json",
                timeout: 5000,
                success: function(resultData) {
                    deferred.resolve(resultData);
                },
                error: function(errorData) {
                    deferred.reject(errorData);
                }
            });

            return deferred.promise;
        };

        var getJSON = function(url) {
            return makeHttpRequest(url, "GET");
        };

        var postJSON = function(url, data) {
            return makeHttpRequest(url, "POST", data);
        };

        return {
            getJSON: getJSON,
            postJSON: postJSON
        }
    }());

    return HttpRequester;
});