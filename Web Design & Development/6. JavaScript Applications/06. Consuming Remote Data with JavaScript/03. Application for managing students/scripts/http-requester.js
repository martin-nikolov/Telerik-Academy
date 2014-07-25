var HttpRequster = (function() {
    'use strict';

    function makeHttpRequest(url, type, data) {
        var $deffered = jQuery.Deferred();

        var stringifiedData = "";
        if (data) {
            stringifiedData = JSON.stringify(data);
        }

        $.ajax({
            url: url,
            type: type,
            data: stringifiedData,
            contentType: 'application/json',
            timeout: 5000,
            success: function(resultData) {
                $deffered.resolve(resultData);
            },
            error: function(errorData) {
                $deffered.reject(errorData);
            }
        });

        return $deffered.promise();
    }

    function getJSON(url) {
        return makeHttpRequest(url, 'GET');
    }

    function postJSON(url, data) {
        return makeHttpRequest(url, 'POST', data);
    }

    function deleteJSON(url) {
        return makeHttpRequest(url, 'DELETE');
    }

    return {
        getJSON: getJSON,
        postJSON: postJSON,
        deleteJSON: deleteJSON
    };
}());