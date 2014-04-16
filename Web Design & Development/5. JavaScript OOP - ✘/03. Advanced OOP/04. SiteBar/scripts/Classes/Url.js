define(function(require) {

    // Include utility
    var Class = require('../Helper/utility.js');

    function _convertToHtml(message, url) {
        var anchor = document.createElement('a');
        anchor.setAttribute('href', url);
        anchor.setAttribute('title', url);
        anchor.setAttribute('target', '_blank');
        anchor.className = "item url";
        anchor.innerHTML = message;

        return anchor;
    }

    var Url = Class.create({
        init: function(message, url) {
            this.message = message;
            this.url = url;

            return this;
        },
        convertToHtml: function() { return _convertToHtml(this.message, this.url); }
    });

    return Url;
})